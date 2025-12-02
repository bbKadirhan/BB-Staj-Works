using HayvanBarınma.Repositories;
using HayvanBarınma.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HayvanBarınma
{
    public partial class Dashboard : Form
    {
        public static Dashboard Instance;

        HayvanlarRepository repository = new HayvanlarRepository();

        public Dashboard()
        {
            InitializeComponent();
            Instance = this;

        }

        public void LoadUsers()
        {
            List<HayvanBarınma.Models.Admin> userList = repository.GetAllUsers();

            dataGridView1.DataSource = userList;

            dataGridView1.ClearSelection();

            tdUsername.Text = string.Empty;
            tdPassword.Text = string.Empty;
            tdRole.SelectedIndex = -1;
            tdDeleted.SelectedIndex = -1;
        }

        public void LoadVets()
        {
            List<HayvanBarınma.Models.Vet> vetList = repository.GetAllVets();

            dataGridView2.DataSource = vetList;

            dataGridView2.ClearSelection();

            tdVetNameSurname.Text = string.Empty;
            tdVetPosition.Text = string.Empty;
            tdVetTel.Text = string.Empty;
            tdVetKurum.SelectedIndex = -1;
        }

        public void LoadPets()
        {
            List<HayvanBarınma.Models.Pet> petList = repository.GetAllPets();

            dataGridView3.DataSource = petList;

            dataGridView3.ClearSelection();

            tdPetName.Text = string.Empty;
            tdPetTur.Text = string.Empty;
            tdPetIrk.Text = string.Empty;
            tdPetYas.Text = string.Empty;
            tdPetPadok.Text = string.Empty;
            tdPetDurum.SelectedIndex = -1;
            tdCinsiyetFilter.SelectedIndex = 0;
            tdPetFilter.Text = string.Empty;
            tdPetCinsiyet.SelectedIndex = -1;
            tdDurumFilter.SelectedIndex = 0;

            dataGridView3.ClearSelection();

        }

        public void FilterPets()
        {
            dataGridView3.ClearSelection();

            string namefilter = tdPetFilter.Text.Trim();

            string cinsiyetfilter = tdCinsiyetFilter.SelectedIndex > -1
                                    ? tdCinsiyetFilter.Text.Trim()
                                    : string.Empty;

            string durumfilter = tdDurumFilter.SelectedIndex > -1
                                   ? tdDurumFilter.Text.Trim()
                                   : string.Empty;

            if (cinsiyetfilter == "Tümü") { cinsiyetfilter = null; }
            if (durumfilter == "Hiçbiri") { durumfilter = null; }


            List<HayvanBarınma.Models.Pet> petList = new List<HayvanBarınma.Models.Pet>();

            petList = repository.FilteredPetSearch(namefilter, cinsiyetfilter, durumfilter);

            dataGridView3.DataSource = petList;
            dataGridView3.ClearSelection();
        }

        public void LoadRandevus()
        {
            List<HayvanBarınma.Models.Randevu> randevuList = repository.GetAllRandevus();

            dataGridView4.DataSource = randevuList;

            dataGridView4.ClearSelection();

            tdptName.SelectedIndex = -1;
            tdvtName.Text = string.Empty;
            tdTrh.Text = string.Empty;
            tdknu.Text = string.Empty;
            tddrm.SelectedIndex = -1;

            List<string> durumList = repository.GetUniqueDurumlar();
            durumList.Insert(0, "Tümü");
            rdvDrmFlt.DataSource = durumList;

            List<string> vetList = repository.GetUniqueVeterinerAdlari();
            vetList.Insert(0, "Tümü");
            rdvVetFlt.DataSource = vetList;

            List<string> RandevuVetList = repository.GetUniqueVeterinerAdlari();
            tdvtName.DataSource = RandevuVetList;

            List<string> HayvanListesi = repository.GetUniquePets();
            tdptName.DataSource = HayvanListesi;


            dataGridView4.ClearSelection();
        }

        public void FilterRandevus()
        {
            dataGridView4.ClearSelection();

            string VetFilter = rdvVetFlt.SelectedIndex > -1
                                    ? rdvVetFlt.Text.Trim()
                                    : string.Empty;

            string durumfilter = rdvDrmFlt.SelectedIndex > -1
                                   ? rdvDrmFlt.Text.Trim()
                                   : string.Empty;

            if (VetFilter == "Tümü") { VetFilter = null; }
            if (durumfilter == "Tümü") { durumfilter = null; }


            List<HayvanBarınma.Models.Randevu> randevuList = new List<HayvanBarınma.Models.Randevu>();

            randevuList = repository.FilteredRandevuSearch(VetFilter, durumfilter);

            dataGridView4.DataSource = randevuList;
            dataGridView4.ClearSelection();
        }

        public void LoadIslemler()
        {
            List<HayvanBarınma.Models.Islem> islemList = repository.GetAllislemler();

            dataGridView5.DataSource = islemList;

            dataGridView5.ClearSelection();

            isTdName.Text = string.Empty;
            isVetCb.Text = string.Empty;
            isTdTarih.Text = string.Empty;
            isTdDesc.Text = string.Empty;
            isTdTur.SelectedIndex = -1;

            List<string> IslemTurleri = repository.GetUniqueIsTuru();
            IslemTurleri.Insert(0, "Tümü");
            isCbTur.DataSource = IslemTurleri;

            List<string> IslemList = repository.GetUniqueIsTuru();
            isTdTur.DataSource = IslemList;

            List<string> vetList = repository.GetUniqueVeterinerAdlari();
            vetList.Insert(0, "Tümü");
            isCbVet.DataSource = vetList;

            List<string> veterinerList = repository.GetUniqueVeterinerAdlari();
            vetList.Insert(0, null);
            isVetCb.DataSource = veterinerList;



            dataGridView5.ClearSelection();
        }
        public void FilterIslemler()
        {
            dataGridView5.ClearSelection();

            string VetFilter = isCbVet.SelectedIndex > -1
                                    ? isCbVet.Text.Trim()
                                    : string.Empty;

            string isTurufilter = isCbTur.SelectedIndex > -1
                                   ? isCbTur.Text.Trim()
                                   : string.Empty;

            if (VetFilter == "Tümü") { VetFilter = null; }
            if (isTurufilter == "Tümü") { isTurufilter = null; }


            List<HayvanBarınma.Models.Islem> islemlerList = new List<HayvanBarınma.Models.Islem>();

            islemlerList = repository.FilteredIslemlerSearch(VetFilter, isTurufilter);

            dataGridView5.DataSource = islemlerList;
            dataGridView5.ClearSelection();
        }

        public void PanelDesign(Button button)
        {
            pnlNav.Height = button.Height;
            pnlNav.Top = button.Top;
            button.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {


            usernameTxt.Text = Form1.Instance.loggedAdmin.Username;
            roleTxt.Text = $"Rol: {Form1.Instance.loggedAdmin.Role}";
            if (Form1.Instance.loggedAdmin.Role.Trim() == "Admin")
            {
                btnUserManagment.Enabled = true;
                btnUserManagment.Visible = true;
                VetFlowLayoutPanel.Visible = true;
            }
            else
            {
                btnUserManagment.Enabled = false;
                btnUserManagment.Visible = false;
                VetFlowLayoutPanel.Visible = false;
            }

            PanelDesign(btnHayvanlar);
            isPanel.Visible = true;
            LoadIslemler();
        }

        private void btnHayvanlar_Click(object sender, EventArgs e)
        {
            PanelDesign(btnHayvanlar);
            UsersPanel.Visible = false;
            VetPanel.Visible = false;
            petPanel.Visible = false;
            RandevuPanel.Visible = false;
            isPanel.Visible = true;

            LoadIslemler();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PanelDesign(btnRandevu);
            UsersPanel.Visible = false;
            VetPanel.Visible = false;
            petPanel.Visible = false;
            RandevuPanel.Visible = true;
            isPanel.Visible = false;

            LoadRandevus();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PanelDesign(btnPetManagment);
            UsersPanel.Visible = false;
            VetPanel.Visible = false;
            petPanel.Visible = true;
            RandevuPanel.Visible = false;
            isPanel.Visible = false;


            LoadPets();

        }

        private void btnHayvanlar_Leave(object sender, EventArgs e)
        {
            btnHayvanlar.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button2_Leave(object sender, EventArgs e)
        {
            btnRandevu.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void button3_Leave(object sender, EventArgs e)
        {
            btnPetManagment.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void btnUserManagment_Click_1(object sender, EventArgs e)
        {
            PanelDesign(btnUserManagment);
            UsersPanel.Visible = true;
            VetPanel.Visible = false;
            petPanel.Visible = false;
            RandevuPanel.Visible = false;
            isPanel.Visible = false;


            LoadUsers();

        }

        private void btnUserManagment_Leave(object sender, EventArgs e)
        {
            btnUserManagment.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tdUsername.Text.Contains(" ") || tdPassword.Text.Contains(" "))
            {
                MessageBox.Show("Lütfen kullanıcı adı veya şifrede boşluk bırakmayınız.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(tdUsername.Text) ||
                string.IsNullOrWhiteSpace(tdPassword.Text) ||
                string.IsNullOrWhiteSpace(tdRole.Text))
            {
                MessageBox.Show("Kullanıcı Adı, Şifre ve Rol alanları boş bırakılamaz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = tdRole.Text.Trim();


            if (!role.Equals("Admin", StringComparison.OrdinalIgnoreCase) &&
                !role.Equals("User", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Rol sadece 'Admin' veya 'User' olmalıdır.", "Hatalı Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Admin userToAdd = new Admin();
            userToAdd.Username = tdUsername.Text.Trim();
            userToAdd.Password = tdPassword.Text.Trim();
            userToAdd.Role = tdRole.Text.Trim();
            bool deleted;
            if (tdDeleted.Text.Trim() == "True") { deleted = true; }
            else { deleted = false; }
            userToAdd.isDeleted = deleted;


            List<HayvanBarınma.Models.Admin> userList = repository.GetAllUsers();


            string newUsername = userToAdd.Username;


            bool isDuplicate = userList.Any(a =>
                string.Equals(a.Username, newUsername, StringComparison.OrdinalIgnoreCase));

            if (isDuplicate)
            {
                MessageBox.Show($"'{newUsername}' kullanıcı adı zaten mevcut.", "Kullanıcı Zaten Var", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            repository.AddNewUser(userToAdd);

            LoadUsers();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];


                tdUsername.Text = selectedRow.Cells["username"].Value?.ToString() ?? string.Empty;
                tdPassword.Text = selectedRow.Cells["password"].Value?.ToString() ?? string.Empty;
                tdRole.Text = selectedRow.Cells["Role"].Value?.ToString()?.Trim() ?? string.Empty;
                tdDeleted.Text = selectedRow.Cells["isDeleted"].Value?.ToString() ?? string.Empty;
            }
            else
            {
                tdUsername.Text = string.Empty;
                tdPassword.Text = string.Empty;
                tdRole.Text = string.Empty;
                tdDeleted.Text = string.Empty;
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tdUsername.Text) ||
                string.IsNullOrWhiteSpace(tdPassword.Text) ||
                string.IsNullOrWhiteSpace(tdRole.Text))
            {
                MessageBox.Show("Kullanıcı Adı, Şifre ve Rol alanları boş bırakılamaz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = tdRole.Text.Trim();

            if (!role.Equals("Admin", StringComparison.OrdinalIgnoreCase) &&
                !role.Equals("User", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Rol sadece 'Admin' veya 'User' olmalıdır.", "Hatalı Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Admin a = new Admin();
            int selectedUserId = -1;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                if (selectedRow.Cells["id"].Value != null)
                {
                    if (int.TryParse(selectedRow.Cells["id"].Value.ToString(), out selectedUserId))
                    {
                        a.Id = selectedUserId;
                    }
                    else
                    {
                        MessageBox.Show("Seçilen kullanıcının ID değeri geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Seçilen kullanıcının ID değeri bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                a.Username = tdUsername.Text.Trim();
                a.Password = tdPassword.Text.Trim();
                a.Role = tdRole.Text.Trim();

                bool deleted;
                if (tdDeleted.Text.Trim().Equals("True", StringComparison.OrdinalIgnoreCase))
                {
                    deleted = true;
                }
                else if (tdDeleted.Text.Trim().Equals("False", StringComparison.OrdinalIgnoreCase))
                {
                    deleted = false;
                }
                else
                {
                    MessageBox.Show("Silme durumu ('isDeleted') sadece 'True' veya 'False' olmalıdır.", "Hatalı Değer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                a.isDeleted = deleted;
            }
            else
            {
                MessageBox.Show("Düzenlemek için önce bir kullanıcı seçmelisiniz.", "Seçim Eksik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<HayvanBarınma.Models.Admin> userList = repository.GetAllUsers();
            string newUsername = a.Username;

            bool isDuplicate = userList.Any(u =>
                string.Equals(u.Username, newUsername, StringComparison.OrdinalIgnoreCase) && u.Id != a.Id);

            if (isDuplicate)
            {
                MessageBox.Show($"'{newUsername}' kullanıcı adı başka bir kullanıcı tarafından zaten kullanılıyor.", "Kullanıcı Zaten Var", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            repository.EditUser(a);
            MessageBox.Show($"Kullanıcı '{a.Username}' başarıyla düzenlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadUsers();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tdUsername.Text = string.Empty;
            tdPassword.Text = string.Empty;
            tdRole.SelectedIndex = -1;
            tdDeleted.SelectedIndex = -1;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnVetManagment_Click(object sender, EventArgs e)
        {
            PanelDesign(btnVetManagment);
            UsersPanel.Visible = false;
            VetPanel.Visible = true;
            petPanel.Visible = false;
            isPanel.Visible = false;
            RandevuPanel.Visible = false;


            LoadVets();
        }

        private void btnVetManagment_Leave(object sender, EventArgs e)
        {
            btnVetManagment.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnAddVet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tdVetNameSurname.Text) ||
                string.IsNullOrWhiteSpace(tdVetPosition.Text) ||
                string.IsNullOrWhiteSpace(tdVetTel.Text) ||
                string.IsNullOrWhiteSpace(tdVetKurum.Text))
            {
                MessageBox.Show("Ad Soyad, Pozisyon, Telefon ve Kurum alanları boş bırakılamaz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tdVetKurum.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir Kurum seçiniz.", "Hatalı Kurum", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            HayvanBarınma.Models.Vet vetToAdd = new HayvanBarınma.Models.Vet();
            vetToAdd.AdSoyad = tdVetNameSurname.Text.Trim();
            vetToAdd.Alan = tdVetPosition.Text.Trim();
            vetToAdd.Telno = tdVetTel.Text.Trim();
            vetToAdd.Kurum = tdVetKurum.Text.Trim();



            List<HayvanBarınma.Models.Vet> vetList = repository.GetAllVets();

            string newTel = vetToAdd.Telno;

            bool isDuplicate = vetList.Any(v =>
                string.Equals(v.Telno, newTel, StringComparison.OrdinalIgnoreCase));

            if (isDuplicate)
            {
                MessageBox.Show($"'{newTel}' telefon numarasına ait bir veteriner hekim zaten mevcut.", "Kayıt Zaten Var", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            repository.AddNewVet(vetToAdd);

            LoadVets();
        }

        private void btnEditVets_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tdVetNameSurname.Text) ||
                string.IsNullOrWhiteSpace(tdVetPosition.Text) ||
                string.IsNullOrWhiteSpace(tdVetTel.Text) ||
                string.IsNullOrWhiteSpace(tdVetKurum.Text))
            {
                MessageBox.Show("Ad Soyad, Pozisyon, Telefon ve Kurum alanları boş bırakılamaz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tdVetKurum.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir Kurum seçiniz.", "Hatalı Kurum", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            HayvanBarınma.Models.Vet vetToEdit = new HayvanBarınma.Models.Vet();
            int selectedVetId = -1;

            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                if (selectedRow.Cells["Id"].Value != null)
                {
                    if (int.TryParse(selectedRow.Cells["Id"].Value.ToString(), out selectedVetId))
                    {
                        vetToEdit.Id = selectedVetId;
                    }
                    else
                    {
                        MessageBox.Show("Seçilen veteriner hekimin ID değeri geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Seçilen veteriner hekimin ID değeri bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                vetToEdit.AdSoyad = tdVetNameSurname.Text.Trim();
                vetToEdit.Alan = tdVetPosition.Text.Trim();
                vetToEdit.Telno = tdVetTel.Text.Trim();
                vetToEdit.Kurum = tdVetKurum.Text.Trim();
            }
            else
            {
                MessageBox.Show("Düzenlemek için önce bir veteriner hekim seçmelisiniz.", "Seçim Eksik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<HayvanBarınma.Models.Vet> vetList = repository.GetAllVets();

            string newTelCleaned = System.Text.RegularExpressions.Regex.Replace(vetToEdit.Telno, "[^0-9]", "");
            string newNameSurname = vetToEdit.AdSoyad;

            bool isDuplicateTel = vetList.Any(v =>
                string.Equals(System.Text.RegularExpressions.Regex.Replace(v.Telno, "[^0-9]", ""), newTelCleaned, StringComparison.Ordinal) && v.Id != vetToEdit.Id);

            if (isDuplicateTel)
            {
                MessageBox.Show($"'{vetToEdit.Telno}' telefon numarası başka bir veteriner hekim tarafından zaten kullanılıyor.", "Telefon Zaten Kullanılıyor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isDuplicateName = vetList.Any(v =>
                string.Equals(v.AdSoyad, newNameSurname, StringComparison.OrdinalIgnoreCase) && v.Id != vetToEdit.Id);

            if (isDuplicateName)
            {
                MessageBox.Show($"'{newNameSurname}' ad soyad bilgisi başka bir veteriner hekim tarafından zaten kullanılıyor.", "Ad Soyad Zaten Kullanılıyor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            repository.EditVet(vetToEdit);
            MessageBox.Show($"Veteriner hekim '{vetToEdit.AdSoyad}' başarıyla düzenlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadVets();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            tdVetNameSurname.Text = string.Empty;
            tdVetPosition.Text = string.Empty;
            tdVetTel.Text = string.Empty;
            tdVetKurum.SelectedIndex = -1;
        }

        private void btnVetRefresh_Click(object sender, EventArgs e)
        {
            LoadVets();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];


                tdVetNameSurname.Text = selectedRow.Cells["adsoyad"].Value?.ToString() ?? string.Empty;
                tdVetPosition.Text = selectedRow.Cells["alan"].Value?.ToString() ?? string.Empty;
                tdVetTel.Text = selectedRow.Cells["Telno"].Value?.ToString()?.Trim() ?? string.Empty;
                tdVetKurum.Text = selectedRow.Cells["kurum"].Value?.ToString() ?? string.Empty;
            }
            else
            {
                tdUsername.Text = string.Empty;
                tdVetPosition.Text = string.Empty;
                tdVetTel.Text = string.Empty;
                tdVetKurum.Text = string.Empty;
            }
        }

        private void tdVetTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void btnChangeAcc_Click(object sender, EventArgs e)
        {
            Form1 from1 = new Form1();
            from1.Show();

            this.Hide();
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView3.SelectedRows[0];


                tdPetName.Text = selectedRow.Cells["Name"].Value?.ToString() ?? string.Empty;
                tdPetTur.Text = selectedRow.Cells["Tur"].Value?.ToString() ?? string.Empty;
                tdPetIrk.Text = selectedRow.Cells["Irk"].Value?.ToString()?.Trim() ?? string.Empty;
                tdPetYas.Text = selectedRow.Cells["TahminiYas"].Value?.ToString() ?? string.Empty;
                tdPetDurum.Text = selectedRow.Cells["Durum"].Value?.ToString() ?? string.Empty;
                tdPetPadok.Text = selectedRow.Cells["Padok"].Value?.ToString() ?? string.Empty;
                tdPetCinsiyet.Text = selectedRow.Cells["Cinsiyet"].Value?.ToString() ?? string.Empty;


            }
            else
            {
                tdPetName.Text = string.Empty;
                tdPetTur.Text = string.Empty;
                tdPetIrk.Text = string.Empty;
                tdPetYas.Text = string.Empty;
                tdPetDurum.Text = string.Empty;
                tdPetPadok.Text = string.Empty;
                tdPetDurum.SelectedIndex = -1;
                tdPetCinsiyet.SelectedIndex = -1;
            }
        }

        private void btnPetClear_Click(object sender, EventArgs e)
        {
            tdPetName.Text = string.Empty;
            tdPetTur.Text = string.Empty;
            tdPetIrk.Text = string.Empty;
            tdPetYas.Text = string.Empty;
            tdPetDurum.Text = string.Empty;
            tdPetPadok.Text = string.Empty;
            tdPetDurum.SelectedIndex = -1;
            tdPetCinsiyet.SelectedIndex = -1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadPets();
        }

        private void petEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tdPetName.Text) ||
                string.IsNullOrWhiteSpace(tdPetTur.Text) ||
                string.IsNullOrWhiteSpace(tdPetIrk.Text) ||
                string.IsNullOrWhiteSpace(tdPetYas.Text) ||
                string.IsNullOrWhiteSpace(tdPetDurum.Text) ||
                string.IsNullOrWhiteSpace(tdPetPadok.Text) ||
                string.IsNullOrWhiteSpace(tdPetCinsiyet.Text))
            {
                MessageBox.Show("Boş Alan bırakmayınız.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cinsiyet = tdPetCinsiyet.Text.Trim();

            if (!cinsiyet.Equals("E", StringComparison.OrdinalIgnoreCase) &&
                !cinsiyet.Equals("D", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Cinsiyet sadece 'E' veya 'D' olmalıdır.", "Hatalı Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Pet p = new Pet();
            int selectedUserId = -1;

            if (dataGridView3.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView3.SelectedRows[0];

                if (selectedRow.Cells["PetID"].Value != null)
                {
                    if (int.TryParse(selectedRow.Cells["PetID"].Value.ToString(), out selectedUserId))
                    {
                        p.PetID = selectedUserId;
                    }
                    else
                    {
                        MessageBox.Show("Seçilen kullanıcının ID değeri geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Seçilen kullanıcının ID değeri bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                p.Name = tdPetName.Text.Trim();
                p.Tur = tdPetTur.Text.Trim();
                p.Irk = tdPetIrk.Text.Trim();
                p.TahminiYas = Convert.ToInt32(tdPetYas.Text.Trim());
                p.Durum = tdPetDurum.Text.Trim();
                p.Padok = tdPetPadok.Text.Trim();
                p.Cinsiyet = tdPetCinsiyet.Text.Trim();
            }
            else
            {
                MessageBox.Show("Düzenlemek için önce bir kullanıcı seçmelisiniz.", "Seçim Eksik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            repository.EditPet(p);
            MessageBox.Show($"Hayvan: '{p.Name}' başarıyla düzenlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadPets();
        }

        private void btnAddPet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tdPetName.Text) ||
               string.IsNullOrWhiteSpace(tdPetTur.Text) ||
               string.IsNullOrWhiteSpace(tdPetIrk.Text) ||
               string.IsNullOrWhiteSpace(tdPetYas.Text) ||
               string.IsNullOrWhiteSpace(tdPetDurum.Text) ||
               string.IsNullOrWhiteSpace(tdPetPadok.Text) ||
               string.IsNullOrWhiteSpace(tdPetCinsiyet.Text))
            {
                MessageBox.Show("Boş Alan bırakmayınız.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string cinsiyet = tdPetCinsiyet.Text.Trim();

            if (!cinsiyet.Equals("E", StringComparison.OrdinalIgnoreCase) &&
                !cinsiyet.Equals("D", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Cinsiyet sadece 'E' veya 'D' olmalıdır.", "Hatalı Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Pet p = new Pet();

            p.Name = tdPetName.Text.Trim();
            p.Tur = tdPetTur.Text.Trim();
            p.Irk = tdPetIrk.Text.Trim();
            p.TahminiYas = Convert.ToInt32(tdPetYas.Text.Trim());
            p.Durum = tdPetDurum.Text.Trim();
            p.Padok = tdPetPadok.Text.Trim();
            p.Cinsiyet = tdPetCinsiyet.Text.Trim();
            p.Gelis = DateTime.Now;

            repository.AddNewPet(p);

            LoadPets();
        }

        private void tdPetFilter_TextChanged(object sender, EventArgs e)
        {

            FilterPets();
        }

        private void tdCinsiyetFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterPets();
        }

        private void tdDurumFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterPets();
        }

        private void rdvVetFlt_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterRandevus();
        }

        private void rdvDrmFlt_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterRandevus();
        }

        private void isCbTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterIslemler();
        }

        private void isCbVet_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterIslemler();
        }

        private void isRefresh_Click(object sender, EventArgs e)
        {
            LoadIslemler();
        }

        private void isClear_Click(object sender, EventArgs e)
        {
            isTdName.Text = string.Empty;
            isVetCb.Text = string.Empty;
            isTdTarih.Text = string.Empty;
            isTdDesc.Text = string.Empty;
            isTdTur.SelectedIndex = -1;
            isVetCb.SelectedIndex = -1;
        }

        private void isAdd_Click(object sender, EventArgs e)
        {
            if (isTdName.Text.Trim() == string.Empty ||
               isVetCb.Text.Trim() == string.Empty ||
               isTdTarih.Text.Trim() == string.Empty ||
               isTdDesc.Text.Trim() == string.Empty ||
               isTdTur.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Boş alan Bırakmayınız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Islem i = new Islem();
            i.Tarih = Convert.ToDateTime(isTdTarih.Text.Trim());
            i.Veteriner = isVetCb.Text.Trim();
            i.IslemTuru = isTdTur.Text.Trim();
            i.Açıklama = isTdDesc.Text.Trim();
            i.Hayvan = isTdName.Text.Trim();
            repository.AddNewIslem(i);

            LoadIslemler();

        }

        private void isEdit_Click(object sender, EventArgs e)
        {
            if (isTdName.Text.Trim() == string.Empty ||
               isVetCb.Text.Trim() == string.Empty ||
               isTdTarih.Text.Trim() == string.Empty ||
               isTdDesc.Text.Trim() == string.Empty ||
               isTdTur.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Boş alan Bırakmayınız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Islem i = new Islem();

            int selectedUserId = -1;

            if (dataGridView5.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView5.SelectedRows[0];

                if (selectedRow.Cells["id"].Value != null)
                {
                    if (int.TryParse(selectedRow.Cells["id"].Value.ToString(), out selectedUserId))
                    {
                        i.id = selectedUserId;
                    }
                    else
                    {
                        MessageBox.Show("Seçilen İşlemin ID değeri geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Seçilen İşlemin ID değeri bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                i.Tarih = Convert.ToDateTime(isTdTarih.Text.Trim());
                i.Veteriner = isVetCb.Text.Trim();
                i.IslemTuru = isTdTur.Text.Trim();
                i.Açıklama = isTdDesc.Text.Trim();
                i.Hayvan = isTdName.Text.Trim();
            }
            else
            {
                MessageBox.Show("Düzenlemek için önce bir İşlem seçmelisiniz.", "Seçim Eksik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            repository.EditIslem(i);
            LoadIslemler();
        }

        private void dataGridView5_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView5.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView5.SelectedRows[0];


                isTdName.Text = selectedRow.Cells["Hayvan"].Value?.ToString() ?? string.Empty;
                isTdTarih.Text = selectedRow.Cells["Tarih"].Value?.ToString() ?? string.Empty;
                isVetCb.Text = selectedRow.Cells["Veteriner"].Value?.ToString() ?? string.Empty;
                isTdTur.Text = selectedRow.Cells["IslemTuru"].Value?.ToString()?.Trim() ?? string.Empty;
                isTdDesc.Text = selectedRow.Cells["Açıklama"].Value?.ToString() ?? string.Empty;
            }
            else
            {
                isTdName.Text = string.Empty;
                isTdTarih.Text = string.Empty;
                isVetCb.Text = string.Empty;
                isTdTur.Text = string.Empty;
                isTdDesc.Text = string.Empty;

            }
        }

        private void isExcel_Click(object sender, EventArgs e)
        {
            DataExportHelperXlsx.ExportDataGridViewToXlsx(dataGridView5);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DataExportHelperXlsx.ExportDataGridViewToXlsx(dataGridView3);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataExportHelperXlsx.ExportDataGridViewToXlsx(dataGridView1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataExportHelperXlsx.ExportDataGridViewToXlsx(dataGridView4);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DataExportHelperXlsx.ExportDataGridViewToXlsx(dataGridView2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tdptName.SelectedIndex = -1;
            tdvtName.Text = string.Empty;
            tdvtName.SelectedIndex = -1;
            tdTrh.Text = string.Empty;
            tdknu.Text = string.Empty;
            tddrm.SelectedIndex = -1;
        }

        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView4.SelectedRows[0];


                tdptName.Text = selectedRow.Cells["Hayvan"].Value?.ToString() ?? string.Empty;
                tdTrh.Text = selectedRow.Cells["Tarih"].Value?.ToString() ?? string.Empty;
                tdvtName.Text = selectedRow.Cells["Veteriner"].Value?.ToString() ?? string.Empty;
                tdknu.Text = selectedRow.Cells["Konu"].Value?.ToString()?.Trim() ?? string.Empty;
                tddrm.Text = selectedRow.Cells["Durum"].Value?.ToString() ?? string.Empty;
            }
            else
            {
                tdptName.Text = string.Empty;
                tdTrh.Text = string.Empty;
                tdvtName.Text = string.Empty;
                tdknu.Text = string.Empty;
                tddrm.Text = string.Empty;

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoadRandevus();
        }

        private void randevuEdit_Click(object sender, EventArgs e)
        {
            if (tdptName.Text.Trim() == string.Empty ||
               tdvtName.Text.Trim() == string.Empty ||
               tdTrh.Text.Trim() == string.Empty ||
               tdknu.Text.Trim() == string.Empty ||
               tddrm.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Boş alan Bırakmayınız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Randevu i = new Randevu();

            int selectedUserId = -1;

            if (dataGridView4.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView4.SelectedRows[0];

                if (selectedRow.Cells["id"].Value != null)
                {
                    if (int.TryParse(selectedRow.Cells["id"].Value.ToString(), out selectedUserId))
                    {
                        i.id = selectedUserId;
                    }
                    else
                    {
                        MessageBox.Show("Seçilen İşlemin ID değeri geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Seçilen İşlemin ID değeri bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                i.Tarih = Convert.ToDateTime(tdTrh.Text.Trim());
                i.Veteriner = tdvtName.Text.Trim();
                i.Hayvan = tdptName.Text.Trim();
                i.Konu = tdknu.Text.Trim();
                i.Durum = tddrm.Text.Trim();
            }
            else
            {
                MessageBox.Show("Düzenlemek için önce bir İşlem seçmelisiniz.", "Seçim Eksik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            repository.EditRandevu(i);
            LoadRandevus();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (tdptName.Text.Trim() == string.Empty ||
               tdvtName.Text.Trim() == string.Empty ||
               tdTrh.Text.Trim() == string.Empty ||
               tdknu.Text.Trim() == string.Empty ||
               tddrm.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Boş alan Bırakmayınız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Randevu i = new Randevu();


            i.Tarih = Convert.ToDateTime(tdTrh.Text.Trim());
            i.Veteriner = tdvtName.Text.Trim();
            i.Hayvan = tdptName.Text.Trim();
            i.Konu = tdknu.Text.Trim();
            i.Durum = tddrm.Text.Trim();


            repository.AddRandevu(i);
            LoadRandevus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
