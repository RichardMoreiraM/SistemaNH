USE sisnh_bd;

DROP TABLE IF EXISTS tb_usuario, tb_rol;


CREATE TABLE tb_rol(id_rol VARCHAR(20) PRIMARY KEY, descripcion VARCHAR(30));

CREATE TABLE tb_usuario(id VARCHAR(30) PRIMARY KEY,cedula INT(10),nombres VARCHAR(70),
email VARCHAR(50), clave VARCHAR(20),rol VARCHAR(20), estado BOOL,usuario_ingreso VARCHAR(50),
usuario_modificacion VARCHAR(50),fecha_ingreso DATETIME,fecha_modificacion DATETIME, descripcion VARCHAR(100),
CONSTRAINT  fk_id_rol FOREIGN KEY (rol) REFERENCES tb_rol(id_rol));
