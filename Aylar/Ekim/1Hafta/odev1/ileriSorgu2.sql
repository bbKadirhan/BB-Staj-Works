select top(5) Dersler.DersAdi, count(Katilimlar.KatilimID) as KatilimSayisi from katilimlar
join Dersler on Dersler.DersID = Katilimlar.DersID
group by Dersler.DersAdi
order by KatilimSayisi desc
