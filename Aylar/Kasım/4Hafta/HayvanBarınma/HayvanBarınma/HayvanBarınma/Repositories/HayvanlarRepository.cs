using HayvanBarınma.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data;
using Microsoft.VisualBasic.ApplicationServices;
namespace HayvanBarınma.Repositories
{
    public class HayvanlarRepository
    {
        
        private readonly string connectionString = "Data Source=MBB-01-BIL065-N\\SQLEXPRESS;Initial Catalog=hayvanDB;Integrated Security=True;Trust Server Certificate=True";
       
        public Admin GetAdminByCredentials(string username, string password)
        {
            Admin admin = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT id, Username, Password, Role FROM Users WHERE Username = @Username AND Password = @Password AND isDeleted = 0";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                admin = new Admin
                                {
                                    Id = reader.GetInt32(0),
                                    Username = reader.GetString(1),
                                    Password = reader.GetString(2),
                                    Role = reader.GetString(3)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sql Veri öekmede hata oluştu: " + ex.Message);
            }

            return admin;
        }

        public List<Admin> GetAllUsers()
        {
            List<Admin> users = new List<Admin>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT id, Username, Password, Role, isDeleted FROM Users";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) 
                            {
                                Admin user = new Admin
                                {
                                    Id = reader.GetInt32(0),
                                    Username = reader.GetString(1),
                                    Password = reader.GetString(2),
                                    Role = reader.GetString(3),
                                    isDeleted = reader.GetBoolean(4)
                                };
                                users.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Kullanıcı verileri çekilirken hata oluştu: " + ex.Message);
            }

            return users;
        }

        public void AddNewUser(Admin a)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO Users (Username, Password, Role, isDeleted) " +
                                 "VALUES (@Username, @Password, @Role, @isDeleted);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Username", a.Username);
                        command.Parameters.AddWithValue("@Password", a.Password);
                        command.Parameters.AddWithValue("@Role", a.Role);
                        command.Parameters.AddWithValue("@isDeleted", a.isDeleted);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User added successfully!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Kullanıcı eklenirken hata oluştu: " + ex.Message);
            }
        }

        public void EditUser(Admin a)
        {
           
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "UPDATE Users SET " +
                          "Username = @Username, " +
                          "Password = @Password, " +
                          "Role = @Role, " +
                          "isDeleted = @isDeleted " +
                          "WHERE id = @id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Username", a.Username);
                        command.Parameters.AddWithValue("@Password", a.Password);
                        command.Parameters.AddWithValue("@Role", a.Role);
                        command.Parameters.AddWithValue("@isDeleted", a.isDeleted);
                        command.Parameters.AddWithValue("@id", a.Id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Kullanıcı eklenirken hata oluştu: " + ex.Message);
            }

        }

        


        //Veteriner bölümü
        public List<Vet> GetAllVets()
        {
            List<Vet> vets = new List<Vet>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT id, AdSoyad, Alan, Telno, Kurum FROM Vets";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Vet vet = new Vet
                                {
                                    Id = reader.GetInt32(0),
                                    AdSoyad = reader.GetString(1),
                                    Alan = reader.GetString(2),
                                    Telno = reader.GetString(3),
                                    Kurum = reader.GetString(4)
                                };
                                vets.Add(vet);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Veteriner verileri çekilirken hata oluştu: " + ex.Message);
            }

            return vets;
        }

        public void AddNewVet(Vet v)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO Vets (AdSoyad, Alan, Telno, Kurum) " +
                                 "VALUES (@AdSoyad, @Alan, @Telno, @Kurum);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@AdSoyad", v.AdSoyad);
                        command.Parameters.AddWithValue("@Alan", v.Alan);
                        command.Parameters.AddWithValue("@Telno", v.Telno);
                        command.Parameters.AddWithValue("@Kurum", v.Kurum);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Vet added successfully!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Veteriner eklenirken hata oluştu: " + ex.Message);
            }
        }

        public void EditVet(Vet v)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "UPDATE Vets SET " +
                                 "AdSoyad = @AdSoyad, " +
                                 "Alan = @Alan, " +
                                 "Telno = @Telno, " +
                                 "Kurum = @Kurum " +
                                 "WHERE id = @id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@AdSoyad", v.AdSoyad);
                        command.Parameters.AddWithValue("@Alan", v.Alan);
                        command.Parameters.AddWithValue("@Telno", v.Telno);
                        command.Parameters.AddWithValue("@Kurum", v.Kurum);
                        command.Parameters.AddWithValue("@id", v.Id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Veteriner düzenlenirken hata oluştu: " + ex.Message);
            }
        }

        //Hayvanlar bölümü

        public List<Pet> GetAllPets()
        {
            List<Pet> pets = new List<Pet>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT PetID, Name, Tur, Irk, Cinsiyet,TahminiYas, Gelis, Durum, Padok FROM Pets";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Pet pet = new Pet
                                {
                                    PetID = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Tur = reader.GetString(2),
                                    Irk = reader.GetString(3),
                                    Cinsiyet = reader.GetString(4),
                                    TahminiYas = reader.GetInt32(5),
                                    Gelis = reader.GetDateTime(6),
                                    Durum = reader.GetString(7),
                                    Padok = reader.GetString(8)
                                };
                                pets.Add(pet);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hayvanlar verileri çekilirken hata oluştu: " + ex.Message);
            }

            return pets;
        }



        public void EditPet(Pet p)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "UPDATE Pets SET " +
                                 "Name = @Name, " +
                                 "Tur = @Tur, " +
                                 "Irk = @Irk, " +
                                 "Cinsiyet = @Cinsiyet, " +
                                 "TahminiYas = @TahminiYas, " +
                                 "Durum = @Durum," +
                                 "Padok = @Padok " +
                                 "WHERE PetID = @PetID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@PetID", p.PetID);
                        command.Parameters.AddWithValue("@Name", p.Name);
                        command.Parameters.AddWithValue("@Tur", p.Tur);
                        command.Parameters.AddWithValue("@Irk", p.Irk);
                        command.Parameters.AddWithValue("@Cinsiyet", p.Cinsiyet);
                        command.Parameters.AddWithValue("@TahminiYas", p.TahminiYas);
                        command.Parameters.AddWithValue("@Durum", p.Durum);
                        command.Parameters.AddWithValue("@Padok", p.Padok);


                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hayvanlar düzenlenirken hata oluştu: " + ex.Message);
            }
        }


        public void AddNewPet(Pet p)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO Pets (Name, Tur, Irk, Cinsiyet, Gelis, TahminiYas, Durum, Padok) " +
                                 "VALUES (@Name, @Tur, @Irk, @Cinsiyet, @Gelis, @TahminiYas, @Durum, @Padok);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@PetID", p.PetID);
                        command.Parameters.AddWithValue("@Name", p.Name);
                        command.Parameters.AddWithValue("@Tur", p.Tur);
                        command.Parameters.AddWithValue("@Irk", p.Irk);
                        command.Parameters.AddWithValue("@Cinsiyet", p.Cinsiyet);
                        command.Parameters.AddWithValue("@TahminiYas", p.TahminiYas);
                        command.Parameters.AddWithValue("@Durum", p.Durum);
                        command.Parameters.AddWithValue("@Padok", p.Padok);
                        command.Parameters.AddWithValue("@Gelis", p.Gelis);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Hayvan başarılıyla eklendi!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hayvan eklenirken hata oluştu: " + ex.Message);
            }
        }


        public List<Pet> FilteredPetSearch(string nameFilter, string CinsiyetFilter, string DurumFilter)
        {
            List<Pet> pets = new List<Pet>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT PetID, Name, Tur, Irk, Cinsiyet, TahminiYas, Gelis, Durum, Padok FROM Pets";
                            
                    string whereClause = " WHERE 1 = 1 ";
                    
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        if (!string.IsNullOrEmpty(nameFilter))
                        {
                            whereClause += "AND Name LIKE @NameFilter ";
                            command.Parameters.AddWithValue("@NameFilter", "%" + nameFilter + "%"); 
                        }

                        if(!string.IsNullOrEmpty(CinsiyetFilter))
                        {
                            whereClause += "AND Cinsiyet = @CinsiyetFilter ";
                            command.Parameters.AddWithValue("@CinsiyetFilter", CinsiyetFilter);
                        }

                        if (!string.IsNullOrEmpty(DurumFilter))
                        {
                            whereClause += "AND Durum = @DurumFilter ";
                            command.Parameters.AddWithValue("@DurumFilter", DurumFilter);
                        }

                        command.CommandText = sql + whereClause;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Pet pet = new Pet
                                {
                                    PetID = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Tur = reader.GetString(2),
                                    Irk = reader.GetString(3),
                                    Cinsiyet = reader.GetString(4),
                                    TahminiYas = reader.GetInt32(5),
                                    Gelis = reader.GetDateTime(6),
                                    Durum = reader.GetString(7),
                                    Padok = reader.GetString(8)
                                };
                                pets.Add(pet);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hayvanlar verilerini filtrelerken hata oluştu: " + ex.Message);
                // log ekleme yapılabilir
            }

            return pets;
        }


        //randevular


        public List<Randevu> GetAllRandevus()
        {
            List<Randevu> randevus = new List<Randevu>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    string sql = @"SELECT R.id, R.Tarih, H.Name AS Hayvan, V.AdSoyad AS Veteriner, R.Konu,  R.Durum 
                                   FROM  Randevu R
                                   INNER JOIN Pets H ON R.HayvanID = H.PetID
                                   INNER JOIN Vets V ON R.VetID = V.id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Randevu randevu = new Randevu
                                {
                                    id = reader.GetInt32(0),
                                    Tarih = reader.GetDateTime(1),
                                    Hayvan = reader.GetString(2),
                                    Veteriner = reader.GetString(3),
                                    Konu = reader.GetString(4),
                                    Durum = reader.GetString(5),
                                };
                                randevus.Add(randevu);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hayvanlar verileri çekilirken hata oluştu: " + ex.Message);
            }

            return randevus;
        }

        public void AddRandevu(Randevu p)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    int hayvanID = -1;
                    string getHayvanIdSql = "SELECT PetID FROM Pets WHERE Name = @PetName;";
                    using (SqlCommand getHayvanIdCommand = new SqlCommand(getHayvanIdSql, connection))
                    {
                        getHayvanIdCommand.Parameters.AddWithValue("@PetName", p.Hayvan);
                        object hayvanResult = getHayvanIdCommand.ExecuteScalar();

                        if (hayvanResult != null && hayvanResult != DBNull.Value)
                        {
                            hayvanID = (int)hayvanResult;
                        }
                    }

                    int vetID = -1;
                    string getVetIdSql = "SELECT id FROM Vets WHERE AdSoyad = @VetName;";
                    using (SqlCommand getVetIdCommand = new SqlCommand(getVetIdSql, connection))
                    {
                        getVetIdCommand.Parameters.AddWithValue("@VetName", p.Veteriner);
                        object vetResult = getVetIdCommand.ExecuteScalar();

                        if (vetResult != null && vetResult != DBNull.Value)
                        {
                            vetID = (int)vetResult;
                        }
                    }

                    // Check if IDs were found
                    if (hayvanID == -1)
                    {
                        MessageBox.Show("Hata: Hayvan adı '" + p.Hayvan + "' bulunamadı. Randevu güncellenemiyor.");
                        return;
                    }
                    if (vetID == -1)
                    {
                        MessageBox.Show("Hata: Veteriner adı '" + p.Veteriner + "' bulunamadı. Randevu güncellenemiyor.");
                        return;
                    }

                    // Execute the UPDATE query

                    string sql = "INSERT INTO Randevu (Tarih, HayvanID, VetID, Konu, Durum) " +
                                "VALUES (@Tarih, @HayvanID, @VetID, @Konu, @Durum);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Tarih", p.Tarih);
                        command.Parameters.AddWithValue("@HayvanID", hayvanID);
                        command.Parameters.AddWithValue("@VetID", vetID);
                        command.Parameters.AddWithValue("@Konu", p.Konu);
                        command.Parameters.AddWithValue("@Durum", p.Durum);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Randevu başarıyla güncellendi!");
                        }
                        else
                        {
                            MessageBox.Show("Hata: Randevu bulunamadı veya değişiklik yapılmadı.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Randevu Eklenirken hata oluştu: " + ex.Message);
            }
        }
        public void EditRandevu(Randevu p)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    int hayvanID = -1;
                    string getHayvanIdSql = "SELECT PetID FROM Pets WHERE Name = @PetName;";
                    using (SqlCommand getHayvanIdCommand = new SqlCommand(getHayvanIdSql, connection))
                    {
                        getHayvanIdCommand.Parameters.AddWithValue("@PetName", p.Hayvan);
                        object hayvanResult = getHayvanIdCommand.ExecuteScalar();

                        if (hayvanResult != null && hayvanResult != DBNull.Value)
                        {
                            hayvanID = (int)hayvanResult;
                        }
                    }

                    int vetID = -1;
                    string getVetIdSql = "SELECT id FROM Vets WHERE AdSoyad = @VetName;";
                    using (SqlCommand getVetIdCommand = new SqlCommand(getVetIdSql, connection))
                    {
                        getVetIdCommand.Parameters.AddWithValue("@VetName", p.Veteriner);
                        object vetResult = getVetIdCommand.ExecuteScalar();

                        if (vetResult != null && vetResult != DBNull.Value)
                        {
                            vetID = (int)vetResult;
                        }
                    }

                    // Check if IDs were found
                    if (hayvanID == -1)
                    {
                        MessageBox.Show("Hata: Hayvan adı '" + p.Hayvan + "' bulunamadı. Randevu güncellenemiyor.");
                        return;
                    }
                    if (vetID == -1)
                    {
                        MessageBox.Show("Hata: Veteriner adı '" + p.Veteriner + "' bulunamadı. Randevu güncellenemiyor.");
                        return;
                    }

                    // Execute the UPDATE query
                    string sql = @"
                UPDATE Randevu SET 
                    Tarih = @Tarih, 
                    HayvanID = @HayvanID, 
                    VetID = @VetID, 
                    Konu = @Konu, 
                    Durum = @Durum 
                WHERE id = @RandevuID;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Tarih", p.Tarih);
                        command.Parameters.AddWithValue("@HayvanID", hayvanID);
                        command.Parameters.AddWithValue("@VetID", vetID);
                        command.Parameters.AddWithValue("@Konu", p.Konu);
                        command.Parameters.AddWithValue("@Durum", p.Durum);
                        command.Parameters.AddWithValue("@RandevuID", p.id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Randevu başarıyla güncellendi!");
                        }
                        else
                        {
                            MessageBox.Show("Hata: Randevu bulunamadı veya değişiklik yapılmadı.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Randevu düzenlenirken hata oluştu: " + ex.Message);
            }
        }
        public List<Randevu> FilteredRandevuSearch(string VeterinerFilter, string DurumFilter)
        {
            List<Randevu> randevus = new List<Randevu>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                SELECT 
                    R.id, 
                    R.Tarih, 
                    H.Name AS Hayvan, 
                    V.AdSoyad AS Veteriner, 
                    R.Konu, 
                    R.Durum 
                FROM 
                    Randevu R
                INNER JOIN 
                    Pets H ON R.HayvanID = H.PetID
                INNER JOIN 
                    Vets V ON R.VetID = V.id";

                    string whereClause = " WHERE 1 = 1 ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        if (!string.IsNullOrEmpty(VeterinerFilter))
                        {
                            whereClause += "AND V.AdSoyad LIKE @VetNameFilter ";
                            command.Parameters.AddWithValue("@VetNameFilter", "%" + VeterinerFilter + "%");
                        }

                        if (!string.IsNullOrEmpty(DurumFilter))
                        {
                            whereClause += "AND R.Durum = @DurumFilter ";
                            command.Parameters.AddWithValue("@DurumFilter", DurumFilter);
                        }

                        command.CommandText = sql + whereClause;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Randevu randevu = new Randevu
                                {
                                    id = reader.GetInt32(0),
                                    Tarih = reader.GetDateTime(1),
                                    Hayvan = reader.GetString(2),
                                    Veteriner = reader.GetString(3),
                                    Konu = reader.GetString(4),
                                    Durum = reader.GetString(5),
                                };
                                randevus.Add(randevu);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Randevu verilerini filtrelerken hata oluştu: " + ex.Message);
            }

            return randevus;
        }


        // unique lists for comboboxes
        public List<string> GetUniqueDurumlar()
        {
            List<string> durumlar = new List<string>();

            string sql = "SELECT DISTINCT Durum FROM Randevu WHERE Durum IS NOT NULL AND Durum <> ''";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                durumlar.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Durum verileri çekilirken hata oluştu: " + ex.Message);
            }

            return durumlar;
        }

        public List<string> GetUniqueVeterinerAdlari()
        {
            List<string> adlar = new List<string>();

            string sql = "SELECT DISTINCT AdSoyad FROM Vets WHERE AdSoyad IS NOT NULL AND AdSoyad <> '' ORDER BY AdSoyad";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                adlar.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veteriner adları çekilirken hata oluştu: " + ex.Message);
            }

            return adlar;
        }

        public List<string> GetUniqueIsTuru()
        {
            List<string> isturleri = new List<string>();

            string sql = "SELECT DISTINCT IslemTuru FROM Islemler WHERE IslemTuru IS NOT NULL AND IslemTuru <> ''";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                isturleri.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("IslemTuru verileri çekilirken hata oluştu: " + ex.Message);
            }

            return isturleri;
        }

        public List<string> GetUniquePets()
        {
            List<string> HayvanIsimleri = new List<string>();

            string sql = "SELECT DISTINCT Name FROM Pets WHERE Name IS NOT NULL AND Name <> ''";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                HayvanIsimleri.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hayvan ismi verileri çekilirken hata oluştu: " + ex.Message);
            }

            return HayvanIsimleri;
        }


        //işlemler

        public List<Islem> GetAllislemler()
        {
            List<Islem> islemler = new List<Islem>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    string sql = @"SELECT R.id, R.Tarih, H.Name AS Hayvan, R.IslemTuru, V.AdSoyad AS Veteriner, R.açıklama 
                                   From Islemler R
                                   INNER JOIN Pets H ON R.PetID = H.PetID
                                   INNER JOIN Vets V ON R.VetID = V.id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Islem islem = new Islem
                                {
                                    id = reader.GetInt32(0),
                                    Tarih = reader.GetDateTime(1),
                                    Hayvan = reader.GetString(2),
                                    IslemTuru = reader.GetString(3),
                                    Veteriner = reader.GetString(4),
                                    Açıklama = reader.GetString(5),
                                };
                                islemler.Add(islem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hayvanlar verileri çekilirken hata oluştu: " + ex.Message);
            }

            return islemler;
        }
        public void AddNewIslem(Islem v)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    int petID = -1;
                    string getPetIdSql = "SELECT PetID FROM Pets WHERE Name = @PetName;";
                    using (SqlCommand getPetIdCommand = new SqlCommand(getPetIdSql, connection))
                    {
                        getPetIdCommand.Parameters.AddWithValue("@PetName", v.Hayvan);
                        object petResult = getPetIdCommand.ExecuteScalar();

                        if (petResult != null)
                        {
                            petID = (int)petResult;
                        }
                    }


                    int vetID = -1;

                    string getVetIdSql = "SELECT id FROM Vets WHERE AdSoyad = @VetName;";
                    using (SqlCommand getVetIdCommand = new SqlCommand(getVetIdSql, connection))
                    {
                        getVetIdCommand.Parameters.AddWithValue("@VetName", v.Veteriner);
                        object vetResult = getVetIdCommand.ExecuteScalar();

                        if (vetResult != null)
                        {
                            vetID = (int)vetResult;
                        }
                    }


                    if (petID == -1)
                    {
                        MessageBox.Show("Error: Pet with name '" + v.Hayvan + "' not found.");
                        return;
                    }
                    if (vetID == -1)
                    {
                        MessageBox.Show("Error: Veterinarian with name '" + v.Veteriner + "' not found.");
                        return;
                    }

                    string sql = "INSERT INTO Islemler (Tarih, PetID, IslemTuru, VetId, Açıklama) " +
                                 "VALUES (@Tarih, @PetID, @IslemTuru, @VetID, @Açıklama );";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Tarih", v.Tarih);
                        command.Parameters.AddWithValue("@PetID", petID);
                        command.Parameters.AddWithValue("@IslemTuru", v.IslemTuru);
                        command.Parameters.AddWithValue("@VetId", vetID);
                        command.Parameters.AddWithValue("@Açıklama", v.Açıklama);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Operation added successfully!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlem eklenirken hata oluştu: " + ex.Message);
            }
        }

        public void EditIslem(Islem v)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    int petID = -1;
                    string getPetIdSql = "SELECT PetID FROM Pets WHERE Name = @PetName;";
                    using (SqlCommand getPetIdCommand = new SqlCommand(getPetIdSql, connection))
                    {
                        getPetIdCommand.Parameters.AddWithValue("@PetName", v.Hayvan);
                        object petResult = getPetIdCommand.ExecuteScalar();

                        if (petResult != null)
                        {
                            petID = (int)petResult;
                        }
                    }

                    int vetID = -1;
                    string getVetIdSql = "SELECT id FROM Vets WHERE AdSoyad = @VetName;";
                    using (SqlCommand getVetIdCommand = new SqlCommand(getVetIdSql, connection))
                    {
                        getVetIdCommand.Parameters.AddWithValue("@VetName", v.Veteriner);
                        object vetResult = getVetIdCommand.ExecuteScalar();

                        if (vetResult != null)
                        {
                            vetID = (int)vetResult;
                        }
                    }

                    if (petID == -1)
                    {
                        MessageBox.Show("Error: Pet with name '" + v.Hayvan + "' not found. Cannot update.");
                        return;
                    }
                    if (vetID == -1)
                    {
                        MessageBox.Show("Error: Veterinarian with name '" + v.Veteriner + "' not found. Cannot update.");
                        return;
                    }
                    if (v.id <= 0)
                    {
                        MessageBox.Show("Error: Islem ID is missing or invalid. Cannot update.");
                        return;
                    }

                    string sql = @"
                UPDATE Islemler SET 
                    Tarih = @Tarih, 
                    PetID = @PetID, 
                    IslemTuru = @IslemTuru, 
                    VetId = @VetId, 
                    Açıklama = @Açıklama 
                WHERE id = @IslemID;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Tarih", v.Tarih);
                        command.Parameters.AddWithValue("@PetID", petID);
                        command.Parameters.AddWithValue("@IslemTuru", v.IslemTuru);
                        command.Parameters.AddWithValue("@VetId", vetID);
                        command.Parameters.AddWithValue("@Açıklama", v.Açıklama);
                        command.Parameters.AddWithValue("@IslemID", v.id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Operation updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Error: Operation not found or no changes were made.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlem güncellenirken hata oluştu: " + ex.Message);
            }
        }
        public List<Islem> FilteredIslemlerSearch(string VeterinerFilter, string IsTurleri)
        {
            List<Islem> islemler = new List<Islem>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                SELECT R.id, R.Tarih, H.Name AS Hayvan, R.IslemTuru, V.AdSoyad AS Veteriner, R.açıklama 
                FROM Islemler R
                INNER JOIN Pets H ON R.PetID = H.PetID
                INNER JOIN Vets V ON R.VetID = V.id";

                    string whereClause = " WHERE 1 = 1 ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        if (!string.IsNullOrEmpty(VeterinerFilter))
                        {
                            whereClause += "AND V.AdSoyad LIKE @VetNameFilter ";
                            command.Parameters.AddWithValue("@VetNameFilter", "%" + VeterinerFilter + "%");
                        }

                        if (!string.IsNullOrEmpty(IsTurleri))
                        {
                            whereClause += "AND R.IslemTuru = @IslemTuru ";
                            command.Parameters.AddWithValue("@IslemTuru", IsTurleri);
                        }

                        command.CommandText = sql + whereClause;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Islem islem = new Islem
                                {
                                    id = reader.GetInt32(0),
                                    Tarih = reader.GetDateTime(1),
                                    Hayvan = reader.GetString(2),
                                    IslemTuru = reader.GetString(3),
                                    Veteriner = reader.GetString(4),
                                    Açıklama = reader.GetString(5),
                                };
                                islemler.Add(islem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlemler verilerini filtrelerken hata oluştu: " + ex.Message);
            }

            return islemler;
        }
    }
}
