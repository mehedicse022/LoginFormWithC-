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

namespace GHIT_LoginForm
{

   
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = WADEY; Initial Catalog = ghit; Integrated Security = True");

        public Form1()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)
        {

            try
            {

                // Update users table status to '0' if cancel

                string queryup = ("update users set status = '0' where status = '1' ");
                SqlDataAdapter cancel = new SqlDataAdapter(queryup, con);
                DataTable dtexit = new DataTable();
                cancel.Fill(dtexit);
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void login_Click(object sender, EventArgs e)
        {
            try
            {

                //con.Open();

                // Check Login username and password on users table

                string query = ("select * from users where username='" + this.username.Text + "' and password ='" + this.password.Text + "' ");
                SqlDataAdapter log = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                log.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    // update users table status and set to 1 .. if successfull 

                    string queryuplogin = ("update users set status='1' where status = '0' and username='" + this.username.Text + "' ");
                    SqlDataAdapter upd = new SqlDataAdapter(queryuplogin, con);

                    DataTable dtup = new DataTable();
                    upd.Fill(dtup);

                    // Show Message 

                    MessageBox.Show("Welcome to Apllication !!!");
                    Main window = new Main();
                    window.Show();

                }
                else
                {
                    MessageBox.Show("Please Check Your Username and Password ");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
