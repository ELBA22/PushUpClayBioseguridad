CREATE DATABASE bioseguridad


CREATE TABLE `estado`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Descripcion` VARCHAR(255) NOT NULL
);
CREATE TABLE `turnos`(
    `Id` INT  NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nombreTurno` VARCHAR(255) NOT NULL,
    `horaturnoT` TIME NOT NULL,
    `horaturnoF` TIME NOT NULL
);
CREATE TABLE `tipoContacto`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `descripcion` VARCHAR(255) NOT NULL
);
CREATE TABLE `pais`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nombrePais` VARCHAR(255) NOT NULL
);
CREATE TABLE `categoriaPersona`(
    `Id` INT  NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nombreCategoria` VARCHAR(255) NOT NULL
);
CREATE TABLE `tipoPersona`(
    `Id` INT  NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `descripcion` VARCHAR(255) NOT NULL
);
CREATE TABLE `tipodireccion`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `descripcion` VARCHAR(255) NOT NULL
);
CREATE TABLE `departamento`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nombreDep` VARCHAR(255) NOT NULL,
    `IdPais` INT NOT NULL,
    CONSTRAINT `departamento_idpais_foreign` FOREIGN KEY(`IdPais`) REFERENCES `pais`(`Id`)
);
CREATE TABLE `ciudad`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nombreCiudad` VARCHAR(255) NOT NULL,
    `IdDepartamento` INT NOT NULL,
    `IdCategoriaPer` INT NOT NULL,
    CONSTRAINT `ciudad_iddepartamento_foreign` FOREIGN KEY(`IdDepartamento`) REFERENCES `departamento`(`Id`),
    CONSTRAINT `persona_idcategoriaper_foreign` FOREIGN KEY(`IdCategoriaPer`) REFERENCES `categoriaPersona`(`Id`)
);

CREATE TABLE `persona`(
    `Id` INT  NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `IdPersona` INT NOT NULL,
    `nombre` VARCHAR(255) NOT NULL,
    `dateReg` INT NOT NULL,
    `IdTipoPersona` INT NOT NULL,
    `IdCategoriaPer` INT NOT NULL,
    `IdCiudad` INT NOT NULL,
    CONSTRAINT `persona_idtipopersona_foreign` FOREIGN KEY(`IdTipoPersona`) REFERENCES `tipoPersona`(`Id`),
    CONSTRAINT `persona_idciudad_foreign` FOREIGN KEY(`IdCiudad`) REFERENCES `ciudad`(`Id`)
);
ALTER TABLE
    `persona` ADD UNIQUE `persona_idpersona_unique`(`IdPersona`);

CREATE TABLE `contactoPersona`(
    `Id` INT  NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `descripcion` VARCHAR(255) NOT NULL,
    `IdPersona` INT NOT NULL,
    `IdTipoContacto` INT NOT NULL,
    CONSTRAINT `contactopersona_idpersona_foreign` FOREIGN KEY(`IdPersona`) REFERENCES `persona`(`Id`),
    CONSTRAINT `contactopersona_idtipocontacto_foreign` FOREIGN KEY(`IdTipoContacto`) REFERENCES `tipoContacto`(`Id`)
);
ALTER TABLE
    `contactoPersona` ADD UNIQUE `contactopersona_descripcion_unique`(`descripcion`);
CREATE TABLE `direccionPersona`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `direccion` VARCHAR(255) NOT NULL,
    `IdPersona` INT NOT NULL,
    `IdTipoDireccion` INT NOT NULL,
    CONSTRAINT `direccionpersona_idtipodireccion_foreign` FOREIGN KEY(`IdTipoDireccion`) REFERENCES `tipodireccion`(`Id`),
    CONSTRAINT `direccionpersona_idpersona_foreign` FOREIGN KEY(`IdPersona`) REFERENCES `persona`(`Id`)
);
CREATE TABLE `contrato`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `IdCliente` INT NOT NULL,
    `fechaContrato` DATE NOT NULL,
    `IdEmpleado` INT NOT NULL,
    `fechafin` DATE NOT NULL,
    `IdEstado` INT NOT NULL,
    CONSTRAINT `contrato_idempleado_foreign` FOREIGN KEY(`IdEmpleado`) REFERENCES `persona`(`Id`),
    CONSTRAINT `contrato_idestado_foreign` FOREIGN KEY(`IdEstado`) REFERENCES `estado`(`Id`),
    CONSTRAINT `contrato_idcliente_foreign` FOREIGN KEY(`IdCliente`) REFERENCES `persona`(`Id`)
);

CREATE TABLE `programacion`(
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `IdContrato` INT NOT NULL,
    `IdTurno` INT NOT NULL,
    `IdEmpleado` INT NOT NULL,
    CONSTRAINT `programacion_idturno_foreign` FOREIGN KEY(`IdTurno`) REFERENCES `turnos`(`Id`),
    CONSTRAINT `programacion_idcontrato_foreign` FOREIGN KEY(`IdContrato`) REFERENCES `contrato`(`Id`),
    CONSTRAINT `programacion_idempleado_foreign` FOREIGN KEY(`IdEmpleado`) REFERENCES `persona`(`Id`)
);


















