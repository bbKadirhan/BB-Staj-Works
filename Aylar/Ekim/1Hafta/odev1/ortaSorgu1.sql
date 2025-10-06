select KategoriAdi ,count(DersID) as aktifDersSayisi from Dersler
join Kategoriler on Dersler.KategoriID = Kategoriler.KategoriID
where Aktif = '1'
group by Kategoriler.KategoriAdi
