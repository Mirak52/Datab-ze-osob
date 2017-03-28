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

namespace Databáze_osob
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///       
    public partial class MainWindow : Window
    {
        public bool decision = true;
        public int test = 0;
        public MainWindow()
        {
            InitializeComponent();
/*
            Osoby item = new Osoby();
            item.FirstName = "item";
            item.LastName = "item text";
            item.Done = 0;
            Database.SaveItemAsync(item);
            */
            
            ///   var itemsFromDb = Database.GetItemsAsync().Result;
           var itemsFromDb = Database.GetItemsNotDoneAsync().Result;
            /* Psaní textu do debug tabulky
           Debug.WriteLine("                             ");
           Debug.WriteLine("                             ");
           Debug.WriteLine("                             ");

           Debug.WriteLine(itemsFromDb.Count);
           foreach (TodoItem todoItem in itemsFromDb)
           {
               Debug.WriteLine(todoItem);
           }

           Debug.WriteLine("                             ");
           Debug.WriteLine("                             ");
           Debug.WriteLine("                             ");
              */

            ItemsCount.Content = "Items in Database " + itemsFromDb.Count;
            ToDoItemsListView.ItemsSource = itemsFromDb;
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

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            var itemsFromDb = Database.GetItemsNotDoneAsync().Result;
            Database.QueryCustom();
            ToDoItemsListView.ItemsSource = itemsFromDb;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            /*  Osoby item = new Osoby();
              item.Name = "Vojtosaurus";
              item.Text = textBox.Text;
              item.Done = 0;
              Database.SaveItemAsync(item);
          */
            
            if (string.IsNullOrEmpty(FirstName.Text) & string.IsNullOrEmpty(LastName.Text) &
                string.IsNullOrEmpty(LifeNumber.Text))
            {
                Text.Content = "Zadej data správně";
                            
            }
            else
            {
                double num;
                if (double.TryParse(LifeNumber.Text, out num))
                {
                    Osoby item = new Osoby();
                    item.FirstName = FirstName.Text;
                    item.LastName = LastName.Text;
                    item.LifeNumber = LifeNumber.Text;
                    DateTime datumCas = DateTime.Now;
                    item.Date = datumCas;

                    item.Sex = Man.Content.ToString();
                    item.Done = 0;
                    Database.SaveItemAsync(item);
                    var itemsFromDb = Database.GetItemsNotDoneAsync().Result;
                    
                    ItemsCount.Content = "Items in Database " + itemsFromDb.Count;
                    ToDoItemsListView.ItemsSource = itemsFromDb;
                    Text.Content = "Uloženo";
                }
                else
                {
                    Text.Content = "LifeNumber inst number";
                }
            }
        }
        private void click(object sender, SelectionChangedEventArgs e)
        {
            Osoby osoba = (Osoby)ToDoItemsListView.SelectedItems[0];
            //textBox.Text = osoba.Text;
            Detail customization = new Detail(osoba);
            customization.Show();
            this.Close();

        }
        private void FirstName_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (decision)
            {
                FirstName.Text = "";
                decision = false;
            }
            else
            { decision = true; }
        }

        private void LastName_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (decision)
            {
                LastName.Text = "";
                decision = false;
            }
            else
            { decision = true; }
        }

        private void LifeNumber_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (decision)
            {
                LifeNumber.Text = "";
                decision = false;
            }
            else
            { decision = true; }
        }

     
    }
}
