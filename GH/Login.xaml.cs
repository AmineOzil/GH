using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;

namespace GH
{

    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window

    {

        public Login()
        {
            InitializeComponent();
           

        }


        private void button_Click(object sender, RoutedEventArgs e)
        {



            try
            {
                //Connect to Data Base
                SQLiteDatabase db = new SQLiteDatabase();

                //Data Table login that Have All Queries From DB
                DataTable Login;

                //Query to Get Username & Password and Compare them In Db if Found!
                String query = "select * from Login where username='" + this.UsernameInput.Text + "' and password='" + this.PasswordInput.Password + "'";

                //Put this information from DB to DataTable = login;
                Login = db.GetDataTable(query);

                //select grade,  username, password
                string grade = "select grade from Login where username='" + this.UsernameInput.Text + "' ";
                string user = "select username from Login where username='" + this.UsernameInput.Text + "' ";
                string pass = "select password from Login where password='" + this.PasswordInput.Password + "' ";

                //Assign (grade, username, password) to local variables (g, u, p)
                string g = db.ExecuteScalar(grade);
                string u = db.ExecuteScalar(user);
                string p = db.ExecuteScalar(pass);

                //Test if the inputs informations NOT Match to Database Informations

                if (this.UsernameInput.Text != u || this.PasswordInput.Password != p)
                {
                    MessageBox.Show("Fuck you TryCatch");
                    UsernameInput.Clear();
                    PasswordInput.Clear();
                    UsernameInput.Focus();
                    
                }
                else
                {
                    foreach (DataRow r in Login.Rows)
                    {
                        MessageBox.Show("WELCOME " + g + " " + UsernameInput.Text, "successful", MessageBoxButton.OK, MessageBoxImage.Information);
                        MainWindow admin = new MainWindow();
                        admin.Show();
                        this.Close();
                    }
                }

            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
                MessageBox.Show(error);
                this.Close();
            }



        }

        private void Dialog(object sender, DialogClosingEventArgs eventArgs)
        {


        }





        private void PasswordInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                button_Click(this, new RoutedEventArgs());
            }
        }

        private void UsernameInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                button_Click(this, new RoutedEventArgs());
            }
        }
    }
}
