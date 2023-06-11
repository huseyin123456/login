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
using MySql.Data.MySqlClient;
using MySql.Data;

namespace deneme_login
{
	public partial class Form2 : Form
	{
		private MySqlConnection connection;
		string deneme = "SERVER= localhost; DATABASE=login;UID=root; PWD=Budak72";
		public Form2()
		{
			InitializeComponent();
			connection = new MySqlConnection(deneme);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form1 frm1 = new Form1();
			frm1.ShowDialog();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			string kullanici_adi = textBox1.Text;
			string şifre= textBox2.Text;

			string sql = "insert into new_table (kullanici_adi, şifre) values(@kullanici_adi, @şifre)";
			MySqlCommand komut = new MySqlCommand(sql, connection);
			komut.Parameters.AddWithValue("@kullanici_adi", kullanici_adi);
			komut.Parameters.AddWithValue("@şifre", şifre);

			connection.Open();
			int bilinmeyen = komut.ExecuteNonQuery();
			connection.Close();

			if (bilinmeyen > 0)
			{
				MessageBox.Show("kayıt başarılı giriş yapabilirsiniz");
			}
			else
			{
				MessageBox.Show("kayıt başarısız tekrar deneyin");
			}


		}
	}
}
