using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Diagnostics.Eventing.Reader;

namespace deneme_login
{
	public partial class Form1 : Form
	{	
		private MySqlConnection connection;
		string deneme = "SERVER= localhost; DATABASE=login;UID=root; PWD=Budak72";
		public Form1()
		{
			InitializeComponent();
			connection = new MySqlConnection(deneme);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			

			
		}


		private void button1_Click(object sender, EventArgs e)
		{
			string kullanici_adi = textBox1.Text;
			string şifre = textBox2.Text;


			string sql = "select * from new_table where kullanici_adi= @kullanici_adi and şifre= @şifre";
			MySqlCommand komut = new MySqlCommand(sql, connection);
			komut.Parameters.AddWithValue("@kullanici_adi", kullanici_adi);
			komut.Parameters.AddWithValue("@şifre", şifre);

			connection.Open();

			MySqlDataReader okuyucu = komut.ExecuteReader();


			if (okuyucu.Read())
			{
				MessageBox.Show("başarılı");
			}
			else
			{
				MessageBox.Show("başarısız");

			}
			connection.Close();

		} 


		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			Form2 frm2 = new Form2();
			frm2.ShowDialog();
		}
	}
}
