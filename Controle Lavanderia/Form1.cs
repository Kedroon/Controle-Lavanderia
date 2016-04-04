using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Controle_Lavanderia
{
    public partial class MainForm : Form
    {
        private string matricula;
        private OleDbConnection connection = new OleDbConnection();
        string query;

        public MainForm(string mat)
        {
            InitializeComponent();
            matricula = mat;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=H:\Controlelavanderia.accdb;
Persist Security Info=False;";
            updateDataGrid();
        }

        void updateDataGrid() {

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                query = "select * from Servicos where Matricula='" + matricula + "' order by Depositado desc";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read()) {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[count].Cells[0].Value = reader["ID"].ToString();

                    if (reader["Status"].ToString() == "Ok")
                    {
                        dataGridView1.Rows[count].Cells[1].Value = Properties.Resources.icn_ball_green_16;
                    }
                    else if (reader["Status"].ToString() == "Ag") {
                        dataGridView1.Rows[count].Cells[1].Value = Properties.Resources.icn_ball_yellow_16;
                    }

                    dataGridView1.Rows[count].Cells[2].Value = reader["Quantidade"].ToString();
                     if (reader["Depositado"].ToString() != "")
                     {
                         dataGridView1.Rows[count].Cells[3].Value = DateTime.Parse(reader["Depositado"].ToString()).ToString("dd/MM/yy");
                     }
                     if (reader["Retornado"].ToString() != "")
                     {
                         dataGridView1.Rows[count].Cells[4].Value = DateTime.Parse(reader["Retornado"].ToString()).ToString("dd/MM/yy");
                     }
                    
                    dataGridView1.Rows[count].Cells[5].Value = reader["Observacoes"].ToString();

                    count++;
                }
                connection.Close();

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
                connection.Close();
            }
            
                               

        }
        

    }
}
