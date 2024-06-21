using System;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var password = textBox2.Text;

            var PI = new PersonalData();
            if (PI.SetPersonalData(login, password))
            {
                var MainForm = new FormMain();
                MainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Пользоатель не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }

    }
}
