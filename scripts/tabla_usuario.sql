DROP DATABASE IF EXISTS sisnh_bd;

CREATE DATABASE sisnh_bd;

USE sisnh_bd;

CREATE TABLE tb_rol(
    id_rol VARCHAR(20) PRIMARY KEY NOT NULL, 
    descripcion VARCHAR(30)
);

CREATE TABLE tb_usuario(
    id VARCHAR(30) PRIMARY KEY NOT NULL,
    cedula INT(10),nombres VARCHAR(70),
    email VARCHAR(50), 
    clave VARCHAR(20),
    rol VARCHAR(20), 
    estado BOOL,
    usuario_ingreso VARCHAR(50),
    usuario_modificacion VARCHAR(50),
    fecha_ingreso DATETIME,
    fecha_modificacion DATETIME, 
    descripcion VARCHAR(100),
    CONSTRAINT  fk_id_rol FOREIGN KEY (rol) REFERENCES tb_rol(id_rol)
);

INSERT INTO tb_usuario (id, email, clave)
VALUES('1','rm@gmail.com','1234');
