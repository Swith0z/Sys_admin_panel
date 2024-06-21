using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp7
{
    public partial class Form_Application : Form

    {
        private DB db;
        
        public Form_Application()
        {
            db = new DB();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select Z.[ID Заявки],Z.Статус,Z.Описание,S.ФИО, Z.[Дата заявки] from dbo.Заявки AS Z INNER JOIN Сотрудники_1 AS S ON Z.[ID Пользователя] = S.[ID Пользователя]";
            if(db.SqlReturnData(query, dataGridView1) != null)
            {
                MessageBox.Show("Запрос успешно выполнен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var queryAdd = $"update Заявки set Статус = N'{textBox1.Text}' where [ID Заявки] = {textBox2.Text}";
            db.queryExecute(queryAdd);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var queryAddComm = $"update Заявки set Комментарий = N'{textBox3.Text}' where [ID Заявки] = {textBox5.Text}";
            db.queryExecute(queryAddComm);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = $"select Z.[ID Заявки],z.Комментарий, z.Вопросы from dbo.Заявки AS Z";
            if (db.SqlReturnData(query, dataGridView3) != null)
            {
                MessageBox.Show("Запрос успешно выполнен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

 

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы точно хотите выйти?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Действие было отменено", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       

        private void button8_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM dbo.Заявки WHERE Статус = N'Выполнено';";
            db.queryExecute(query);
        }


     
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
            {

                var id = dataGridView1.CurrentRow.Cells[0].Value;

                string query = $"select Z.[ID Заявки],z.Комментарий, z.Вопросы from dbo.Заявки AS Z where [ID Заявки] = {id}";
                if (db.SqlReturnData(query, dataGridView3) == null)
                {
                    MessageBox.Show("Запрос успешно выполнен!", "ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            //Книга.
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

            for(int i = 1; i < dataGridView1.Columns.Count+1; i++)
            {
                ExcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                }
            }
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }
    }
}
