-- Table: public.errors

-- DROP TABLE public.errors;


CREATE TABLE public.errors
(
    errors_id integer NOT NULL DEFAULT nextval('errors_errors_id_seq'::regclass),
    errors_ts_created timestamp without time zone NOT NULL,
    errors_ts_inserted timestamp without time zone NOT NULL,
    errors_sourceip text COLLATE pg_catalog."default" NOT NULL,
    errors_programversion character varying(20) COLLATE pg_catalog."default" NOT NULL,
    errors_message text COLLATE pg_catalog."default" NOT NULL,
    errors_stacktrace text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT errors_pkey PRIMARY KEY (errors_id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.errors
    OWNER to dbsgasupport;

-- Index: idx_errors_errors_message

-- DROP INDEX public.idx_errors_errors_message;

CREATE INDEX idx_errors_errors_message
    ON public.errors USING btree
    (errors_message COLLATE pg_catalog."default")
    TABLESPACE pg_default;

-- Index: idx_errors_errors_programversion

-- DROP INDEX public.idx_errors_errors_programversion;

CREATE INDEX idx_errors_errors_programversion
    ON public.errors USING btree
    (errors_programversion COLLATE pg_catalog."default")
    TABLESPACE pg_default;

-- Index: idx_errors_errors_stacktrace

-- DROP INDEX public.idx_errors_errors_stacktrace;

CREATE INDEX idx_errors_errors_stacktrace
    ON public.errors USING btree
    (errors_stacktrace COLLATE pg_catalog."default")
    TABLESPACE pg_default;
    
    
    
-- Table: public.stats_persession

-- DROP TABLE public.stats_persession;

CREATE TABLE public.stats_persession
(
    stats_persession_id integer NOT NULL DEFAULT nextval('stats_persession_stats_persession_id_seq'::regclass),
    stats_persession_userkey character varying(64) COLLATE pg_catalog."default" NOT NULL,
    stats_persession_sessionstart timestamp without time zone NOT NULL,
    stats_persession_sessionend timestamp without time zone NOT NULL,
    stats_persession_hashes integer NOT NULL,
    stats_persession_computerkey character varying(64) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT stats_persession_pkey PRIMARY KEY (stats_persession_id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.stats_persession
    OWNER to dbsgasupport;

-- Index: idx_stats_persession_computerkey

-- DROP INDEX public.idx_stats_persession_computerkey;

CREATE INDEX idx_stats_persession_computerkey
    ON public.stats_persession USING btree
    (stats_persession_computerkey COLLATE pg_catalog."default")
    TABLESPACE pg_default;

-- Index: idx_stats_persession_sessionstart

-- DROP INDEX public.idx_stats_persession_sessionstart;

CREATE INDEX idx_stats_persession_sessionstart
    ON public.stats_persession USING btree
    (stats_persession_sessionstart)
    TABLESPACE pg_default;

-- Index: idx_stats_persession_userkey

-- DROP INDEX public.idx_stats_persession_userkey;

CREATE INDEX idx_stats_persession_userkey
    ON public.stats_persession USING btree
    (stats_persession_userkey COLLATE pg_catalog."default")
    TABLESPACE pg_default;


    -- Table: public.stats_daily

-- DROP TABLE public.stats_daily;

CREATE TABLE public.stats_daily
(
  stats_daily_id integer NOT NULL DEFAULT nextval('stats_daily_stats_daily_id_seq'::regclass),
  stats_daily_totalusers integer NOT NULL,
  stats_daily_activeusers integer NOT NULL,
  stats_daily_totalcomputers integer NOT NULL,
  stats_daily_ts timestamp without time zone NOT NULL,
  stats_daily_activecomputers integer NOT NULL,
  CONSTRAINT pkey_stats_daily_stats_daily_id PRIMARY KEY (stats_daily_id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public.stats_daily
  OWNER TO dbsgasupport;


    