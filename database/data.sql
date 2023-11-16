CREATE DATABASE systemcom;
CREATE table person(
    idPerson int IDENTITY(1,1) primary key,
    nomPerson   varchar(25),
    ages        int
);

CREATE TABLE PRODUIT(
    idProduit   int IDENTITY(1,1) primary key,
    nomProduit  varchar(25)
);

CREATE TABLE DEPARTEMENT(
    idDepartement   int IDENTITY(1,1) primary key,
    nomDepartement  varchar(30)
);

CREATE or replace TABLE UNITE(
    idUnite     serial primary key,
    nomUnite    VARCHAR(30)
); 

CREATE table demande(
    idDemande   int IDENTITY primary key,
    idProduit   int references produit (idProduit),
    quantite    double precision,
    unite       int references unite (idunite),
    idDepartement   int references DEPARTEMENT (idDepartement),
    dateDemande     datetime,
    etat        int

);

-- View ---
CREATE or Replace view besoin as
select d.idDemande,p.nomProduit,d.quantite,u.nomunite,d.iddepartement,de.nomdepartement,d.dateDemande,d.etat 
	from demande d 
	join departement de on d.idDepartement = de.idDepartement
	join produit p on d.idproduit = p.idProduit
	join unite u  on u.idunite = d.unite;

-- Donnees ---
-- Insertion de données dans la table PRODUIT
INSERT INTO PRODUIT (nomProduit) VALUES
('Ordinateur portable'),
('Imprimante'),
('Stylo');

-- Insertion de données dans la table DEPARTEMENT
INSERT INTO DEPARTEMENT (nomDepartement) VALUES
('Ressources humaines'),
('Informatique'),
('Logistique');

-- Insertion de données dans la table UNITE
INSERT INTO UNITE (nomUnite) VALUES
('Pièce'),
('Boîte'),
('Ensemble');

-- Insertion de données dans la table DEMANDE
INSERT INTO DEMANDE (idProduit, quantite, unite, idDepartement, dateDemande, etat) VALUES
(1, 10, 1, 2, '2023-16-11 10:00:00', 0),
(2, 5, 2, 1, '2023-16-11 11:30:00', 0),
(3, 50, 3, 3, '2023-16-11 13:45:00', 0);
