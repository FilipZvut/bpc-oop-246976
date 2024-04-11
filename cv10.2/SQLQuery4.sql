USE [D:\BPC-OOP\BPC-OOP-246976\CV10.2\VYUKA.MDF];
GO

SELECT Student.Jmeno, Student.Prijmeni, Predmet.Nazev
FROM Student
LEFT JOIN Zapsani ON Student.Id = Zapsani.ID_studenta
LEFT JOIN Predmet ON Zapsani.Zkratka_predmetu = Predmet.Zkratka;

SELECT Prijmeni, COUNT(*) AS Pocet_studentu
FROM Student
GROUP BY Prijmeni
ORDER BY Pocet_studentu DESC;

SELECT Predmet.Nazev, COUNT(*) AS Pocet_studentu
FROM Predmet
JOIN Zapsani ON Predmet.Zkratka = Zapsani.Zkratka_predmetu
GROUP BY Predmet.Nazev
HAVING COUNT(*) < 3;

SELECT 
    Predmet.Nazev,
    MIN(Hodnoceni.Hodnoceni) AS Nejlepsi_hodnoceni,
    MAX(Hodnoceni.Hodnoceni) AS Nejhorsi_hodnoceni,
    AVG(Hodnoceni.Hodnoceni) AS Prumerna_hodnoceni,
    COUNT(Hodnoceni.ID_studenta) AS Pocet_hodnocenych_studentu
FROM Predmet
LEFT JOIN Hodnoceni ON Predmet.Zkratka = Hodnoceni.Zkratka_predmetu
GROUP BY Predmet.Nazev;
