using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string pass = textBox2.Text;

            if (login == "12345" && pass == "12345")
            {
                tabControl1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = true;
                groupBox4.Visible = true;
                groupBox5.Visible = true;
                groupBox7.Visible = true;
                groupBox8.Visible = true;
            }
            else
            {
                tabControl1.Visible = true;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
                groupBox4.Visible = false;
                groupBox5.Visible = false;
                groupBox7.Visible = false;
                groupBox8.Visible = false;
            }

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `comp`", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            dataGridView1.Rows.Clear();

            dataGridView1.RowCount = table.Rows.Count != 0 ? table.Rows.Count : 1;
            for (int i = 0; i < table.Rows.Count; ++i)
            {
                dataGridView1.Rows[i].Cells[0].Value = table.Rows[i].ItemArray[0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = table.Rows[i].ItemArray[1].ToString();
                dataGridView1.Rows[i].Cells[2].Value = table.Rows[i].ItemArray[2].ToString();
                dataGridView1.Rows[i].Cells[3].Value = table.Rows[i].ItemArray[3].ToString();
                dataGridView1.Rows[i].Cells[4].Value = table.Rows[i].ItemArray[4].ToString();
                dataGridView1.Rows[i].Cells[5].Value = table.Rows[i].ItemArray[5].ToString();
            }

            DB db2 = new DB();

            DataTable table2 = new DataTable();

            MySqlDataAdapter adapter2 = new MySqlDataAdapter();

            MySqlCommand command2 = new MySqlCommand("SELECT * FROM `traffic`", db2.getConnection());

            adapter2.SelectCommand = command2;
            adapter2.Fill(table2);

            dataGridView2.Rows.Clear();

            dataGridView2.RowCount = table2.Rows.Count != 0 ? table2.Rows.Count : 1;
            for (int i = 0; i < table2.Rows.Count; ++i)
            {
                dataGridView2.Rows[i].Cells[0].Value = table2.Rows[i].ItemArray[0].ToString();
                dataGridView2.Rows[i].Cells[1].Value = table2.Rows[i].ItemArray[1].ToString();
                dataGridView2.Rows[i].Cells[2].Value = table2.Rows[i].ItemArray[2].ToString();
                dataGridView2.Rows[i].Cells[3].Value = table2.Rows[i].ItemArray[3].ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `traffic`", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            int id = table.Rows.Count + 1;
            string from_port = textBox9.Text;
            string to_port = textBox10.Text;
            string max_load = textBox11.Text;

            DB db2 = new DB();

            DataTable table2 = new DataTable();

            MySqlDataAdapter adapter2 = new MySqlDataAdapter();

            MySqlCommand command2 = new MySqlCommand("INSERT INTO `traffic` (`id`, `from_port`, `to_port`, `max_load`) VALUES (@id, @from_port, @to_port, @max_load)", db.getConnection());
            command2.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            command2.Parameters.Add("@from_port", MySqlDbType.VarChar).Value = from_port;
            command2.Parameters.Add("@to_port", MySqlDbType.VarChar).Value = to_port;
            command2.Parameters.Add("@max_load", MySqlDbType.VarChar).Value = max_load;


            adapter2.SelectCommand = command2;
            adapter2.Fill(table2);

            DB db1 = new DB();

            DataTable table1 = new DataTable();

            MySqlDataAdapter adapter1 = new MySqlDataAdapter();

            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `traffic`", db.getConnection());

            adapter1.SelectCommand = command1;
            adapter1.Fill(table1);

            dataGridView2.Rows.Clear();

            dataGridView2.RowCount = table1.Rows.Count;
            for (int i = 0; i < table1.Rows.Count; ++i)
            {
                dataGridView2.Rows[i].Cells[0].Value = table1.Rows[i].ItemArray[0].ToString();
                dataGridView2.Rows[i].Cells[1].Value = table1.Rows[i].ItemArray[1].ToString();
                dataGridView2.Rows[i].Cells[2].Value = table1.Rows[i].ItemArray[2].ToString();
                dataGridView2.Rows[i].Cells[3].Value = table1.Rows[i].ItemArray[3].ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string id = textBox12.Text;
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("DELETE FROM `traffic` WHERE `traffic`.`id` = @id", db.getConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

            adapter.SelectCommand = command;
            adapter.Fill(table);


            DB db1 = new DB();

            DataTable table1 = new DataTable();

            MySqlDataAdapter adapter1 = new MySqlDataAdapter();

            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `traffic`", db.getConnection());

            adapter1.SelectCommand = command1;
            adapter1.Fill(table1);

            dataGridView2.Rows.Clear();

            dataGridView2.RowCount = table1.Rows.Count;
            for (int i = 0; i < table1.Rows.Count; ++i)
            {
                dataGridView2.Rows[i].Cells[0].Value = table1.Rows[i].ItemArray[0].ToString();
                dataGridView2.Rows[i].Cells[1].Value = table1.Rows[i].ItemArray[1].ToString();
                dataGridView2.Rows[i].Cells[2].Value = table1.Rows[i].ItemArray[2].ToString();
                dataGridView2.Rows[i].Cells[3].Value = table1.Rows[i].ItemArray[3].ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("DELETE FROM `traffic`", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);


            DB db1 = new DB();

            DataTable table1 = new DataTable();

            MySqlDataAdapter adapter1 = new MySqlDataAdapter();

            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `traffic`", db.getConnection());

            adapter1.SelectCommand = command1;
            adapter1.Fill(table1);

            dataGridView2.Rows.Clear();

            dataGridView2.RowCount = table1.Rows.Count != 0 ? table1.Rows.Count : 1;
            for (int i = 0; i < table1.Rows.Count; ++i)
            {
                dataGridView2.Rows[i].Cells[0].Value = table1.Rows[i].ItemArray[0].ToString();
                dataGridView2.Rows[i].Cells[1].Value = table1.Rows[i].ItemArray[1].ToString();
                dataGridView2.Rows[i].Cells[2].Value = table1.Rows[i].ItemArray[2].ToString();
                dataGridView2.Rows[i].Cells[3].Value = table1.Rows[i].ItemArray[3].ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `comp`", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            int id = table.Rows.Count + 1;
            string typ = textBox3.Text;
            string number = textBox4.Text;
            string load = textBox5.Text;
            string from_port = textBox6.Text;
            string to_port = textBox7.Text;

            DB db2 = new DB();

            DataTable table2 = new DataTable();

            MySqlDataAdapter adapter2 = new MySqlDataAdapter();

            MySqlCommand command2 = new MySqlCommand("INSERT INTO `comp` (`id`, `typ`, `number`, `load`, `from_port`, `to_port`) VALUES (@id, @typ, @number, @load, @from_port, @to_port)", db.getConnection());
            command2.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            command2.Parameters.Add("@typ", MySqlDbType.VarChar).Value = typ;
            command2.Parameters.Add("@number", MySqlDbType.VarChar).Value = number;
            command2.Parameters.Add("@load", MySqlDbType.VarChar).Value = load;
            command2.Parameters.Add("@from_port", MySqlDbType.VarChar).Value = from_port;
            command2.Parameters.Add("@to_port", MySqlDbType.VarChar).Value = to_port;


            adapter2.SelectCommand = command2;
            adapter2.Fill(table2);

            DB db1 = new DB();

            DataTable table1 = new DataTable();

            MySqlDataAdapter adapter1 = new MySqlDataAdapter();

            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `comp`", db.getConnection());

            adapter1.SelectCommand = command1;
            adapter1.Fill(table1);

            dataGridView1.Rows.Clear();

            dataGridView1.RowCount = table1.Rows.Count;
            for (int i = 0; i < table1.Rows.Count; ++i)
            {
                dataGridView1.Rows[i].Cells[0].Value = table1.Rows[i].ItemArray[0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = table1.Rows[i].ItemArray[1].ToString();
                dataGridView1.Rows[i].Cells[2].Value = table1.Rows[i].ItemArray[2].ToString();
                dataGridView1.Rows[i].Cells[3].Value = table1.Rows[i].ItemArray[3].ToString();
                dataGridView1.Rows[i].Cells[4].Value = table1.Rows[i].ItemArray[4].ToString();
                dataGridView1.Rows[i].Cells[5].Value = table1.Rows[i].ItemArray[5].ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id = textBox8.Text;
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("DELETE FROM `comp` WHERE `comp`.`id` = @id", db.getConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

            adapter.SelectCommand = command;
            adapter.Fill(table);


            DB db1 = new DB();

            DataTable table1 = new DataTable();

            MySqlDataAdapter adapter1 = new MySqlDataAdapter();

            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `comp`", db.getConnection());

            adapter1.SelectCommand = command1;
            adapter1.Fill(table1);

            dataGridView1.Rows.Clear();

            dataGridView1.RowCount = table1.Rows.Count;
            for (int i = 0; i < table1.Rows.Count; ++i)
            {
                dataGridView1.Rows[i].Cells[0].Value = table1.Rows[i].ItemArray[0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = table1.Rows[i].ItemArray[1].ToString();
                dataGridView1.Rows[i].Cells[2].Value = table1.Rows[i].ItemArray[2].ToString();
                dataGridView1.Rows[i].Cells[3].Value = table1.Rows[i].ItemArray[3].ToString();
                dataGridView1.Rows[i].Cells[4].Value = table1.Rows[i].ItemArray[4].ToString();
                dataGridView1.Rows[i].Cells[5].Value = table1.Rows[i].ItemArray[5].ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("DELETE FROM `comp`", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);


            DB db1 = new DB();

            DataTable table1 = new DataTable();

            MySqlDataAdapter adapter1 = new MySqlDataAdapter();

            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `comp`", db.getConnection());

            adapter1.SelectCommand = command1;
            adapter1.Fill(table1);

            dataGridView1.Rows.Clear();

            dataGridView1.RowCount = table1.Rows.Count != 0 ? table1.Rows.Count : 1;
            for (int i = 0; i < table1.Rows.Count; ++i)
            {
                dataGridView1.Rows[i].Cells[0].Value = table1.Rows[i].ItemArray[0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = table1.Rows[i].ItemArray[1].ToString();
                dataGridView1.Rows[i].Cells[2].Value = table1.Rows[i].ItemArray[2].ToString();
                dataGridView1.Rows[i].Cells[3].Value = table1.Rows[i].ItemArray[3].ToString();
                dataGridView1.Rows[i].Cells[4].Value = table1.Rows[i].ItemArray[4].ToString();
                dataGridView1.Rows[i].Cells[5].Value = table1.Rows[i].ItemArray[5].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> Mass = new List<string>();

            for (int i = 0; i < dataGridView1.RowCount; ++i)
            {
                if (Mass.IndexOf(Convert.ToString(dataGridView1.Rows[i].Cells[4].Value)) == -1)
                    Mass.Add(Convert.ToString(dataGridView1.Rows[i].Cells[4].Value));
                if (Mass.IndexOf(Convert.ToString(dataGridView1.Rows[i].Cells[5].Value)) == -1)
                    Mass.Add(Convert.ToString(dataGridView1.Rows[i].Cells[5].Value));
            }

            List<List<int>> MassCompany = new List<List<int>>();

            for (int i = 0; i < Mass.Count; ++i)
            {
                List<int> a = new List<int>();
                for (int j = 0; j < Mass.Count; ++j)
                    a.Add(5000);
                MassCompany.Add(a);
            }


            for (var i = 0; i < MassCompany.Count; ++i)
            {
                for (var j = 0; j < MassCompany.Count; ++j)
                    for (var k = 0; k < dataGridView2.RowCount; ++k)
                        if ((Convert.ToString(dataGridView2.Rows[k].Cells[1].Value) == Mass[i] && Convert.ToString(dataGridView2.Rows[k].Cells[2].Value) == Mass[j]) || (Convert.ToString(dataGridView2.Rows[k].Cells[1].Value) == Mass[j] && Convert.ToString(dataGridView2.Rows[k].Cells[2].Value) == Mass[i]))
                            MassCompany[i][j] = Convert.ToInt32(Convert.ToString(dataGridView2.Rows[k].Cells[3].Value));
            }


            List<int> ANS = new List<int>();
            ANS.Add(0);
            do
            {
                int max = 9999;
                int j = ANS[ANS.Count - 1];
                for (var i = 0; i < MassCompany.Count; ++i)
                {
                    if (MassCompany[j][i] < max && ANS.IndexOf(i) == -1)
                    {
                        max = MassCompany[ANS[ANS.Count - 1]][i];
                        j = i;
                    }
                }
                ANS.Add(j);
            } while (ANS.Count < Mass.Count);

            var str = "";
            for (var i = 0; i < ANS.Count - 1; ++i)
                str += Mass[ANS[i]] + "-";
            if (ANS.Count != 0)
                str += Mass[ANS[ANS.Count - 1]];

            int sum = 0;
            for (var i = 0; i < ANS.Count - 1; ++i)
                sum += MassCompany[ANS[i]][ANS[i + 1]];

            int M = 0;
            List<int> V = new List<int>();
            for (var i = 0; i < ANS.Count - 1; ++i)
            {
                for (var j = 0; j < dataGridView1.RowCount; ++j)
                {
                    if (Convert.ToString(dataGridView1.Rows[j].Cells[4].Value) == Mass[ANS[i]])
                        M += Convert.ToInt32(dataGridView1.Rows[j].Cells[3].Value);
                    if (Convert.ToString(dataGridView1.Rows[j].Cells[5].Value) == Mass[ANS[i]])
                        M -= Convert.ToInt32(dataGridView1.Rows[j].Cells[3].Value);
                }
                V.Add(M);
            }


            for (int i = 0; i < ANS.Count - 1; ++i)
            {
                ListViewItem item = new ListViewItem(Mass[ANS[i]]);
                item.SubItems.Add(Mass[ANS[i + 1]]);
                item.SubItems.Add(Convert.ToString(MassCompany[ANS[i]][ANS[i + 1]]));
                item.SubItems.Add(Convert.ToString(V[i]));
                listView1.Items.Add(item);
            }

            textBox13.Text = str;
            textBox14.Text = Convert.ToString(sum);
            textBox15.Text = ANS.Count > 1 ? Mass[ANS[1]] : "";
        }
    }
}
