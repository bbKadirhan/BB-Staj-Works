using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RandevuUygulamasıWinForm.RandevuApp;
using static System.Net.Mime.MediaTypeNames;

namespace RandevuUygulamasıWinForm
{
    public partial class RandevuApp : Form
    {
        public RandevuApp()
        {
            InitializeComponent();
        }
        //değişkenler

        private bool dataNotSaved = false;

        // Fonksiyonlar
        public void Setcolor(Color backColor, Color textColor)
        {
            BackColor = backColor;
            ForeColor = textColor;

            statusStrip1.BackColor = backColor;
            statusStrip1.ForeColor = textColor;

            menuStrip1.BackColor = backColor;
            menuStrip1.ForeColor = textColor;

            dateTimePicker1.BackColor = backColor;
            dateTimePicker1.ForeColor = textColor;

            toolStripStatusLabel1.BackColor = backColor;
            toolStripStatusLabel1.ForeColor = textColor;

            toolStripStatusLabel2.BackColor = backColor;
            toolStripStatusLabel2.ForeColor = textColor;

            toolStripStatusLabel4.BackColor = backColor;
            toolStripStatusLabel4.ForeColor = textColor;

            toolStripStatusLabel5.BackColor = backColor;
            toolStripStatusLabel5.ForeColor = textColor;

            dataGridView1.BackgroundColor = backColor;
            dataGridView1.ForeColor = Color.Black;

            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
        }

 
        public void DefaulTXTCreate(string folderPath)
        {
            string[] fileNames = { "clients.txt","rooms.txt"};

            foreach (string fileName in fileNames)
            {
                string filePath = Path.Combine(folderPath, fileName);
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, "", Encoding.UTF8);
                }
            }
        }

        private List<Client> LoadClientsFromTextFile()
        {
            List<Client> clients = new List<Client>();
            string filePath = Path.Combine(path, "clients.txt");

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath)
                                       .Where(line => !string.IsNullOrWhiteSpace(line))
                                       .ToArray();
                int currentId = 1;

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');

                    if (parts.Length >= 5)
                    {
                        if (Int64.TryParse(parts[2].Trim(), out Int64 phoneNumber))
                        {
                            clients.Add(new Client
                            {
                                id = currentId++,
                                room = parts[0].Trim(),
                                fullname = parts[1].Trim(),
                                phone = phoneNumber,
                                time = parts[3].Trim(),
                                date = parts[4].Trim()
                            });
                        }
                    }
                }
            }
            return clients;
        }

        private void SaveClientsToTextFile(List<Client> clients)
        {
            string filePath = Path.Combine(path, "clients.txt");
            List<string> linesToSave = new List<string>();

            foreach (Client client in clients)
            {
                string line = $"{client.room}|{client.fullname}|{client.phone}|{client.time}|{client.date}";
                linesToSave.Add(line);
            }

            try
            {
                File.WriteAllLines(filePath, linesToSave, Encoding.UTF8);
                dataNotSaved = false;
                toolStripStatusLabel5.Text = $"Son Kaydetme: {DateTime.Now.TimeOfDay:hh\\:mm\\:ss}";
                MessageBox.Show("Veriler başarıyla kaydedildi.", "Kaydetme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kaydetme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class Client
        {
            public int id { get; set; }
            public string fullname { get; set; }
            public Int64 phone { get; set; }
            public string room { get; set; }
            public string date { get; set; }
            public string time { get; set; }
        }

        // Data

        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"RandevuPlanlayici","data" );


        // İşlemler
        private void RandevuApp_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                DefaulTXTCreate(path);
            }
            catch
            {
                MessageBox.Show("Data klasoru oluşumunda hata oluştu bilgileriniz kaydedilmeyebilir tekrar giriş yapınız.");
            }

            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(1);

            Setcolor(Color.FromArgb(220, 220, 220), Color.FromArgb(0, 0, 0));

            List<Client> clients = LoadClientsFromTextFile();

            dataGridView1.DataSource = clients;
            if (dataGridView1.Columns.Contains("id"))
            {
                dataGridView1.Columns["id"].ReadOnly = true;
            }

        }

        private void açıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setcolor(Color.FromArgb(220, 220, 220), Color.FromArgb(0, 0, 0));
        }

        private void koyuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setcolor(Color.FromArgb(41, 41, 41), Color.FromArgb(255, 255, 255));
        }

        private void yüksekKontrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setcolor(Color.FromArgb(0, 0, 0), Color.FromArgb(255, 255, 0));
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(1);
            toolStripStatusLabel1.Text = $"Saat: {dateTimePicker1.Value.Hour.ToString()}";
            toolStripStatusLabel2.Text = $"Seçili Gün: {dateTimePicker1.Value.Day.ToString()}";
        }

        private void veriKalsorunuAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(path);
        }
        private void RandevuApp_FormClosing(object sender, FormClosingEventArgs e)
        {
           

            //datagridviewde bilgi kaydedilmedi ise uyar
            if (dataNotSaved == true)
            {
                DialogResult result = MessageBox.Show("Tabloda Kaydedilmemiş değişikler var!\nDeğişiklikler kaydedilsin mi?", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                else if (result == DialogResult.Yes)
                {
                        dataGridView1.EndEdit();
                        if (dataGridView1.DataSource is List<Client> editedClients)
                        {
                            SaveClientsToTextFile(editedClients);
                        }
                }
                else if (result == DialogResult.No)
                {
                    e.Cancel = false;
                }
            }

            if (String.IsNullOrEmpty(textBox1.Text.Trim())) { return; }
            else if (String.IsNullOrEmpty(textBox2.Text.Trim())) { return; }
            else if (String.IsNullOrEmpty(textBox3.Text.Trim())) { return; }
            else if (radioButton1.Checked == false && radioButton2.Checked == false) { return; }
            else if (comboBox1.SelectedItem == null) { return; }

            string selectedTime = "";
            if (radioButton1.Checked == true) { selectedTime = radioButton1.Text.Trim(); }
            else if (radioButton2.Checked == true) { selectedTime = radioButton2.Text.Trim(); }

            string lastline = File.ReadAllLines(Path.Combine(path, "clients.txt")).LastOrDefault() ?? "";
            string expectedLastLine =
                        $"{comboBox1.SelectedItem.ToString()}|" +
                        $"{textBox1.Text.Trim()} {textBox2.Text.Trim()}|" + $"{textBox3.Text.Trim()}|" +
                        $"{selectedTime}|" +
                        $"{dateTimePicker1.Value.ToString("dd.MM.yyyy")}";


            if ((lastline != expectedLastLine) || dataNotSaved == true)
            {
                DialogResult result = MessageBox.Show("Şunaki girili bilgiler Kaydedilmemiş!\nDeğişiklikler kaydedilsin mi?", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                else if (result == DialogResult.Yes)
                {
                    if (lastline != expectedLastLine)
                    {
                        if (String.IsNullOrEmpty(textBox1.Text.Trim())) { return; }
                        else if (String.IsNullOrEmpty(textBox2.Text.Trim())) { return; }
                        else if (String.IsNullOrEmpty(textBox3.Text.Trim())) { return; }
                        else if (radioButton1.Checked == false && radioButton2.Checked == false) { return; }
                        else if (comboBox1.SelectedItem == null) { return; }

                        Client client = new Client();
                        client.fullname = textBox1.Text.Trim() + " " + textBox2.Text.Trim();
                        client.phone = Convert.ToInt64(textBox3.Text);
                        client.room = comboBox1.SelectedItem.ToString();
                        client.date = dateTimePicker1.Value.Date.ToShortDateString();
                        if (radioButton1.Checked == true) { client.time = radioButton1.Text.Trim(); }
                        if (radioButton2.Checked == true) { client.time = radioButton2.Text.Trim(); }

                        File.AppendAllLines(Path.Combine(path, "clients.txt"), new[] { $"{client.room}|{client.fullname}|{client.phone}|{client.time}|{client.date}" });
                    }
                }
                else if (result == DialogResult.No)
                {
                    e.Cancel = false;
                }
            }
            e.Cancel = false;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void verileriYükleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Client> clients = LoadClientsFromTextFile();

            dataGridView1.DataSource = clients;
        }

        private void verileriKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();

            if (dataGridView1.DataSource is List<Client> editedClients)
            {
                SaveClientsToTextFile(editedClients);
            }
            else
            {
                MessageBox.Show("Veri kaynağı bulunamadı veya düzenlenemiyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            dataNotSaved = true;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataNotSaved = true;
        }

        private void yedekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string backupPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RandevuPlanlayici", "Backupdata");
                string backupClients = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RandevuPlanlayici", "Backupdata","backup-clients.txt");
                string Clientdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RandevuPlanlayici", "data", "clients.txt");
                if (!Directory.Exists(backupPath))
                {
                    Directory.CreateDirectory(backupPath);
                    
                }
                File.Copy(Clientdata,backupClients, true);
                MessageBox.Show("Yedekleme başarıyla tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Yedeklemede bir hata oluştu bilgileriniz kaydedilmeyebilir tekrar giriş yapınız.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ok = false;
            int hatalar = 0;
            errorProvider1.Clear();
            if (String.IsNullOrEmpty(textBox1.Text.Trim())) { errorProvider1.SetError(textBox1, "Zorunlu"); hatalar++; ok = true; }
            if (String.IsNullOrEmpty(textBox2.Text.Trim())) { errorProvider1.SetError(textBox2, "Zorunlu"); hatalar++; ok = true; }
            if (String.IsNullOrEmpty(textBox3.Text.Trim()) || textBox3.Text.Trim().Length < 10) { errorProvider1.SetError(textBox3, "Zorunlu"); hatalar++; ok = true; }
            if (radioButton1.Checked == false && radioButton2.Checked == false) { errorProvider1.SetError(radioButton1, "Zorunlu"); hatalar++; errorProvider1.SetError(radioButton2, "Zorunlu"); hatalar++; ok = true; }
            if (comboBox1.SelectedItem == null) { errorProvider1.SetError(comboBox1, "Zorunlu"); hatalar++; ok = true; }

            toolStripStatusLabel4.Text = $"Çakışma sayısı: {hatalar.ToString()}";
            if (ok == true) { return; }




            Client client = new Client();
            client.fullname = textBox1.Text.Trim() + " " + textBox2.Text.Trim();
            client.phone = Convert.ToInt64(textBox3.Text);
            client.room = comboBox1.SelectedItem.ToString();
            client.date = dateTimePicker1.Value.Date.ToShortDateString();
            if (radioButton1.Checked == true) { client.time = radioButton1.Text.Trim(); }
            if (radioButton2.Checked == true) { client.time = radioButton2.Text.Trim(); }

            File.AppendAllLines(Path.Combine(path, "clients.txt"), new[] { $"{client.room}|{client.fullname}|{client.phone}|{client.time}|{client.date}" });
            toolStripStatusLabel5.Text = $"Son Kaydetme: {DateTime.Now.TimeOfDay:hh\\:mm\\:ss}";


            //datagride bilgi gösterme
            List<Client> clients = LoadClientsFromTextFile();

            dataGridView1.DataSource = clients;
            MessageBox.Show("Yeni müşteri başarılı bir şekilde eklendi","Müşteri eklendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            radioButton1.Checked = false; radioButton2.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            comboBox1.SelectedIndex = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //datagrideki değişikleri kaydetmek
            dataGridView1.EndEdit();

            if (dataGridView1.DataSource is List<Client> editedClients)
            {
                SaveClientsToTextFile(editedClients);
            }
            else
            {
                MessageBox.Show("Veri kaynağı bulunamadı veya düzenlenemiyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
