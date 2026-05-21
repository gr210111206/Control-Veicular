CREATE DATABASE IF NOT EXISTS sicv;
USE sicv;

CREATE TABLE IF NOT EXISTS Usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(255) NOT NULL,
    apellidos VARCHAR(255) NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    rol ENUM('chofer', 'coordinador', 'solicitante', 'admin') NOT NULL,
    numero_empleado VARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE IF NOT EXISTS Vehiculos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    numero_unidad VARCHAR(50) UNIQUE NOT NULL,
    marca VARCHAR(100),
    modelo VARCHAR(100),
    anio INT,
    placas VARCHAR(50) UNIQUE NOT NULL,
    kilometraje_actual INT DEFAULT 0,
    estado ENUM('Disponible', 'En uso', 'Mantenimiento') DEFAULT 'Disponible',
    rendimiento_kmL DECIMAL(5,2)
);

CREATE TABLE IF NOT EXISTS Bitacoras (
    id_bitacora INT AUTO_INCREMENT PRIMARY KEY,
    id_vehiculo INT NOT NULL,
    id_usuario INT NOT NULL,
    fecha_salida DATETIME,
    fecha_retorno DATETIME,
    km_inicial INT,
    km_final INT,
    destino VARCHAR(255),
    motivo VARCHAR(255),
    evidencia_url VARCHAR(255),
    FOREIGN KEY (id_vehiculo) REFERENCES Vehiculos(id),
    FOREIGN KEY (id_usuario) REFERENCES Usuarios(id)
);

CREATE TABLE IF NOT EXISTS Mantenimientos (
    id_mantenimiento INT AUTO_INCREMENT PRIMARY KEY,
    id_vehiculo INT NOT NULL,
    tipo_servicio VARCHAR(100),
    km_realizado INT,
    km_proximo_servicio INT,
    estado ENUM('Pendiente', 'Completado') DEFAULT 'Pendiente',
    FOREIGN KEY (id_vehiculo) REFERENCES Vehiculos(id)
);
