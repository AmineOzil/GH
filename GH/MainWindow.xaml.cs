using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using System.Data.SQLite;
using GH.Operations;

namespace GH
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonQuery_Click(object sender, RoutedEventArgs e)
        {
            Query QueryWindow = new Query();
            QueryWindow.Show();
            
            
        }

        private void ButtonInsert_Click(object sender, RoutedEventArgs e)
        {
            Insert InsertWindow = new Insert();
            InsertWindow.Show();
            
            this.Close();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete DeleteWindow = new Delete();
            DeleteWindow.Show();
            this.Close();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Update UpdateWindow = new Update();
            UpdateWindow.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SQLiteDatabase db = new SQLiteDatabase();
            Dictionary<String, String> data = new Dictionary<String, String>();
            data.Add("name", "Mr Margo");
            data.Add("lastname", "hhhhhhhhh");
            data.Add("grade", "admin");
            data.Add("email", "mrgo@mergo.com");
            data.Add("username", "margo");
            data.Add("password", "margo");
            try
            {
                db.Insert("Login", data);
            }
            catch (Exception crap)
            {
                MessageBox.Show(crap.Message);
            }

        }

  
    }
}
