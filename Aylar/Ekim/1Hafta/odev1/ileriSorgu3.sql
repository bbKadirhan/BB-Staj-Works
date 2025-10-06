select Dersler.DersID ,Dersler.DersAdi from katilimlar
join Dersler on Dersler.DersID = Katilimlar.DersID
group by Dersler.DersAdi, Dersler.DersID
having count(Dersler.DersAdi) = 1 and SUM(CASE WHEN Katilimlar.durum NOT IN ('iptal', 'katýlmadý') THEN 1 ELSE 0 END) = 0;

