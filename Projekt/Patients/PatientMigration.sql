BEGIN TRANSACTION;
GO

CREATE TABLE [Appointment] (
    [Id] int NOT NULL IDENTITY,
    [AppointmentDate] datetime2 NOT NULL,
    [Reason] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Appointment] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Patient] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Surname] nvarchar(max) NOT NULL, 
    [PESEL] bigint NOT NULL,
    [PhoneNumber] int NOT NULL,
    [Birthdate] datetime2 NOT NULL,
    CONSTRAINT [PK_Patient] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [PatientAppointment] (
    [AppointmentId] int NOT NULL,
    [PatientId] int NOT NULL,
    CONSTRAINT [PK_PatientAppointment] PRIMARY KEY ([AppointmentId], [PatientId]),
    CONSTRAINT [FK_PatientAppointment_Appointment_AppointmentId] FOREIGN KEY ([AppointmentId]) REFERENCES [Appointment] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PatientAppointment_Patient_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Patient] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_PatientAppointment_PatientId] ON [PatientAppointment] ([PatientId]);
GO


COMMIT;
GO
