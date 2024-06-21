using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp7
{
    public class DB
    {

        public string StringConSql = @"Data Source=DESKTOP-0BKOCES\SQLEXPRESS;Initial Catalog=dbRole;Integrated Security=True";

       public DataTable SqlReturnData(string query, DataGridView grid)
        {
            try
            {
                using(SqlConnection myCon = new SqlConnection(StringConSql))
                {
                    myCon.Open();
                    if (myCon.State != ConnectionState.Open)
                    {
                        MessageBox.Show($"Не удалось установить подключение к базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }

                    using (SqlDataAdapter sda = new SqlDataAdapter(query, myCon))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                       
                        grid.DataSource = dt;
                        return dt;
                    }
                }

                
            }
            catch (SqlException ex) 
            {
                MessageBox.Show($"Возникла ошибка при выполнении запроса: {ex.Message}", "Ошибка" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch ( Exception ex)
            {
                MessageBox.Show($"Произошла непредвенная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public SqlDataAdapter queryExecute(string query)
        {
            try
            {
                SqlConnection myCon = new SqlConnection(StringConSql);
                myCon.Open();

                SqlDataAdapter SDA = new SqlDataAdapter(query, myCon);

                SDA.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Действие успешно выполнено!", "Успех");
                return SDA;
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при выполнении запроса.", "Ошибка");
                return null;
            }
        }
    }
}
