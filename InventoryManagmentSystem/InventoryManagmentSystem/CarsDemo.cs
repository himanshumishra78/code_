using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace InventoryManagmentSystem
{
    public partial class CarsDemo : Form
    {
        public CarsDemo()
        {
            InitializeComponent();
            display();

        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=InventoryDb;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
        
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
        private void display()
        {
            con.Open();
            String Query = "select * from CarTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(txt_carname.Text=="Car Name" ||txt_carbrand.Text=="Car Brand"||txt_carmodel.Text=="Car Model"||txt_carcolor.Text=="Car Color"||txt_carowner.Text=="Car Owner")
            {
                MessageBox.Show("Wrong Input");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into CarTbl(CNum,CBrand,CModel,CDate,CColor,OwnerName) values(@CN,@CB,@CM,@CD,@CC,@ON)", con);
                    
                    cmd.Parameters.AddWithValue("@CN", txt_carname.Text);
                    cmd.Parameters.AddWithValue("@CB", txt_carbrand.Text);
                    cmd.Parameters.AddWithValue("@CM", txt_carmodel.Text);
                    cmd.Parameters.AddWithValue("@CD", dtp_car.Value.Date);
                    cmd.Parameters.AddWithValue("@CC", txt_carcolor.Text);
                    cmd.Parameters.AddWithValue("@ON", txt_carowner.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Registered");
                    con.Close();
                    display();
                }
                catch(Exception exe)
                {
                    MessageBox.Show(exe.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_carname.Text == "Car Name" || txt_carbrand.Text == "Car Brand" || txt_carmodel.Text == "Car Model" || txt_carcolor.Text == "Car Color" || txt_carowner.Text == "Car Owner")
            {
                MessageBox.Show("Wrong Input");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update CarTbl set CBrand=@CB,CModel=@CM,CDate=@CM,CDate=@CD,CColor=@CC,OwnerName=@ON where CNum=@CN", con);

                    cmd.Parameters.AddWithValue("@CN", txt_carname.Text);
                    cmd.Parameters.AddWithValue("@CB", txt_carbrand.Text);
                    cmd.Parameters.AddWithValue("@CM", txt_carmodel.Text);
                    cmd.Parameters.AddWithValue("@CD", dtp_car.Value.Date);
                    cmd.Parameters.AddWithValue("@CC", txt_carcolor.Text);
                    cmd.Parameters.AddWithValue("@ON", txt_carowner.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car updated");
                    con.Close();
                    display();
                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.Message);
                }
            }
            }
        string carKey="";
        private void button3_Click(object sender, EventArgs e)
        {
            if(carKey==" ")
            {
                MessageBox.Show("Select th Car");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from CarTbl where CNum=@CN", con);
                    cmd.Parameters.AddWithValue("@CN", carKey);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Deleted");
                    con.Close();
                    display();
                }
                catch(Exception exe)
                {
                    MessageBox.Show(exe.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txt_carname.Text = dataGridView1.SelectedRows[row].Cells[0].Value.ToString();
            carKey = dataGridView1.SelectedRows[row].Cells[0].Value.ToString();
            txt_carbrand.Text = dataGridView1.SelectedRows[row].Cells[1].Value.ToString();
            txt_carmodel.Text = dataGridView1.SelectedRows[row].Cells[2].Value.ToString();
            dtp_car.Text = dataGridView1.SelectedRows[row].Cells[3].Value.ToString();
            txt_carcolor.Text = dataGridView1.SelectedRows[row].Cells[4].Value.ToString();
            txt_carowner.Text = dataGridView1.SelectedRows[row].Cells[5].Value.ToString();
            //if (txt_carname.Text == "")
            //{
            //    key = 0;
            //}
            //else
            //{
            //    key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            //}
        }
    }
}
