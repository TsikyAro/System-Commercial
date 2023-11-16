CREATE DATABASE systemcom;
CREATE table person(
    idPerson int IDENTITY(1,1) primary key,
    nomPerson   varchar(25),
    ages        int
);