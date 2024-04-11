-- 7. Vytvoření skriptu pro SELECT dotazy
USE Vyuka1;
GO
-- 8. Dotaz, kde vypíšete všechny studenty a předměty, které mají zapsané. Použijte LEFT JOIN.
SELECT Student.Jmeno, Student.Prijmeni, Predmet.Nazev
FROM Student
LEFT JOIN Zapsani ON Student.ID_studenta = Zapsani.ID_studenta
LEFT JOIN Predmet ON Zapsani.Zkratka_predmetu = Predmet.Zkratka;

-- 9. Dotaz, kde vypíšete příjmení studentů a počet studentů, kteří mají stejné příjmení. Seřaďte je sestupně dle četnosti příjmení. Použijte GROUP BY.
SELECT Prijmeni, COUNT(*) AS Pocet_studentu
FROM Student
GROUP BY Prijmeni
ORDER BY Pocet_studentu DESC;

-- 10. Dotaz, kde vypíšete předměty, ve kterých je zapsáno méně než 3 studenti.
SELECT Predmet.Nazev, COUNT(*) AS Pocet_studentu
FROM Predmet
JOIN Zapsani ON Predmet.Zkratka = Zapsani.Zkratka_predmetu
GROUP BY Predmet.Nazev
HAVING COUNT(*) < 3;

-- 11. Dotaz, kde vypíšete všechny předměty a nejlepší, nejhorší a průměrné hodnocení v předmětu. Dále pak počet hodnocených studentů v předmětu. Použijte GROUP BY.
SELECT 
    Predmet.Nazev,
    MAX(Hodnoceni.Hodnoceni) AS Nejlepsi_hodnoceni,
    MIN(Hodnoceni.Hodnoceni) AS Nejhorsi_hodnoceni,
    AVG(Hodnoceni.Hodnoceni) AS Prumerna_hodnoceni,
    COUNT(Hodnoceni.ID_studenta) AS Pocet_hodnocenych_studentu
FROM Predmet
LEFT JOIN Hodnoceni ON Predmet.Zkratka = Hodnoceni.Zkratka_predmetu
GROUP BY Predmet.Nazev;
