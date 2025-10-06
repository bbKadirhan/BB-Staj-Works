SELECT top (1) with ties Dersler.DersAdi, count(*) as KatilimSayisi
FROM Katilimlar
INNER JOIN Uyeler ON Katilimlar.UyeID=Uyeler.UyeID
inner join Dersler on Katilimlar.DersID=Dersler.DersID
where Uyeler.Yas < 25
group by Dersler.DersAdi
order by KatilimSayisi DESC
