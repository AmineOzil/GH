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

namespace GH.Operations
{
    /// <summary>
    /// Interaction logic for Delete.xaml
    /// </summary>
    public partial class Delete : Window
    {
        public Delete()
        {
            InitializeComponent();
            try
            {
                SQLiteDatabase db = new SQLiteDatabase();

                DataTable Login;

                String query = "select name \"Name\", lastname \"lastname\", Lid \"Lid\",";

                query += "name \"name\", lastname \"lastname\", Lid \"Lid\"";

                query += "from Login;";

                Login = db.GetDataTable(query);

                List<string> UsersList = new List<string>();

                //Or looped through for some other reason
                foreach (DataRow r in Login.Rows)
                {

                    UsersList.Add(r["name"].ToString());


                }
                comboBox.ItemsSource = UsersList;
                comboBox.SelectedIndex = 0;

             
                
                
                 


            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
                MessageBox.Show(error);
                this.Close();
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var db = new SQLiteDatabase();

            String name = label.Content.ToString();

            db.Delete("Login", string.Format(" name = '{0}'", name));

       

        }
    }
}
