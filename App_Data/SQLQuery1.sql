-- Tabla PersonalMedico
CREATE TABLE PersonalMedico (
    ID_Medico INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50),
    Apellido NVARCHAR(50),
    Especialidad NVARCHAR(50),
    Usuario NVARCHAR(50),
    Contraseña NVARCHAR(50)
);

-- Tabla Pacientes
CREATE TABLE Pacientes (
    ID_Paciente INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50),
    Apellido NVARCHAR(50),
    Fecha_Nacimiento DATE,
    Datos_Contacto NVARCHAR(100)
);

-- Tabla Expedientes
CREATE TABLE Expedientes (
    ID_Expediente INT IDENTITY(1,1) PRIMARY KEY,
    ID_Paciente INT,
    ID_Medico INT,
    Diagnostico TEXT,
    Tratamiento TEXT,
    Resultados_Pruebas TEXT,
    Fecha_Creacion DATE,
    CONSTRAINT fk_paciente FOREIGN KEY (ID_Paciente) REFERENCES Pacientes(ID_Paciente),
    CONSTRAINT fk_medico FOREIGN KEY (ID_Medico) REFERENCES PersonalMedico(ID_Medico)
);

-- Índices en las columnas de la tabla Expedientes
CREATE INDEX idx_fecha_creacion_expedientes ON Expedientes(Fecha_Creacion);
CREATE INDEX idx_id_paciente_expedientes ON Expedientes(ID_Paciente);
CREATE INDEX idx_id_medico_expedientes ON Expedientes(ID_Medico);

-- Inserción de datos en la tabla PersonalMedico
INSERT INTO PersonalMedico (Nombre, Apellido, Especialidad, Usuario, Contraseña)
VALUES 
    ('Juan', 'Pérez', 'Cardiología', 'juan.perez', 'password1'),
    ('María', 'González', 'Pediatría', 'maria.gonzalez', 'password2'),
    ('Carlos', 'Martínez', 'Oncología', 'carlos.martinez', 'password3'),
    ('Ana', 'López', 'Ginecología', 'ana.lopez', 'password4'),
    ('David', 'Ruiz', 'Neurología', 'david.ruiz', 'password5');

-- Inserción de datos en la tabla Pacientes
INSERT INTO Pacientes (Nombre, Apellido, Fecha_Nacimiento, Datos_Contacto)
VALUES 
    ('Pedro', 'Sánchez', '1990-05-15', 'pedro@example.com, 1234567890'),
    ('Sofía', 'Fernández', '1985-09-20', 'sofia@example.com, 9876543210'),
    ('Luis', 'Gómez', '1978-03-10', 'luis@example.com, 4567890123'),
    ('Laura', 'Díaz', '2000-12-30', 'laura@example.com, 7890123456'),
    ('Elena', 'Torres', '1995-07-08', 'elena@example.com, 2345678901');

-- Inserción de datos en la tabla Expedientes
INSERT INTO Expedientes (ID_Paciente, ID_Medico, Diagnostico, Tratamiento, Resultados_Pruebas, Fecha_Creacion)
VALUES 
    (1, 1, 'Hipertensión arterial', 'Medicación y dieta', 'Presión arterial elevada', '2024-04-01'),
    (2, 2, 'Gripe común', 'Reposo y medicación', 'Prueba de PCR positiva', '2024-04-02'),
    (3, 3, 'Cáncer de pulmón', 'Quimioterapia y radioterapia', 'Biopsia positiva', '2024-04-03'),
    (4, 4, 'Embarazo normal', 'Seguimiento prenatal', 'Ecografía normal', '2024-04-04'),
    (5, 5, 'Migraña crónica', 'Medicación y terapia', 'Resonancia magnética normal', '2024-04-05');

-- Procedimientos almacenados

-- Procedimiento para insertar un nuevo médico
CREATE PROCEDURE InsertarMedico
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Especialidad NVARCHAR(50),
    @Usuario NVARCHAR(50),
    @Contraseña NVARCHAR(50)
AS
BEGIN
    INSERT INTO PersonalMedico (Nombre, Apellido, Especialidad, Usuario, Contraseña)
    VALUES (@Nombre, @Apellido, @Especialidad, @Usuario, @Contraseña);
END;

-- Procedimiento para actualizar la información de un médico
CREATE PROCEDURE ActualizarMedico
    @ID_Medico INT,
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Especialidad NVARCHAR(50),
    @Usuario NVARCHAR(50),
    @Contraseña NVARCHAR(50)
AS
BEGIN
    UPDATE PersonalMedico
    SET Nombre = @Nombre,
        Apellido = @Apellido,
        Especialidad = @Especialidad,
        Usuario = @Usuario,
        Contraseña = @Contraseña
    WHERE ID_Medico = @ID_Medico;
END;

-- Procedimiento para eliminar un médico
CREATE PROCEDURE EliminarMedico
    @ID_Medico INT
AS
BEGIN
    DELETE FROM PersonalMedico WHERE ID_Medico = @ID_Medico;
END;

-- Procedimiento para insertar un nuevo paciente
CREATE PROCEDURE InsertarPaciente
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Fecha_Nacimiento DATE,
    @Datos_Contacto NVARCHAR(100)
AS
BEGIN
    INSERT INTO Pacientes (Nombre, Apellido, Fecha_Nacimiento, Datos_Contacto)
    VALUES (@Nombre, @Apellido, @Fecha_Nacimiento, @Datos_Contacto);
END;

-- Procedimiento para actualizar la información de un paciente
CREATE PROCEDURE ActualizarPaciente
    @ID_Paciente INT,
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Fecha_Nacimiento DATE,
    @Datos_Contacto NVARCHAR(100)
AS
BEGIN
    UPDATE Pacientes
    SET Nombre = @Nombre,
        Apellido = @Apellido,
        Fecha_Nacimiento = @Fecha_Nacimiento,
        Datos_Contacto = @Datos_Contacto
    WHERE ID_Paciente = @ID_Paciente;
END;

-- Procedimiento para eliminar un paciente
CREATE PROCEDURE EliminarPaciente
    @ID_Paciente INT
AS
BEGIN
    DELETE FROM Pacientes WHERE ID_Paciente = @ID_Paciente;
END;

-- Procedimiento para insertar un nuevo expediente
CREATE PROCEDURE InsertarExpediente
    @ID_Paciente INT,
    @ID_Medico INT,
    @Diagnostico TEXT,
    @Tratamiento TEXT,
    @Resultados_Pruebas TEXT,
    @Fecha_Creacion DATE
AS
BEGIN
    INSERT INTO Expedientes (ID_Paciente, ID_Medico, Diagnostico, Tratamiento, Resultados_Pruebas, Fecha_Creacion)
    VALUES (@ID_Paciente, @ID_Medico, @Diagnostico, @Tratamiento, @Resultados_Pruebas, @Fecha_Creacion);
END;

-- Procedimiento para obtener todos los expedientes de un paciente
CREATE PROCEDURE ObtenerExpedientesPorPaciente
    @ID_Paciente INT
AS
BEGIN
    SELECT * FROM Expedientes WHERE ID_Paciente = @ID_Paciente;
END;

-- Procedimiento para obtener todos los expedientes de un médico
CREATE PROCEDURE ObtenerExpedientesPorMedico
    @ID_Medico INT
AS
BEGIN
    SELECT * FROM Expedientes WHERE ID_Medico = @ID_Medico;
END;

-- Procedimiento para eliminar un expediente
CREATE PROCEDURE EliminarExpediente
    @ID_Expediente INT
AS
BEGIN
    DELETE FROM Expedientes WHERE ID_Expediente = @ID_Expediente;
END;

Select * from PersonalMedico
Select * from Expedientes
Select * from Pacientes 
