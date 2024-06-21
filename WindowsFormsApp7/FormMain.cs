using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            checkRole(PersonalData.Role.ToUpper());
        }

        private string checkRole(string role)
        {
            switch (role)
            {

                case ("АДМИН"):
                    button1.Dispose();
                    MessageBox.Show($"Добро пожаловать {PersonalData.Login}", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return role;
                case ("СОТРУДНИК"):
                    button2.Dispose();
                    MessageBox.Show($"Добро пожаловать {PersonalData.Login}", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return role;
                default:
                    button1.Dispose();
                    button2.Dispose();
                    MessageBox.Show("Учетная запись некорректна.\rОбратитесь в тех. поддержку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return role;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var FormApp = new Form_Application();
            FormApp.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var CrApp = new CrApp();
            CrApp.Show();
            this.Hide();
        }
    }
}
