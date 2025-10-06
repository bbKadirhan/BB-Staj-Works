SELECT Uyeler.Ad, Uyeler.Soyad, Dersler.DersAdi, Katilimlar.KatilimTarihi FROM Uyeler
JOIN Katilimlar ON Katilimlar.UyeID = Uyeler.UyeID
JOIN Dersler ON Katilimlar.DersID = Dersler.DersID 
WHERE YEAR(Katilimlar.KatilimTarihi) = 2024;