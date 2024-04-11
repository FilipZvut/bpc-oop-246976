-- 1. Vytvoření nového databázového souboru SQL serveru Vyuka.mdf.
CREATE DATABASE Vyuka;
GO
USE Vyuka;
GO

-- 2. Navržení schématu databáze
-- Tabulka pro seznam předmětů
CREATE TABLE Predmet (
    Zkratka NVARCHAR(10) PRIMARY KEY,
    Nazev NVARCHAR(50) NOT NULL
);

-- Tabulka pro seznam studentů
CREATE TABLE Student (
    ID_studenta INT PRIMARY KEY,
    Jmeno NVARCHAR(50) NOT NULL,
    Prijmeni NVARCHAR(50) NOT NULL,
    Datum_narozeni DATE NOT NULL
);

-- Spojovací tabulka pro vztah "m:n" mezi studenty a předměty
CREATE TABLE Zapsani (
    ID_studenta INT,
    Zkratka_predmetu NVARCHAR(10),
    FOREIGN KEY (ID_studenta) REFERENCES Student(ID_studenta),
    FOREIGN KEY (Zkratka_predmetu) REFERENCES Predmet(Zkratka),
    PRIMARY KEY (ID_studenta, Zkratka_predmetu)
);

-- 5. Tabulka Hodnocení
CREATE TABLE Hodnoceni (
    ID_studenta INT,
    Zkratka_predmetu NVARCHAR(10),
    Datum_hodnoceni DATE,
    Hodnoceni INT,
    FOREIGN KEY (ID_studenta) REFERENCES Student(ID_studenta),
    FOREIGN KEY (Zkratka_predmetu) REFERENCES Predmet(Zkratka),
    PRIMARY KEY (ID_studenta, Zkratka_predmetu, Datum_hodnoceni)
);

-- 6. Naplnění tabulek vhodnými daty (pro demonstrační účely uvedeme pouze několik záznamů)
-- Naplnění tabulky Predmet
INSERT INTO Predmet (Zkratka, Nazev) VALUES 
('MAT', 'Matematika'),
('ENG', 'Angličtina'),
('PHY', 'Fyzika');

-- Naplnění tabulky Student
INSERT INTO Student (ID_studenta, Jmeno, Prijmeni, Datum_narozeni) VALUES
(1, 'Jan', 'Novák', '2000-05-10'),
(2, 'Petr', 'Svoboda', '1999-09-15'),
(3, 'Marie', 'Nováková', '2001-02-20');

-- Naplnění tabulky Zapsani
INSERT INTO Zapsani (ID_studenta, Zkratka_predmetu) VALUES
(1, 'MAT'),
(1, 'ENG'),
(2, 'MAT'),
(3, 'PHY');

-- Naplnění tabulky Hodnoceni
INSERT INTO Hodnoceni (ID_studenta, Zkratka_predmetu, Datum_hodnoceni, Hodnoceni) VALUES
(1, 'MAT', '2023-05-20', 90),
(1, 'MAT', '2023-06-15', 85),
(2, 'MAT', '2023-06-01', 75),
(2, 'ENG', '2023-05-25', 80),
(3, 'PHY', '2023-06-10', 88);
