using System;
using System.Collections.Generic;
using System.Data;
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
using System.Data.SQLite;

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
                var db = new SQLiteDatabase();
            DataTable recipe;

            String query = "select * from Login where username='" + this.textbox_username.Text + "' and password='" + this.passwordBox_password.Password + "'";
            recipe = db.GetDataTable(query);
            //select grade 
            string que = "select grade from Login where username='" + this.textbox_username.Text + "' ";
            string grade = db.ExecuteScalar(que);


                foreach (DataRow r in recipe.Rows)
            {
                MessageBox.Show("WELCOME "+grade+" "+ textbox_username.Text, "successful", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow admin = new MainWindow();
                admin.Show();
                this.Close();
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
    }
}
