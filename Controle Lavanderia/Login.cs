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
    public partial class Login : Form
    {

        private OleDbConnection connection = new OleDbConnection();


        public Login()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=H:\Controlelavanderia.accdb;
Persist Security Info=False;";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string query;
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                query = "select * from Colaboradores where Matricula='" + txtLogin.Text + "'";
                command.CommandText =query;
                OleDbDataReader reader = command.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Colaborador não encontrado!");
                }
                else {
                    //MessageBox.Show(reader["Matricula"].ToString());
                    this.Hide();
                    MainForm mf = new MainForm(reader["Matricula"].ToString());
                    connection.Close();
                    mf.ShowDialog();
                }
                 
                
                connection.Close();

            }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message); 
                connection.Close();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}
