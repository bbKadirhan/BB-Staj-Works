select datepart(MONTH, Katilimlar.KatilimTarihi), count(UyeID) as KatilanlarSayisi
from Katilimlar
group by datepart(MONTH, Katilimlar.KatilimTarihi)