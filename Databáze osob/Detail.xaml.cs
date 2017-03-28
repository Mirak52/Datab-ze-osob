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
using System.Windows.Shapes;

namespace Databáze_osob
{
    /// <summary>
    /// Interakční logika pro Detail.xaml
    /// </summary>
    public partial class Detail : Window
    {
        public int test = 0;
        public int test1 = 0;
        private Osoby _osoba;
        public Detail(Osoby osoba)
        {
            InitializeComponent();
            detail.Content = "ID: "+ osoba.ID + " Jméno: "+ osoba.FirstName + " Přijmení: " + osoba.LastName + " Datum vytvoření " + osoba.Date;
            this._osoba = osoba;

        }
        public static OsobyDatabase _database;

        public static OsobyDatabase Database
        {
            get
            {
                if (_database == null)
                {
                   

                    var fileHelper = new FileHelper();
                    _database = new OsobyDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _database;
            }
        }
        private void change_Click(object sender, RoutedEventArgs e)
        {
            Osoby item = new Osoby();
            item.ID = _osoba.ID;
            item.FirstName = namech.Text;
            item.LastName = textch.Text;
            Database.SaveItemAsync(item);
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {

            detail.Content = _osoba.ID;
            Database.QueryCustomID(_osoba.ID);
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow customization = new MainWindow();
            customization.Show();
            this.Close();
        }
        private void enter(object sender, MouseButtonEventArgs e)
        {
            if (test == 0)
            {
                namech.Text = "";
                test = 1;
            }
        }
        private void enter1(object sender, MouseButtonEventArgs e)
        {
            if (test1 == 0)
            {
                textch.Text = "";
                test = 1;
            }
        }

    }
}
