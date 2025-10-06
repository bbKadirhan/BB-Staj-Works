select Antrenorler.Ad, Antrenorler.Soyad, count(Dersler.DersID) as dersSayisi,
SUM(Dersler.Kapasite) as ToplamKapasite
from Antrenorler
join dersler on Dersler.AntrenorID = Antrenorler.AntrenorID
group by Antrenorler.Ad, Antrenorler.Soyad 