using HayvanBarınma.Models;
using HayvanBarınma.Repositories;
using System.Windows.Forms; 
using System.Data;
using System;
using System.Text;

namespace HayvanBarınma
{
    public partial class Form1 : Form
    {
        private readonly HayvanlarRepository _repository;
        public static Form1 Instance;
        public Admin loggedAdmin;

        public Form1()
        {
            InitializeComponent();
            _repository = new HayvanlarRepository();
            Instance = this;
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            string enteredUsername = tbUsername.Text;
            string enteredPassword = tbPassword.Text;

            if (enteredUsername.Contains(" ") || enteredPassword.Contains(" "))
            {
                MessageBox.Show("Lütfen kullanıcı adı veya şifrede boşluk bırakmayınız.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(enteredUsername) || string.IsNullOrWhiteSpace(enteredPassword))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifreyi giriniz.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Admin loggedInAdmin = _repository.GetAdminByCredentials(enteredUsername, enteredPassword);
            loggedAdmin = loggedInAdmin;

            if (loggedInAdmin != null)
            {
                MessageBox.Show($"Hoş geldiniz, {loggedInAdmin.Username}!", "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);


                Dashboard dashboard = new Dashboard();
                dashboard.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Geçersiz Kullanıcı Adı veya Şifre.", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
