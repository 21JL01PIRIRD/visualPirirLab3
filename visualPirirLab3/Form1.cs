using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visualPirirLab3
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=TMKGER01;Initial Catalog=logint; Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void agregar()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from tienda", conn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "aaa");
            dataGridView1.DataSource = ds.Tables["aaa"].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("INSERT INTO tienda(producto,precio,marca) VALUES('" + textBox1.Text + "','" + textBox2.Text + "', '" + textBox3.Text + "')", conn);
            sda.SelectCommand.ExecuteNonQuery();
            agregar();
            MessageBox.Show("Producto registrado");
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM tienda WHERE id =" + textBox4.Text;
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox4.Text = reader[0].ToString();
                    textBox1.Text = reader[1].ToString();
                    textBox2.Text = reader[2].ToString();
                    textBox3.Text = reader[3].ToString();
                }
                else
                    MessageBox.Show("Ningun registro encontrado con el id ingresado!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            textBox4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM tienda WHERE id=" + textBox5.Text;

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Registro eliminado correctamente!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            MessageBox.Show("Conexion Exitosa");
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reporte1 rm1 = new Reporte1();
            rm1.ShowDialog();
        }
    }
}
