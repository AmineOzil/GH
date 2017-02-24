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
    /// Interaction logic for Query.xaml
    /// </summary>
    public partial class Query : Window
    {
        public Query()
        {
            InitializeComponent();

            

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            try
            {
                SQLiteDatabase db = new SQLiteDatabase();

                DataTable Login;

                String query = "select name \"Name\", lastname \"lastname\",";

                query += "name \"name\", lastname \"last name\"";

                query += "from Login;";

                Login = db.GetDataTable(query);


                //Or looped through for some other reason
                foreach (DataRow r in Login.Rows)
                {

                    listBox.Items.Add(r["name"].ToString() +"   "+ r["lastname"].ToString());
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
