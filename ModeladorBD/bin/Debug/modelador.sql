--EJECUTAR EL MODELADOR EN LA MISMA BD
set search_path to public;
-----------------GENERADOR DE ESTRUCTURAS 
create or replace function bd_comparar_esquemas_new(cchema_base varchar,cchema_comparar varchar default '')
returns text as 
$BODY$
/*
	Autor : Luis Cruz		Fecha : 22-02-2017
	Objetivo : 
		Retornar las estructuras de tabla que no existan en la comparacion
	Forma de Uso : 
		select * from bd_comparar_esquemas_new('sisplani','negocios')
	
*/
declare 
--RECORRIDO DE LAS CONSULTAS 
	r record;			r1 record;
--ALMACENADORES DE LAS CADENAS GENERADAS 
	cquery text:='';		cstruc_trig text:='';		cstruc_trig_index text:='';
	cdrop_index text:='';		cdrop_trigger text:='';		cdrop_trigger_function text:='';
	celiminacio_vista text:='';
--CONFIRMADORES DE MENSAJE DE CABECERA 
	bmensaje boolean:=true;		bbmensaje boolean:=true;	beliminaSchema boolean:=false;
--NOMBRE DEL ESQUEMA A MOLDEAR 
	xcchema_comparar text:=cchema_comparar;
begin
--		GENERAMOS EL CÓDIGO DE LA ESTRUCTURA DE LAS TABLAS QUE NO EXISTAN
	if length(xcchema_comparar)=0 then
		execute 'CREATE SCHEMA IF NOT EXISTS matrix';
		xcchema_comparar:='matrix';
		beliminaSchema:=true;
	end if;
	cquery :='set search_path to '|| xcchema_comparar ||';';
	bmensaje :=true;
		for r in select tablename::varchar as table_name from pg_tables where schemaname =cchema_base 
			and tablename not in (select tablename from pg_tables where schemaname = xcchema_comparar) 
			and tablename not in (SELECT relname::varchar FROM pg_catalog.pg_inherits
			JOIN pg_catalog.pg_class AS chlcla ON (chlcla.oid = inhrelid)) order by tablename
			loop
				if bmensaje  then
					cquery			:=cquery||chr(13)||'-------------TABLAS AGREGADAS '||chr(13);
					bmensaje		:=false;
				end if;
				cquery:=cquery||chr(13)||coalesce(bd_crear_estructura_tabla(cchema_base ,r.table_name),r.table_name||' III')||chr(13);
				if exists (select description from pg_description
					join pg_class on pg_description.objoid = pg_class.oid
					join pg_namespace on pg_class.relnamespace = pg_namespace.oid
					where relname = r.table_name and nspname= cchema_base limit 1) then
					
					cquery:=cquery||coalesce(bd_crear_estructura_comentario_tabla(cchema_base,r.table_name),r.table_name||' IIII')||chr(13);
				end if;
			end loop;
			bmensaje :=true;
--		GENERAMOS EL CÓDIGO DE LA ESTRUCTURA DE LAS COLUMNAS QUE NO EXISTAN
	for r in 
		select tablename::varchar as table_name from pg_tables where schemaname = cchema_base  
			and tablename in (select tablename from pg_tables where schemaname = xcchema_comparar) 
				and tablename not in (SELECT relname::varchar FROM pg_catalog.pg_inherits
				JOIN pg_catalog.pg_class AS chlcla ON (chlcla.oid = inhrelid)) order by tablename
		loop
			for r1 in select table_name,column_name from information_schema.columns 
				where table_schema=cchema_base  and table_name = r.table_name 
				and column_name not in (select column_name from information_schema.columns 
							where table_schema= xcchema_comparar and table_name = r.table_name) order by ordinal_position
			loop
				if bmensaje  then
					cquery		:=cquery||chr(13)||'-------------COLUMNAS AGREGADAS '||chr(13);
					bmensaje	:=false;
				end if;
				cquery:=cquery||chr(13)||coalesce(bd_crear_estructura_columna(cchema_base ,r.table_name,r1.column_name),r.table_name||' IIIII');
			end loop;
		end loop;
		bmensaje	:=true;
		
--		GENERAMOS EL CÓDIGO DE LA ESTRUCTURA PARA ELIMINAR LAS TABLAS 
	
		for r in select tablename::varchar as table_name from pg_tables where schemaname = xcchema_comparar 
				and tablename not in (select tablename from pg_tables where schemaname = cchema_base) 
				and tablename not in (SELECT relname::varchar FROM pg_catalog.pg_inherits
				JOIN pg_catalog.pg_class AS chlcla ON (chlcla.oid = inhrelid))order by tablename
			loop
				if bmensaje  then
					cquery	:=cquery||chr(13)||'-------------TABLAS ELIMINACION'||chr(13);
					bmensaje:=false;
				end if;
				cquery	:=cquery||bd_crear_estructura_drop_table(xcchema_comparar,r.table_name);
			end loop;
			bmensaje	:=true;
	
--		GENERAMOS EL CÓDIGO DE LA ESTRUCTURA PARA ELIMINAR COLUMNAS 
	for r in select tablename::varchar as table_name from pg_tables where schemaname = cchema_base  
			and tablename in (select tablename table_name from pg_tables where schemaname = xcchema_comparar) 
			and tablename not in (SELECT relname::varchar FROM pg_catalog.pg_inherits
				JOIN pg_catalog.pg_class AS chlcla ON (chlcla.oid = inhrelid))order by tablename
		loop
			for r1 in select table_name,column_name from information_schema.columns 
				where table_schema=xcchema_comparar and table_name = r.table_name 
				and column_name not in (select column_name from information_schema.columns 
							where  table_schema= cchema_base  and table_name = r.table_name) order by ordinal_position
			loop
				if bmensaje  then
					cquery	:=cquery||chr(13)||'-------------COLUMNAS ELIMINADAS '||chr(13);
					bmensaje:=false;
				end if;
				cquery	:=cquery||bd_crear_estructura_drop_column(xcchema_comparar,r1.table_name,r1.column_name);
				
			end loop;
		end loop;
		bmensaje	:=true;
		
--		GENERAMOS EL CÓDIGO DE LOS PRIMARY KEY Y UNIQUE DE LAS TABLAS , FOREING KEY
	for r in select table_name ,constraint_name,constraint_type from information_schema.table_constraints 
		where table_schema = cchema_base  and constraint_type in ('PRIMARY KEY','UNIQUE','FOREIGN KEY') 
			and table_name not in (select tablename from pg_tables where schemaname = xcchema_comparar)
				and table_name not in (SELECT relname::varchar FROM pg_catalog.pg_inherits
					JOIN pg_catalog.pg_class AS chlcla ON (chlcla.oid = inhrelid))
				group by table_name ,constraint_name,constraint_type order by constraint_type desc
		loop
			if r.constraint_type in ('PRIMARY KEY','UNIQUE')  then
				if bmensaje  then
					cquery	:=cquery||chr(13)||'-------------PRIMARY KEY Y UNIQUE'||chr(13);
					bmensaje:=false;
				end if;
				cquery	:=cquery||chr(13)||coalesce(bd_crear_estructura_pk_uk(cchema_base,r.table_name,r.constraint_type,r.constraint_name,null),r.table_name||' IIIIII')||chr(13);
			else
				if bbmensaje  then
					cquery	:=cquery||chr(13)||'-------------FOREIGN KEY'||chr(13);
					bbmensaje:=false;
				end if;
				cquery	:=cquery||chr(13)||coalesce(bd_crear_estructura_fk(cchema_base,r.table_name,r.constraint_name,null),r.table_name||' IIIIIII')||chr(13);
			end if;	
		end loop;		
--	cquery:=concat(cquery,chr(13),iif(position('CREATE' in cqueryTriggerStruc)>0,cqueryTriggerStruc,''),
--			iif(position('CREATE' in cqueryTrigger)>0,cqueryTrigger,''),
--				chr(13),iif(position('CREATE' in cqueryIndex)>0,cqueryIndex,''));
	--ELIMINAMOS EL ESQUEMA CREADO 
	if beliminaSchema then
		execute 'DROP SCHEMA IF EXISTS matrix';
		cquery:=replace(cquery,'matrix',cchema_base);
	end if;
	--eliminacion de registros en general 
	cdrop_index 		:= public.generar_create_drop_index(xcchema_comparar);
	cdrop_trigger 		:= public.generar_create_drop_trigger(xcchema_comparar);
	cdrop_trigger_function 	:= public.generar_create_drop_trigger_function(xcchema_comparar);
	celiminacio_vista 	:= public.bd_crear_estructura_eliminacio_vista(xcchema_comparar);
	
	--estructura trigger y creacion de triggers u index 
	cstruc_trig		:= public.bd_crear_estructura_trigger_funciones(cchema_base);
	cstruc_trig_index	:= replace(public.generar_create_trigger_index(cchema_base),'set search_path to '|| cchema_base,'') ;
	
	cquery:=concat(	chr(13)||cquery	
			,chr(13)||cdrop_index 
			,chr(13)||cdrop_trigger
			,chr(13)||cdrop_trigger_function
			,chr(13)||celiminacio_vista
			,chr(13)||bd_crear_estructura_vista(cchema_base)
			,chr(13)||cstruc_trig,cstruc_trig_index);
	
	return cquery;
end;
$BODY$
language plpgsql volatile 
cost 1000;

create or replace function generar_create_drop_trigger_function(cschema_patron varchar)
returns text as
$BODY$
/*
	Autor : Luis Cruz 			Fecha : 22-02-2017
	Objetivo : 
		Crear la Estructura de los trigger y index , de las tablas existentes en el esquema 
	Forma de Uso : 
		select public.generar_create_drop_trigger_function('sisplani')
*/
declare 
--RECORRIDO DE LAS CONSULTAS 
	r record;
--ALMACENADORES DE LAS CADENAS GENERADAS 
	cquery   text := '';
begin
--	eliminamo trigeers
	for r in select specific_name,routine_name from information_schema.routines where specific_schema = cschema_patron and data_type = 'trigger'
			order by specific_name
	loop	--ESTRUCTURA
		cquery :=cquery || 'DROP FUNCTION IF EXISTS '||cschema_patron||'.'||r.routine_name||'();' || chr(13);
		
	end loop;
	
	return replace(cquery,cschema_patron||'.','');
end;
$BODY$
language plpgsql volatile
cost 1000;
	
create or replace function generar_create_drop_index(cschema_patron varchar)
returns text as
$BODY$
/*
	Autor : Luis Cruz 			Fecha : 22-02-2017
	Objetivo : 
		Crear la Estructura de elimiancion de index 
	Forma de Uso : 
		select public.generar_create_drop_index('sisplani')
*/
declare 
--RECORRIDO DE LAS CONSULTAS 
	r record;
--ALMACENADORES DE LAS CADENAS GENERADAS 
	cquery   text := '';
begin
--		LOS CONSTRAINT SE ANIDAN , DEBEMOS RECORRER PARA PODER GENERAR DATOS CORRECTAMENTE

	for r in select indexname,indexdef from pg_indexes where schemaname = cschema_patron 
		and indexname not in (select indexname from pg_indexes where schemaname = cschema_patron 
		and indexdef  ilike '%UNIQUE%') and tablename not in (SELECT relname::varchar FROM pg_catalog.pg_inherits
			JOIN pg_catalog.pg_class AS chlcla ON (chlcla.oid = inhrelid))
	loop
--		ARMO LA SENTENCIA DE ELIMINACION DE INDEX
		cquery := cquery||chr(13);
		cquery := cquery|| 'DROP INDEX IF EXISTS ' ||r.indexname ||';'||chr(13);
	end loop;
--		RETORNO DE LA ESTRUCTURA DEL INDEX
	
	return replace(cquery,cschema_patron||'.','');
end;
$BODY$
language plpgsql volatile
cost 1000;

create or replace function generar_create_drop_trigger(cschema_patron varchar)
returns text as
$BODY$
/*
	Autor : Luis Cruz 			Fecha : 22-02-2017
	Objetivo : 
		Crear la Estructura de los trigger y index , de las tablas existentes en el esquema 
	Forma de Uso : 
		select public.generar_create_drop_trigger('sisplani')
*/
declare 
--RECORRIDO DE LAS CONSULTAS 
	r1 record;		r2 record;
--ALMACENADORES DE LAS CADENAS GENERADAS 
	cquery   text := '';	cqueryIndex text:='';	cqueryTrigger text:='';
	calterna text := '';	ctable_ant text:='';
begin
	--TRIGGERS
--	cqueryTrigger		:=cqueryTrigger||chr(13)||'-------------TRIGGERS '||chr(13); 
	for r2 in 
		select tablename::varchar as table_name from pg_tables where schemaname = cschema_patron 
			and tablename not in (SELECT relname::varchar FROM pg_catalog.pg_inherits
			JOIN pg_catalog.pg_class AS chlcla ON (chlcla.oid = inhrelid))
		order by tablename asc
	loop 
	--		DEBEMOS RECORRER PARA PODER GENERAR DATOS CORRECTAMENTE
		for r1 in select trigger_name from information_schema.triggers 
			where event_object_table = r2.table_name and trigger_schema = cschema_patron group by trigger_name order by trigger_name
			loop
	--		AGREGAMOS CODIGO DE ELIMINACION 
				cquery := cquery||'DROP TRIGGER IF EXISTS ' || r1.trigger_name 
					|| ' ON ' || r2.table_name ||';'||chr(13);
					cquery := cquery||chr(13);
			end loop;
	end loop;
	
	return cquery;
end;
$BODY$
language plpgsql volatile
cost 1000;

--EJECUTAR EL MODELADOR EN LA MISMA BD
create or replace function generar_create_trigger_index(cschema_patron varchar)
returns text as
$BODY$
/*
	Autor : Luis Cruz 			Fecha : 12-12-2016
	Objetivo : 
		Crear la Estructura de los trigger y index , de las tablas existentes en el esquema 
	Forma de Uso : 
		select public.generar_create_trigger_index('general')
*/
declare 
--RECORRIDO DE LAS CONSULTAS 
	r record;		r1 record;		r2 record;
--ALMACENADORES DE LAS CADENAS GENERADAS 
	cquery   text := '';	cqueryIndex text:='';	cqueryTrigger text:='';
	calterna text := '';	ctable_ant text:='';
begin
	--TRIGGERS
--	cqueryTrigger		:=cqueryTrigger||chr(13)||'-------------TRIGGERS '||chr(13); 
	for r2 in 
		select tablename::varchar as table_name from pg_tables where schemaname = cschema_patron 
			and tablename not in (SELECT relname::varchar FROM pg_catalog.pg_inherits
			JOIN pg_catalog.pg_class AS chlcla ON (chlcla.oid = inhrelid))
		order by tablename asc
	loop 
	--		DEBEMOS RECORRER PARA PODER GENERAR DATOS CORRECTAMENTE
		for r1 in select trigger_name from information_schema.triggers 
			where event_object_table = r2.table_name and trigger_schema = cschema_patron group by trigger_name order by trigger_name
			loop
				calterna:='';
				if ctable_ant <> r2.table_name then
					cquery := cquery || '-------------'|| r2.table_name||chr(13);
					ctable_ant = r2.table_name;
				end if;
				
				for r in select trigger_name,action_timing,event_manipulation,event_object_schema
					,('FOR EACH '||action_orientation)::VARCHAR AS action_orientation,action_statement 
					from information_schema.triggers 
					where event_object_table = r2.table_name 
						and trigger_schema = cschema_patron and trigger_name = r1.trigger_name
				loop
					calterna:=calterna||r.event_manipulation||' OR ';
				end loop;
	--		AGREGAMOS CODIGO DE ELIMINACION 
				cquery := cquery||'DROP TRIGGER IF EXISTS ' || r.trigger_name 
					|| ' ON ' || r2.table_name ||';'||chr(13);
					cquery := cquery||chr(13);
	--		ARMO LA SENTENCIA DE CREACION DE TRIGGER
				cquery := cquery||'CREATE TRIGGER ' || r.trigger_name
					||chr(13)||r.action_timing||' '|| substring(calterna,1,length(calterna)-3)
					||chr(13)||'ON '||r2.table_name 
					||chr(13)||r.action_orientation||' '|| r.action_statement ||';'||chr(13)
					||chr(13)||chr(13);
			end loop;
	end loop;
	cqueryTrigger := public.iif(length(cquery) > 0 ,replace(cquery,cschema_patron||'.',''),'');
	
	--INDEX
	for r in 
		select tablename::varchar as table_name from pg_tables 
		where schemaname = cschema_patron and tablename not in (SELECT relname::varchar FROM pg_catalog.pg_inherits
									JOIN pg_catalog.pg_class AS chlcla ON (chlcla.oid = inhrelid))
		order by tablename asc
	loop 
		cqueryIndex		:=cqueryIndex||bd_crear_estructura_index(cschema_patron,r.table_name,null);
	end loop;

	cquery	:= public.iif(length(cqueryTrigger) > 0 OR length(cqueryIndex) > 0,'set search_path to '|| cschema_patron ||';','')||  public.iif(length(cqueryTrigger) > 0 , chr(13)||'-------------TRIGGERS '||chr(13) || cqueryTrigger ,'')
			||  public.iif(length(cqueryIndex) > 0 , chr(13)||'-------------INDEX '||chr(13) || cqueryIndex,'');
	
	return cquery;
end;
$BODY$
language plpgsql volatile
cost 1000;

--EJECUTAR EL MODELADOR EN LA MISMA BD
create or replace function generar_empresa_nueva(cschema_patron varchar,cschema_nuevo varchar)
returns void as
$BODY$
/*
	Autor : Luis Cruz 			Fecha : 06-10-2016
	Objetivo : 
		Crear Un Nuevo Esquema 
	Forma de Uso : 
		select public.generar_empresa_nueva('nuevo','consecutivo')
	ADVERTENCIA :
		NO LO HAGAS SIN LA SUPERVISION DE UN ADULTO.
*/
declare 
ctextoI text := '';		r record;
begin
	--coonsultamos que el nombre no se repita , Variable Beliminar si es true se saltara la validacion 
	if exists(select nspname from pg_namespace 
		where substring(nspname from 1 for 3) != 'pg_'  and nspname = cschema_nuevo) then
		--EXECTION
			RAISE EXCEPTION 'EL ESQUEMA YA EXISTE ASEGURE DE ELIMINARLO ANTES DE CONTINUAR';
	end if;
	--NOS ASEGURAMOS QUE NO EXISTA EL ESQUEMA
	execute 'drop schema if exists '|| cschema_nuevo ||' cascade;
		create schema if not exists '|| cschema_nuevo ;
	---RECORRIDO PARA LAS 3 FUNCIONES PRINCIPALES DE CREACION DE 
	FOR i IN 1..3
	LOOP
		set search_path to public;
		ctextoI := ('set search_path to '|| cschema_nuevo ||';' ||
			replace((select iif(i = 1 ,bd_crear_estructura_trigger_funciones(cschema_patron),
			iif(i = 2 ,bd_comparar_esquemas(cschema_patron),bd_crear_estructura_vista(cschema_patron)))),'set search_path to '||cschema_patron,''));
		execute ctextoI;
	END LOOP;
end;
$BODY$
language plpgsql volatile
cost 1000;


----RETORNAR EL TEXTO
create or replace function generar_empresa_nueva_texto(cschema_patron varchar,cschema_nuevo varchar)
returns text as
$BODY$
/*
	Autor : Luis Cruz 			Fecha : 06-10-2016
	Objetivo : 
		Crear Un Nuevo Esquema 
	Forma de Uso : 
		select public.generar_empresa_nueva_texto('sanchez_rico','nuevo')
	ADVERTENCIA :
		NO LO HAGAS SIN LA SUPERVISION DE UN ADULTO.
*/
declare 
ctextoI text := '';		r record;
begin
	--NOS ASEGURAMOS QUE NO EXISTA EL ESQUEMA
	ctextoI := ctextoI || 'drop schema if exists '|| cschema_nuevo ||' cascade;
		create schema if not exists '|| cschema_nuevo 
		||'; set search_path to '|| cschema_nuevo ||';' ;
	---RECORRIDO PARA LAS 3 FUNCIONES PRINCIPALES DE CREACION DE 
	FOR i IN 1..3
	LOOP
		set search_path to public;
		ctextoI := ctextoI || replace((select iif(i = 1 ,bd_crear_estructura_trigger_funciones(cschema_patron),
			iif(i = 2 ,bd_comparar_esquemas(cschema_patron),bd_crear_estructura_vista(cschema_patron)))),cschema_patron,cschema_nuevo);
	END LOOP;
--	raise notice '%',ctextoI;
	return ctextoI;
end;
$BODY$
language plpgsql volatile
cost 1000;
---CONDICIONAL TERNARIA 
CREATE OR REPLACE FUNCTION iif(bb boolean,t1 text,t2 text)
  RETURNS text AS
$BODY$
begin
	/* realiza la operación IF en una sóla línea */
        IF bb THEN
            RETURN t1;
        ELSE
            RETURN t2;
        END IF;
 end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 9999;
--FUNCION DE COMPARACION
create or replace function bd_comparar_esquemas(cchema_base varchar,cchema_comparar varchar default '',ctable varchar default 'TODOS',ccolumn varchar default 'TODOS')
returns text as 
$BODY$
/*
	Autor : Luis Cruz		Fecha : 14-07-2016
	Objetivo : Retornar las estructuras de tabla que no existan en la comparacion
	Forma de Uso : 
	select * from bd_comparar_esquemas('face')
*/
declare 
--RECORRIDO DE LAS CONSULTAS 
	r record;		r1 record;
--ALMACENADORES DE LAS CADENAS GENERADAS 
	cquery text:='';	cqueryIndex text:='';		cqueryTrigger text:='';		cqueryTriggerStruc text:='';	
--CONFIRMADORES DE MENSAJE DE CABECERA 
	bmensaje boolean:=true;	bbmensaje boolean:=true;	beliminaSchema boolean:=false;
--CONVERTIMOS LOS VALORES DE CONDICION 
	xctable varchar:=iif(ctable='TODOS',null,ctable); 	xccolumn VARCHAR:=iif(ccolumn='TODOS',null,ccolumn);
--NOMBRE DEL ESQUEMA A MOLDEAR 
	xcchema_comparar text:=cchema_comparar;
begin
--		GENERAMOS EL CÓDIGO DE LA ESTRUCTURA DE LAS TABLAS QUE NO EXISTAN
	if length(xcchema_comparar)=0 and (xctable)isnull and (xccolumn)isnull then
		execute 'CREATE SCHEMA IF NOT EXISTS matrix';
		xcchema_comparar:= 'matrix';
		beliminaSchema	:= true;
	end if;
	cquery	:= 'set search_path to '|| xcchema_comparar ||';';
	bmensaje:= true;
	if (xccolumn)isnull then
		for r in select tablename::varchar as table_name from pg_tables where schemaname =cchema_base 
			and tablename not in (select tablename from pg_tables where schemaname = xcchema_comparar and tablename = coalesce(xctable,tablename)) 
			and tablename not in (SELECT relname::varchar FROM pg_catalog.pg_inherits
			JOIN pg_catalog.pg_class AS chlcla ON (chlcla.oid = inhrelid))
				and tablename = coalesce(xctable,tablename)
			loop
				if bmensaje  then
					cquery		:= cquery||chr(13)	||'-------------TABLAS AGREGADAS '||chr(13);
					cqueryTrigger	:= cqueryTrigger||chr(13)||'-------------TRIGGERS '||chr(13);
					cqueryIndex	:= cqueryIndex||chr(13)	||'-------------INDEX'||chr(13);
					bmensaje	:= false;
				end if;
				cquery	:= cquery||chr(13)||coalesce(bd_crear_estructura_tabla(cchema_base ,r.table_name),r.table_name||' III')||chr(13);
				
				if exists (select description from pg_description
					join pg_class on pg_description.objoid = pg_class.oid
					join pg_namespace on pg_class.relnamespace = pg_namespace.oid
					where relname = r.table_name and nspname= cchema_base limit 1) then
					
					cquery:=cquery||coalesce(bd_crear_estructura_comentario_tabla(cchema_base,r.table_name),r.table_name||' IIII')||chr(13);
				end if;
				cqueryTrigger	:= cqueryTrigger|| bd_crear_estructura_trigger(cchema_base,r.table_name,xctable notnull);
				cqueryIndex	:= cqueryIndex	|| bd_crear_estructura_index(cchema_base,r.table_name,null);
			end loop;
			bmensaje :=true;
	end if;
	if not((xccolumn)isnull) then 
		for r in select tablename::varchar as table_name from pg_tables where schemaname =cchema_base 
			and tablename not in (select tablename from pg_tables where schemaname = xcchema_comparar and tablename = coalesce(xctable,tablename)) 
				and tablename = coalesce(xctable,tablename)
				and tablename not in (SELECT relname::varchar FROM pg_catalog.pg_inherits
							JOIN pg_catalog.pg_class AS chlcla ON (chlcla.oid = inhrelid))
			loop
				if bmensaje then
					cqueryIndex	:=cqueryIndex||chr(13)||'-------------INDEX'||chr(13);
					bmensaje	:=false;
				end if;
--		GENERAMOS EL CÓDIGO DE LOS INDEX 
				cqueryIndex	:=cqueryIndex||bd_crear_estructura_index(cchema_base ,r.table_name,xccolumn);
			end loop;
			bmensaje :=true;
	end if;
--		GENERAMOS EL CÓDIGO DE LA ESTRUCTURA DE LAS COLUMNAS QUE NO EXISTAN
	for r in 
		select tablename::varchar as table_name from pg_tables where schemaname = cchema_base  
			and tablename in (select tablename from pg_tables where schemaname = xcchema_comparar and tablename = coalesce(xctable,tablename)) 
				and tablename = coalesce(xctable,tablename)
				and tablename not in (SELECT relname::varchar FROM pg_catalog.pg_inherits
				JOIN pg_catalog.pg_class AS chlcla ON (chlcla.oid = inhrelid))
		loop
			for r1 in select table_name,column_name from information_schema.columns 
				where table_schema=cchema_base  and table_name = r.table_name 
				and column_name not in (select column_name from information_schema.columns 
							where table_schema= xcchema_comparar and table_name = r.table_name) order by ordinal_position
			loop
				if bmensaje  then
					cquery		:=cquery||chr(13)||'-------------COLUMNAS AGREGADAS '||chr(13);
					bmensaje	:=false;
				end if;
				cquery	:= cquery||chr(13)||coalesce(bd_crear_estructura_columna(cchema_base , r.table_name , r1.column_name) , r.table_name||' IIIII');
			end loop;
		end loop;
		bmensaje	:=true;
		
--		GENERAMOS EL CÓDIGO DE LA ESTRUCTURA PARA ELIMINAR LAS TABLAS 
	if (xccolumn)isnull then
		for r in select tablename::varchar as table_name from pg_tables where schemaname = xcchema_comparar 
				and tablename not in (select tablename from pg_tables where schemaname = cchema_base and tablename = coalesce(xctable,tablename) ) 
				and tablename = coalesce(xctable,tablename)
				and tablename not in (SELECT relname::varchar FROM pg_catalog.pg_inherits
				JOIN pg_catalog.pg_class AS chlcla ON (chlcla.oid = inhrelid))
			loop
				if bmensaje  then
					cquery	:=cquery||chr(13)||'-------------TABLAS ELIMINACION'||chr(13);
					bmensaje:=false;
				end if;
				cquery	:=cquery||bd_crear_estructura_drop_table(xcchema_comparar,r.table_name);
			end loop;
			bmensaje	:=true;
	end if;
--		GENERAMOS EL CÓDIGO DE LA ESTRUCTURA PARA ELIMINAR COLUMNAS 
	for r in select tablename::varchar as table_name from pg_tables where schemaname = cchema_base  
			and tablename in (select tablename table_name from pg_tables where schemaname = xcchema_comparar and tablename = coalesce(xctable,tablename)) 
			and tablename = coalesce(xctable,tablename)
			and tablename not in (SELECT relname::varchar FROM pg_catalog.pg_inherits
				JOIN pg_catalog.pg_class AS chlcla ON (chlcla.oid = inhrelid))
		loop
			for r1 in select table_name,column_name from information_schema.columns 
				where table_schema=xcchema_comparar and table_name = r.table_name 
				and column_name not in (select column_name from information_schema.columns 
							where  table_schema= cchema_base  and table_name = r.table_name) order by ordinal_position
			loop
				if bmensaje  then
					cquery	:=cquery||chr(13)||'-------------COLUMNAS ELIMINADAS '||chr(13);
					bmensaje:=false;
				end if;
				cquery	:=cquery||bd_crear_estructura_drop_column(xcchema_comparar,r1.table_name,r1.column_name);
				
			end loop;
		end loop;
		bmensaje	:=true;
		
--		GENERAMOS EL CÓDIGO DE LOS PRIMARY KEY Y UNIQUE DE LAS TABLAS , FOREING KEY
	for r in select table_name ,constraint_name,constraint_type from information_schema.table_constraints 
		where table_schema = cchema_base  and constraint_type in ('PRIMARY KEY','UNIQUE','FOREIGN KEY') 
			and table_name not in (select tablename from pg_tables where schemaname = xcchema_comparar and tablename = coalesce(xctable,tablename))
				and table_name = coalesce(xctable,table_name) 
				and table_name not in (SELECT relname::varchar FROM pg_catalog.pg_inherits
					JOIN pg_catalog.pg_class AS chlcla ON (chlcla.oid = inhrelid))
				group by table_name ,constraint_name,constraint_type order by constraint_type desc
		loop
			if r.constraint_type in ('PRIMARY KEY','UNIQUE')  then
				if bmensaje  then
					cquery	:=cquery||chr(13)||'-------------PRIMARY KEY Y UNIQUE'||chr(13);
					bmensaje:=false;
				end if;
				cquery	:= cquery||chr(13)||coalesce(bd_crear_estructura_pk_uk(cchema_base,r.table_name,r.constraint_type,r.constraint_name,xccolumn),r.table_name||' IIIIII')||chr(13);
			else
				if bbmensaje  then
					cquery		:= cquery||chr(13)||'-------------FOREIGN KEY'||chr(13);
					bbmensaje	:= false;
				end if;
				cquery	:=cquery||chr(13)||coalesce(bd_crear_estructura_fk(cchema_base,r.table_name,r.constraint_name,xccolumn),r.table_name||' IIIIIII')||chr(13);
			end if;	
		end loop;
		
	cquery	:= concat(cquery,chr(13),
			iif(position('CREATE' in cqueryTriggerStruc)>0,cqueryTriggerStruc,''),
			iif(position('CREATE' in cqueryTrigger)>0,cqueryTrigger,''),chr(13),
			iif(position('CREATE' in cqueryIndex)>0,cqueryIndex,''));
	--ELIMINAMOS EL ESQUEMA CREADO 
	if beliminaSchema then
		execute 'DROP SCHEMA IF EXISTS matrix';
		cquery:=replace(cquery,'matrix',cchema_base);
	end if;
	if (xccolumn)isnull then
		cquery:=cquery||bd_crear_estructura_eliminacio_vista(cchema_base) 
			||chr(13)||bd_crear_estructura_vista(cchema_base);
	end if;
--	raise notice '%',cquery;
	return cquery;
end;
$BODY$
language plpgsql volatile 
cost 1000;

-----------CREANDO LA ESTRUCTURA DE LA TABLA
create or replace function bd_crear_estructura_tabla(cschema varchar,ctabla varchar)
returns text as 
$BODY$
/*
	Autor : Luis Cruz		Fecha : 01-07-2016
	Objetivo : Retornar la estructuras de tabla segun la tabla y el esquema
	Forma de Uso : 
	conceptos_sel_varios,liquidacion_historial,personal_subsidio
	select bd_crear_estructura_tabla('face','param_expo_sap')
	
*/
declare 
r record;	cquery text:=format('CREATE TABLE IF NOT EXISTS %I (',ctabla)||chr(13);
cmedida	text:='';
begin 
--		RECORRIDO A LA TABLA QUE CONTIENE LOS DATOS DE LA COLUMNA
	for r in select column_name , column_default , is_nullable , data_type , character_maximum_length , numeric_precision , numeric_scale from information_schema.columns 
			where table_name = ctabla and table_schema = cschema order by ordinal_position
	loop	-- Caso especial para los arrays 
		if lower(r.data_type) = 'array' then 
			-- SI FUESE ARRAY UN TRATO ESPECIAL 
			cquery	:= cquery || (SELECT (concat(f.attname , ' ' , pg_catalog.format_type(f.atttypid,f.atttypmod) , (case when f.attnotnull then 'NOT NULL ' else '' end) ,
						(CASE WHEN f.atthasdef = 't' THEN ' DEFAULT ' || d.adsrc else '' END ) ,','||chr(13)))
						FROM pg_attribute f  
						    JOIN pg_class c ON c.oid = f.attrelid  
						    JOIN pg_type t ON t.oid = f.atttypid  
						    LEFT JOIN pg_attrdef d ON d.adrelid = c.oid AND d.adnum = f.attnum  
						    LEFT JOIN pg_namespace n ON n.oid = c.relnamespace  
						    LEFT JOIN pg_constraint p ON p.conrelid = c.oid AND f.attnum = ANY (p.conkey)  
						    LEFT JOIN pg_class AS g ON p.confrelid = g.oid  
						WHERE c.relkind = 'r'::char  
						    AND n.nspname = cschema AND c.relname = ctabla AND f.attname = r.column_name limit 1);
		else 
			-- ENVIAMOS LOS DATOS PARA QUE LA FUNCION LOS PROCECE 
			cquery	:= cquery || bd_crear_estructura_base(r.column_name , r.column_default , r.is_nullable , r.data_type , 
						r.character_maximum_length , r.numeric_precision , r.numeric_scale);
		end if;
	end loop;
--		RETORNO DE LA ESTRUCTURA DE LA TABLA
	return substring(cquery,1,length(cquery)-2)||chr(13)||');';
end;
$BODY$
language plpgsql volatile 
cost 1000;
-----------CREANDO LA ESTRUCTURA PARA LAS COLUMNAS CON NOMBRES IGUALES PERO PROPIEDADES DIFERENTES
create or replace function bd_crear_estructura_comparar_column(cschema varchar,ctabla varchar)
returns text as 
$BODY$
/*
	Autor : Luis Cruz		Fecha : 20-07-2016
	Objetivo : --
	Forma de Uso : 
	select bd_crear_estructura_comparar_column('face','param_expo_sap')
	
*/
declare 
r record;	cquery text:=format('CREATE TABLE IF NOT EXISTS %I (',ctabla)||chr(13);
cmedida	text:='';
begin 
--		RECORRIDO A LA TABLA QUE CONTIENE LOS DATOS DE LA COLUMNA
	for r in select column_name,column_default,is_nullable,data_type,character_maximum_length,numeric_precision,numeric_scale from information_schema.columns 
		where table_name = ctabla and table_schema = cschema order by ordinal_position
	loop
--		ENVIAMOS LOS DATOS PARA QUE LA FUNCION LOS PROCECE 
		cquery	:=cquery||bd_crear_estructura_base(r.column_name,r.column_default,r.is_nullable,
			r.data_type,r.character_maximum_length,r.numeric_precision,r.numeric_scale);
	end loop;
--		RETORNO DE LA ESTRUCTURA DE LA TABLA
	return substring(cquery,1,length(cquery)-2)||chr(13)||');';
end;
$BODY$
language plpgsql volatile 
cost 1000;

-----------CREANDO ESTRUCTURA PARA AGREGAR 1 COLUMNA
create or replace function bd_crear_estructura_columna(cschema varchar,ctabla varchar,ccolumn varchar)
returns text as 
$BODY$
/*
	Autor : Luis Cruz		Fecha : 01-07-2016
	Objetivo : Retornar la estructuras de una columna segun la tabla , esquema y columna
	Forma de Uso : 
	select bd_crear_estructura_columna('face','clases','ayuda')
	
*/
declare 
r record;	cquery text:='';	cmedida	text:='';
begin 
--		RECORRIDO A LA TABLA QUE CONTIENE LOS DATOS DE LA COLUMNA
	select column_name,column_default,is_nullable,data_type,character_maximum_length,numeric_precision,numeric_scale from information_schema.columns 
		where table_name = ctabla and table_schema = cschema and column_name= ccolumn into r;
		
--		ENVIAMOS LOS DATOS PARA QUE LA FUNCION LOS PROCECE 
		cquery	:=cquery||bd_crear_estructura_base(r.column_name,r.column_default,r.is_nullable,
			r.data_type,r.character_maximum_length,r.numeric_precision,r.numeric_scale);
			
--		RETORNO DE LA ESTRUCTURA DE LA TABLA
	return 'ALTER TABLE '|| ctabla ||' ADD '||substring(cquery,1,length(cquery)-2)||';'||chr(13);
end;
$BODY$
language plpgsql volatile 
cost 1000;

---------------ARMADO DE SENTENCIA SEGUN DATOS ENVIADOS POR PARAMETROS
create or replace function bd_crear_estructura_base(column_name varchar,column_default varchar,is_nullable varchar,data_type varchar,character_maximum_length int,numeric_precision int,numeric_scale int)
returns text as 
$BODY$
/*
	Autor : Luis Cruz		Fecha : 01-07-2016
	Objetivo : Retornar la estructuras de creacion de columas con los datos que se envien por parametros
	Forma de Uso : 
	select bd_crear_estructura_base('gc_id','','YES','character varying', 10 ,10 ,0)
*/
declare 
cquery text:='';	cmedida	text:='';
begin 
--		CONDICION PARA EL INGRESO DE DATOS PARA CADA COLUMNA
		if position('nextval' in coalesce(column_default,'')) = 0 then 
--		CUANDO EL TIPO DE DATO ES VARCHAR
			case when substring(data_type,1,9) = 'character' then
				cmedida:=iif(character_maximum_length isnull,'','('|| character_maximum_length ||')' );
				
--		CUANDO EL TIPO DE DATO ES NUMERICO
			when substring(data_type,1,3) = 'num' then
				cmedida:=iif(numeric_precision isnull,'','('|| numeric_precision ||','|| numeric_scale ||')');
				
			else	cmedida:='';	end case;
			
--		FORMO EL QUERY QUE CONTIENE LA ESTRUCTURA DE LA TABLA , LA CUAL SE VA CONTRUYENDO A MEDIDA DEL RECORRIDO DE LA TABLA		 
			cquery := column_name || ' ' || data_type ||cmedida|| ' ' || iif(is_nullable = 'YES','','NOT NULL ') 
				|| iif(column_default is null ,'',' DEFAULT ')||coalesce(column_default,'')||','||chr(13);
		else
--		SI LA CULUMNA TIENE UN CAMPO AUTOINCREMENTAL 
			cquery := column_name || ' serial '  ||','||chr(13);
		end if;
	return cquery;
end;
$BODY$
language plpgsql volatile 
cost 1000;
-----------CREANDO LA ESTRUCTURA DE LOS COMENTARIOS DE LA TABLA
create or replace function bd_crear_estructura_comentario_tabla(cschema varchar,ctable_name varchar)
returns text as 
$BODY$

/*	Autor : Luis Cruz		Fecha : 20-07-2017
	Objetivo : Retornar la estructuras de comentarios tabla segun la tabla y el esquema
	Forma de Uso : 
	
		select bd_crear_estructura_comentario_tabla('nasca2','productos')
	
*/
declare 
r record;	cquery text:='';		ccomentarioTabla text:='';
begin 
--		DEBEMOS RECORRER PARA PODER GENERAR DATOS CORRECTAMENTE
	-- COMENTARIO DE TABLA 
	for r in select description from pg_description
			join pg_class on pg_description.objoid = pg_class.oid
			join pg_namespace on pg_class.relnamespace = pg_namespace.oid
				where nspname= cschema and relname = ctable_name and objsubid = 0 limit 1
	loop
		cquery := concat( chr(13) , 'COMMENT ON TABLE ' , ctable_name 
			 , ' IS ' , quote_literal(r.description) , ';');
	end loop;
	
	-- COMENTARIO DE COLUMNAS
	for r in SELECT c.table_schema,c.table_name,c.column_name,pgd.description
			FROM pg_catalog.pg_statio_all_tables as st
			inner join pg_catalog.pg_description pgd on (pgd.objoid=st.relid)
			inner join information_schema.columns c on (pgd.objsubid=c.ordinal_position
			and  c.table_schema=st.schemaname and c.table_name=st.relname) 
			where c.table_schema = cschema and c.table_name = ctable_name
		loop
		cquery := cquery||chr(13);
		cquery := concat(cquery , 'COMMENT ON COLUMN ' , ctable_name , '.' , r.column_name , 
			' IS ' , quote_literal(r.description) , ';');
			--cquery := concat(chr(13) , cquery , 'COMMENT ON TABLE ' , ctable_name , '.' , r.column_name , ' IS ' , quote_literal(r.description) , ';');
		end loop;
	raise notice '%' , cquery;
	return cquery;
end;
$BODY$
language plpgsql volatile 
cost 1000;
-----------CREANDO LA ESTRUCTURA DE LOS PRIMARY KEY y UNIQUE DE LA TABLA
create or replace function bd_crear_estructura_pk_uk(cschema varchar,ctable_name varchar,cconstraint_type varchar,
cconstraint_name varchar,ccolumn_name varchar)
returns text as 
$BODY$

/*	Autor : Luis Cruz		Fecha : 04-07-2016
	Objetivo : Retornar la estructuras de los primary key y unique tabla segun la tabla y el esquema
	Forma de Uso : 
	select bd_crear_estructura_pk_uk('jianxing','productos','PRIMARY KEY','pk_productos',null)
*/
declare 
r1 record;	
cquery text:='';calterna	text:='';
begin 
--		LIMPIAMOS LA VARIABLE QUE ALTERNARA LOS DATOS DE LAS LLAVES
		calterna:='';
--		AGREGAMOS CODIGO DE ELIMINACION 
		cquery := cquery||'ALTER TABLE ' || ctable_name || ' DROP CONSTRAINT IF EXISTS ' || cconstraint_name ||';'||chr(13);
		
--		ENVIAMOS LOS DATOS PARA QUE LA FUNCION LOS PROCECE 
--		LOS CONSTRAINT SE ANIDAN , DEBEMOS RECORRER PARA PODER GENERAR DATOS CORRECTAMENTE
			for r1 in select column_name from information_schema.key_column_usage 
				where table_schema = cschema and table_name = ctable_name
				and constraint_name = cconstraint_name and column_name = coalesce(ccolumn_name,column_name)
				order by ordinal_position 
			loop
				calterna:=calterna||r1.column_name||',';
			end loop;

--		RETORNO DE LA ESTRUCTURA DE LA TABLA
	return cquery||'ALTER TABLE ' || ctable_name || ' ADD CONSTRAINT ' || cconstraint_name 
			|| iif(cconstraint_type = 'UNIQUE',' UNIQUE (',' PRIMARY KEY (')|| (substring(calterna,1,length(calterna)-1)) ||');' ||chr(13);
end;
$BODY$
language plpgsql volatile 
cost 1000;

-----------CREANDO LA ESTRUCTURA DE LOS FOREIGN KEY DE LA TABLA
create or replace function bd_crear_estructura_fk(cschema varchar,ctable_name varchar,cconstraint_name varchar,ccolumn_name varchar)
returns text as 
$BODY$

/*	Autor : Luis Cruz		Fecha : 04-07-2016
	Objetivo : Retornar la estructuras de las llaves foreaneas tabla segun la tabla y el esquema
	Forma de Uso : 
	select bd_crear_estructura_fk('jianxing','productos','fk_prod_tipo',null)
*/
declare 
r1 record;	rdatos record;
cquery text:='';
calterna	text:='';
begin 
--		LIMPIAMOS LA VARIABLE QUE ALTERNARA LOS DATOS DE LAS LLAVES
		calterna:='';
--		AGREGAMOS CODIGO DE ELIMINACION 
		cquery := cquery||'ALTER TABLE ' || ctable_name || ' DROP CONSTRAINT IF EXISTS ' || cconstraint_name ||';'||chr(13);
--		LOS CONSTRAINT SE ANIDAN , DEBEMOS RECORRER PARA PODER GENERAR DATOS CORRECTAMENTE
			for r1 in select column_name from information_schema.key_column_usage 
				where table_schema = cschema and table_name = ctable_name
				and constraint_name = cconstraint_name and column_name = coalesce(ccolumn_name,column_name)
				order by ordinal_position 
			loop
				calterna:=calterna||r1.column_name||',';
			end loop;
--		DATOS ON  \\  TABLA REFERENCIAL
			select table_schema,table_name,update_rule,delete_rule from information_schema.constraint_table_usage tu
				inner join information_schema.referential_constraints using(constraint_name)
				where tu.constraint_schema = cschema and tu.constraint_name = cconstraint_name limit 1 into rdatos;
				
--		RETORNO DE LA ESTRUCTURA DE LA TABLA
	cquery:=cquery||'ALTER TABLE ' || ctable_name || ' ADD CONSTRAINT ' || cconstraint_name 
			|| ' FOREIGN KEY('|| (substring(calterna,1,length(calterna)-1)) 
			||') REFERENCES '|| rdatos.table_schema ||'.'|| rdatos.table_name ||' ('|| (substring(calterna,1,length(calterna)-1)) 
			||') MATCH SIMPLE ON UPDATE '|| rdatos.update_rule ||' ON DELETE '|| rdatos.delete_rule ||';'||chr(13);
	return replace(cquery,cschema||'.','');
end;
$BODY$
language plpgsql volatile 
cost 1000;

-----------CREANDO LA ESTRUCTURA DE LOS TRIGGER DE LA TABLA
create or replace function bd_crear_estructura_trigger(cschema varchar,ctable_name varchar,bunaTabla boolean)
returns text as 
$BODY$

/*	Autor : Luis Cruz		Fecha : 05-07-2016
	Objetivo : Retornar la estructuras de las llaves foreaneas tabla segun la tabla y el esquema
	Forma de Uso : 
	select bd_crear_estructura_trigger('zorritos','personal_activ',true)
*/
declare 
r record;	r1 record;	cquery text:='';	cqueryStrucureTrigger text:='';
calterna	text:='';
begin 

--		DEBEMOS RECORRER PARA PODER GENERAR DATOS CORRECTAMENTE
	for r1 in select trigger_name from information_schema.triggers 
		where event_object_table = ctable_name and trigger_schema = cschema group by trigger_name order by trigger_name
		loop
			calterna:='';
			for r in select trigger_name,action_timing,event_manipulation,event_object_schema
				,('FOR EACH '||action_orientation)::VARCHAR AS action_orientation,action_statement 
				from information_schema.triggers 
				where event_object_table = ctable_name 
					and trigger_schema = cschema and trigger_name = r1.trigger_name
			loop
				calterna:=calterna||r.event_manipulation||' OR ';
			end loop;
			--CONDICIONAL PARA LA ESTRUCTURA DE EL TRIGGER
--			if bunaTabla then
				cquery :=cquery||bd_crear_estructura_trigger_funciones(cschema,replace(r.trigger_name,cschema||'.',''));
--			end if;
			cquery := cquery||chr(13);
--		AGREGAMOS CODIGO DE ELIMINACION 
			cquery := cquery||'DROP TRIGGER IF EXISTS ' || r.trigger_name 
				|| ' ON ' || ctable_name ||';'||chr(13);
				cquery := cquery||chr(13);
--		ARMO LA SENTENCIA DE CREACION DE TRIGGER
			cquery := cquery||'CREATE TRIGGER ' || r.trigger_name
				||chr(13)||r.action_timing||' '|| substring(calterna,1,length(calterna)-3)
				||chr(13)||'ON '||ctable_name 
				||chr(13)||r.action_orientation||' '|| r.action_statement ||';'||chr(13);
		end loop;
		
	return replace(cquery,cschema||'.','');
end;
$BODY$
language plpgsql volatile 
cost 1000;
-----------CREANDO LA ESTRUCTURA DE LOS TRIGGERS 
create or replace function bd_crear_estructura_trigger_funciones(cschema varchar,croutine_name varchar default null)
returns text as 
$BODY$
/*	Autor : Luis Cruz		Fecha : 14-07-2016
	Objetivo : Retornar la estructuras de las funciones
	Forma de Uso : 
	select bd_crear_estructura_trigger_funciones('zorritos','personal_activ_del_tri_after')
*/
declare 
cquery text:='';	r record;
begin 
--		ARMO LA SENTENCIA DE ELIMINACION DE VISTA 
	for r in select trim(routine_name)as routine_name,pg_get_functiondef((specific_schema||'.'||routine_name)::regproc) from information_schema.routines 
		where specific_schema = cschema and data_type = 'trigger' order by routine_name
	loop
	
		--YA QUE NO SE PUDO ENCONTRAR EL REGISTRO CON EL WHERE , ENTONCES CON LA SEGUNDA CONDICIONAL SOLO SELECCIONARE UNA CONDICIONAL
		if croutine_name isnull then
			cquery := cquery||chr(13);
			cquery := cquery||r.pg_get_functiondef||';';
		else
			--YA QUE LOS NOMBRE DE LOS DATOS NO COINCIDEN 'MEZCLO UNA FUNCION A MI CONVENIENCIA'
			if length(btrim(r.routine_name,croutine_name))=0 then
				cquery := cquery||chr(13);
				cquery := cquery||r.pg_get_functiondef||';';
				exit;
			end if;
		end if;
	end loop;
	
	return replace(cquery,cschema||'.','');
end;
$BODY$
language plpgsql volatile 
cost 1000;
-----------CREANDO LA ESTRUCTURA DE LOS INDEX DE UNA COLUMNA
create or replace function bd_crear_estructura_index(cschema varchar,ctable_name varchar,ccolumn_name varchar)
returns text as 
$BODY$
/*	Autor : Luis Cruz		Fecha : 05-07-2016
	Objetivo : Retornar la estructuras de las llaves foreaneas tabla segun la tabla y el esquema
	Forma de Uso : 
	select bd_crear_estructura_index('zorritos','payroll',null)
*/
declare 
r record;	cquery text:='';
begin 
--		LOS CONSTRAINT SE ANIDAN , DEBEMOS RECORRER PARA PODER GENERAR DATOS CORRECTAMENTE
	for r in select indexname,indexdef from pg_indexes where schemaname=cschema and tablename = ctable_name
		and indexname not in (select indexname from pg_indexes where schemaname=cschema and tablename = ctable_name
		and indexdef  ilike '%UNIQUE%') and indexdef  ilike '%'||coalesce(ccolumn_name,'')||'%'
	loop
--		ARMO LA SENTENCIA DE ELIMINACION DE INDEX
		cquery := cquery||chr(13);
		cquery := cquery|| 'DROP INDEX IF EXISTS ' ||r.indexname ||';'||chr(13);
		cquery := cquery||chr(13);
--		ARMO LA SENTENCIA DE CREACION DE INDEX
		cquery := cquery|| r.indexdef ||';'||chr(13);
	end loop;
--		RETORNO DE LA ESTRUCTURA DEL INDEX
	return replace(cquery,cschema||'.','');
end;
$BODY$
language plpgsql volatile 
cost 1000;

-----------CREANDO LA ESTRUCTURA DE LOS ELIMINACION DE TABLA
create or replace function bd_crear_estructura_drop_table(cschema varchar,ctable_name varchar)
returns text as 
$BODY$
/*	Autor : Luis Cruz		Fecha : 05-07-2016
	Objetivo : Retornar la estructuras de las ELIMINACION DE TABLA SEGUN PARAMETROS
	Forma de Uso : 
	select bd_crear_estructura_drop_table('zorritos','payroll')
*/
begin 
	return chr(13)||' DROP TABLE IF EXISTS ' || ctable_name ||' CASCADE ;'||chr(13);
end;
$BODY$
language plpgsql volatile 
cost 1000;

-----------CREANDO LA ESTRUCTURA DE LOS ELIMINACION DE COLUMNAS 
create or replace function bd_crear_estructura_drop_column(cschema varchar,ctable_name varchar,ccolum_name varchar)
returns text as 
$BODY$
/*	Autor : Luis Cruz		Fecha : 05-07-2016
	Objetivo : Retornar la estructuras de las ELIMINACION DE TABLA SEGUN PARAMETROS
	Forma de Uso : 
	select bd_crear_estructura_drop_column('zorritos','payroll','payroll')
*/
begin 
	return chr(13)||' ALTER TABLE '|| ctable_name||' DROP COLUMN IF EXISTS ' || ccolum_name||' CASCADE ;'||chr(13);
end;
$BODY$
language plpgsql volatile 
cost 1000;
-----------CREANDO LA ESTRUCTURA DE LAS VISTAS 
create or replace function bd_crear_estructura_vista(cschema varchar)
returns text as 
$BODY$
/*	Autor : Luis Cruz		Fecha : 05-07-2016
	Objetivo : Retornar la estructuras de las vista
	Forma de Uso : 
	select bd_crear_estructura_vista('zorritos')
*/
declare 
cquery text:='';	r record;
begin 
	for r in select * from information_schema.views where table_schema = cschema order by table_name
	loop
		cquery := cquery||chr(13);
		cquery := cquery|| 'DROP VIEW IF EXISTS ' ||r.table_name||' CASCADE ;'||chr(13);
		cquery := cquery||chr(13);
--		ARMO LA SENTENCIA DE CREACION DE VISTA 
		cquery := cquery|| 'CREATE OR REPLACE VIEW '||r.table_name ||' AS ' || r.view_definition ||chr(13);
	end loop;
	return replace(cquery,cschema||'.','');
end;
$BODY$
language plpgsql volatile 
cost 1000;

-----------CREANDO LA ESTRUCTURA DE LAS VISTAS 
create or replace function bd_crear_estructura_eliminacio_vista(cschema varchar)
returns text as 
$BODY$
/*	Autor : Luis Cruz		Fecha : 05-07-2016
	Objetivo : Retornar la estructuras de las vista
	Forma de Uso : 
	select bd_crear_estructura_eliminacio_vista('zorritos')
*/
declare 
cquery text:='';	r record;
begin 
	for r in select * from information_schema.views where table_schema = cschema
	loop
		cquery := cquery||chr(13);
--		ARMO LA SENTENCIA DE ELIMINACION DE VISTA 
		cquery := cquery|| 'DROP VIEW IF EXISTS ' ||r.table_name||' CASCADE ;'||chr(13);
	end loop;
	return replace(cquery,cschema||'.','');
end;
$BODY$
language plpgsql volatile 
cost 1000;
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------	CONTROL DE FUNCIONES 
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-----------CREANDO LA ESTRUCTURA DE LAS FUNCIONES
CREATE OR REPLACE FUNCTION bd_crear_estructura_funciones(cschema character varying, cproname character varying DEFAULT NULL,bSinEstructuraEliminacion boolean DEFAULT false)
  RETURNS text AS
$BODY$
/*	Autor : Luis Cruz		Fecha : 11-10-2016
	Objetivo : Retornar la estructuras de las funciones EXECPTUANDO A LOS TRIGGERS 
	Forma de Uso : 
	select public.bd_crear_estructura_funciones('base',null,true)
*/
declare 
cquery text:='';	r record;
begin 
	---NOS RETORNARA LA ESTRUCTURA DE ELIMINACION DE LAS FUNCIONES 
		--cquery :='set search_path to '|| cschema ||';';
		if (bSinEstructuraEliminacion = false) then
			cquery := cquery||chr(13);
			cquery := cquery||replace(bd_estrucura_eliminacion_funciones(cschema,cproname),cschema||'.','');
		end if;
		--CREACION DE ESTRUCTURA DE CREACION 
		for r in SELECT pg_get_functiondef(f.oid) FROM pg_catalog.pg_proc f
				INNER JOIN pg_catalog.pg_namespace n ON (f.pronamespace = n.oid)
				WHERE n.nspname = cschema and proname = coalesce(cproname,proname)
				order by pg_get_functiondef(f.oid)
		loop
			--CONDICIONAMOS PARA QUE SOLO SE ACEPTEN FUNCIONES 
			if position('RETURNS trigger' in r.pg_get_functiondef ) = 0 then
				cquery := cquery||chr(13);
				cquery := cquery||r.pg_get_functiondef||';';
			end if;
		end loop;
		--CONTAMOS EL TAMAñO DE LA CADENA 
		if length(cquery) > 0 then
			cquery := 'set search_path to '|| cschema ||';'||chr(13)||cquery;
			cquery := replace(cquery,'FUNCTION '||cschema||'.','FUNCTION ');
		end if;
		
	return cquery;
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 1000;

CREATE OR REPLACE FUNCTION bd_estrucura_eliminacion_funciones(cschema character varying, cfuncname character varying DEFAULT NULL::character varying)
  RETURNS text AS
$BODY$
/*
	Autor : Luis Cruz	Fecha : 03-01-2017	
	Objetivo : 
		eliminar todas las funciones de un esquema
	Forma de Uso:
	
		Select bd_estrucura_eliminacion_funciones('base')
*/
declare
r record;		r1 record;		r2 record;
csql text:='';		cpar text:= '';		cnombre_ant text:= '';
nident int:=0;
begin	--TABLA TEMPORAL , PARA LOS REGISTROS 
	create temp table temp_lista_funciones_parametros(	nombre_funcion varchar,		data_type varchar,	
								ordinal_position int,		identificador int)on commit drop;
	--RECORRIDO A LAS FUNCIONES EXISTENTES 
	for r in select specific_name,reverse(substring(reverse(specific_name),position('_' in reverse(specific_name))+1))as nombre_funcion,data_type,ordinal_position from information_schema.parameters 
			WHERE specific_schema = cschema and reverse(substring(reverse(specific_name),position('_' in reverse(specific_name))+1)) 
					= coalesce(cfuncname,reverse(substring(reverse(specific_name),position('_' in reverse(specific_name))+1)))
			order by nombre_funcion,specific_name,ordinal_position
	loop
		if r.specific_name <> cnombre_ant then
			cnombre_ant 	:= r.specific_name;
			nident		:= nident + 1;
		end if;
		insert into temp_lista_funciones_parametros values (r.nombre_funcion,r.data_type,r.ordinal_position,nident);

	end loop;
	--RECORRIDO A LAS FUNCIONES QUE NO LLEVAN PARAMETROS 
	for r in SELECT proname FROM pg_catalog.pg_proc f
		INNER JOIN pg_catalog.pg_namespace n ON (f.pronamespace = n.oid)
			WHERE n.nspname = cschema and proname not in (select routine_name from information_schema.routines 
				where specific_schema = cschema and data_type = 'trigger') 
				and proname = coalesce(null,proname) and pronargs = 0  order by pg_get_functiondef(f.oid)
	loop
		nident		:= nident + 1;
		insert into temp_lista_funciones_parametros values (r.proname,'',0,nident);

	end loop;
	
	--ARMAMOS LA ESTRUCTURA DE ELIMINACION DE FUNCIONES EXISTENTES 
	for r in select ('DROP FUNCTION IF EXISTS '||nombre_funcion||'(')::varchar as estruc,identificador from temp_lista_funciones_parametros	
			group by nombre_funcion,identificador order by nombre_funcion,identificador
	loop 	cpar := '';--descarga de los parametros 
		for r1 in select data_type,ordinal_position from temp_lista_funciones_parametros
			WHERE identificador = r.identificador order by ordinal_position
		loop	--descarga de parametros 
			cpar := cpar||r1.data_type||',';
		end loop;
		--si el tamaño de cadena es mayor a 0
		if length(cpar) > 0 then
			cpar	:=	substring(cpar,1,length(cpar)-1);
		end if;--Armado de la estructura
		csql := csql || r.estruc || cpar || ');' ||chr(13);
	end loop;
	csql	:= replace(replace(csql,'EXISTS position','EXISTS "position"'),'EXISTS between','EXISTS "between"');
	return csql;
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
  
---borrar las reclaciones de tablas en un esquema determinado
create or replace function borrar_tablas_relaciones(cschema varchar)
returns void as
$BODY$
/*
	Autor : Luis Cruz	Fecha : 20-04-2016
	
	Objetivo : 
		eliminar todas las tablas y su relacion de un esquema
	Forma de Uso:
		Select borrar_tablas_relaciones('base')
*/
declare
r record;	r1 record;
csql text;
begin
--	eliminamos tabla
	for r in select TABLE_NAME from information_schema.tables where table_schema = 'base'
	loop
		csql :='DROP TABLE IF EXISTS '||cschema||'.'||r.TABLE_NAME||' CASCADE';
		execute csql;
	end loop;
--	eliminamos vista 
	for r in select table_name from information_schema.views where table_schema = 'base'
	loop
		csql :='DROP VIEW IF EXISTS '||cschema||'.'||r.table_name;
		execute csql;
	end loop;
--	eliminamo trigeers
	for r in select specific_name,routine_name from information_schema.routines where specific_schema = cschema and data_type = 'trigger'
			order by specific_name
	loop
	
	csql :='DROP FUNCTION IF EXISTS '||cschema||'.'||r.routine_name||'()';
		execute csql;
	end loop;
end;
$BODY$
language plpgsql volatile 
cost 100;
/*		---------------------------------------- RESPALDO ----------------------------------------
	
	SELECT  
	    f.attnum AS number,  
	    f.attname AS name,  
	    f.attnum,  
	    f.attnotnull AS notnull,  
	    pg_catalog.format_type(f.atttypid,f.atttypmod) AS type,  
	    CASE  
		WHEN p.contype = 'p' THEN 't'  
		ELSE 'f'  
	    END AS primarykey,  
	    CASE  
		WHEN p.contype = 'u' THEN 't'  
		ELSE 'f'
	    END AS uniquekey,
	    CASE
		WHEN p.contype = 'f' THEN g.relname
	    END AS foreignkey,
	    CASE
		WHEN p.contype = 'f' THEN p.confkey
	    END AS foreignkey_fieldnum,
	    CASE
		WHEN p.contype = 'f' THEN g.relname
	    END AS foreignkey,
	    CASE
		WHEN p.contype = 'f' THEN p.conkey
	    END AS foreignkey_connnum,
	    CASE
		WHEN f.atthasdef = 't' THEN d.adsrc
	    END AS default
	FROM pg_attribute f  
	    JOIN pg_class c ON c.oid = f.attrelid  
	    JOIN pg_type t ON t.oid = f.atttypid  
	    LEFT JOIN pg_attrdef d ON d.adrelid = c.oid AND d.adnum = f.attnum  
	    LEFT JOIN pg_namespace n ON n.oid = c.relnamespace  
	    LEFT JOIN pg_constraint p ON p.conrelid = c.oid AND f.attnum = ANY (p.conkey)  
	    LEFT JOIN pg_class AS g ON p.confrelid = g.oid  
	WHERE c.relkind = 'r'::char  
	    AND n.nspname = 'nasca2'  -- Replace with Schema name  
	    AND c.relname = 'servicios'  -- Replace with table name  
	    AND f.attnum > 0 ORDER BY number;
	    
*/