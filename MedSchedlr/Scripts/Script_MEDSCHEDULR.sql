CREATE DATABASE MEDSCHEDULR;

USE MEDSCHEDULR;

create table tb_plano(
idPlano int IDENTITY(1,1) primary key,
tipoPlano varchar(255),
acomodacao varchar(255)
);

create table tb_paciente(
codPaciente int IDENTITY(1,1) primary key, 
nome varchar(255),
endereco varchar(255),
idPlano int not null foreign key references tb_plano(idPlano)
);

create table tb_consultorio(
idConsultorio int IDENTITY(1,1) primary key,
endereco varchar(255)
);

create table tb_medico (
idMedico int IDENTITY(1,1) primary key,
especialidade varchar(255),
idConsultorio int not null foreign key references tb_consultorio(idConsultorio),
crm int not null
);