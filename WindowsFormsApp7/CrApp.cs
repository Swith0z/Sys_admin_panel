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
    public partial class CrApp : Form
    {
        private DB db;
       
        public CrApp()
        {
            db = new DB();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = $"insert into Заявки (Статус,[ID Пользователя], Описание, [Дата заявки]) values (N'Ожидание', {PersonalData.IdUser}, N'{textBox1.Text}', GETDATE())";
            db.queryExecute(query);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = $"select [ID Заявки], Статус , Описание , [Дата заявки] from dbo.Заявки where [ID Пользователя] = {PersonalData.IdUser} ";
            if (db.SqlReturnData(query, dataGridView1) != null)
            {
                MessageBox.Show("Запрос успешно выполнен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = $"select [ID Заявки], Комментарий, Вопросы from dbo.Заявки where [ID Пользователя] = {PersonalData.IdUser}";
            if (db.SqlReturnData(query, dataGridView2) != null)
            {
                MessageBox.Show("Запрос успешно выполнен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var query = $"UPDATE Заявки set Вопросы = N'{textBox2.Text}' where [ID Пользователя] = {PersonalData.IdUser}";
            db.queryExecute(query);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы точно хотите выйти?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Действие было отменено", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
