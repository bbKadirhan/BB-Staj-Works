---

# 🚀 WordPress Backup Tool (CLI & Daemon)

Windows sunucularda birden fazla WordPress sitesini otomatik olarak yedeklemek için geliştirilmiş bir komut satırı aracıdır.

---

## 🛠 Yapılandırma (`config.json`)

Tüm ayarlar `config.json` dosyası üzerinden yönetilir. `sites` kısmına yeni süslü parantez `{}` blokları ekleyerek sınırsız sayıda site tanımlayabilirsiniz.

### 1. Genel Ayarlar (General)

* **`mysqldumpPath`**: `mysqldump.exe` dosyasının tam yolunu belirtin.
* *Örnek:* `C:\\xampp\\mysql\\bin\\mysqldump.exe`


* **`backupRootPath`**: Yedeklerin depolanacağı ana klasör yoludur.
* **`backupTime`**: Yedeklemenin her gün saat kaçta yapılacağını belirler (Örn: `02:30`).

### 2. Site Bazlı Ayarlar (Sites)

| Parametre | Açıklama |
| --- | --- |
| **`siteName`** | Sitenin adı. Yedek klasörü bu isimle oluşturulur. |
| **`rootPath`** | WordPress dosyalarının (wp-config.php'nin olduğu yer) bulunduğu klasör yolu. |
| **`keepLast`** | **Yedek Sınırı:** Klasörde en fazla kaç adet yedek tutulacağını belirler. Sınır aşılırsa en eski yedek silinir. |
| **`enabled`** | **Hızlı Kapatma:** `false` yapılırsa, config dosyasından silmeden o sitenin yedeği atlanır. |

> **Database Bilgileri:** Veritabanı adı, kullanıcı adı ve şifre bilgilerini sitenizin içindeki `wp-config.php` dosyasından bulabilirsiniz.

---

## 📂 Dosya Yapısı

Yedekler alındığında, uygulama otomatik olarak tarihsel bir klasör yapısı oluşturur:

```text
C:\BackupVault\
└── iklimsite\
    └── 2026-02-24_023000\
        ├── iklimsite_2026-02-24_023000_files.zip  <-- Site dosyaları
        └── iklimsite_2026-02-24_023000_db.sql     <-- Veritabanı yedeği

```

---

## 💻 Kullanım Komutları

Uygulamayı terminal (CMD/PowerShell) üzerinden iki farklı modda çalıştırabilirsiniz:

### **Daemon Modu (Sürekli Çalışma)**

Bu modda program kapanmaz, arka planda bekler ve her gün belirlenen saatte yedek alır.

```bash
backup.exe daemon

```

### **Run Modu (Anlık Yedek)**

Zamanı beklemeden, listedeki tüm aktif sitelerin yedeğini hemen almak için kullanılır.

```bash
backup.exe run

```

---