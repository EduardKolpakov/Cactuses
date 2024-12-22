using Cactuses.DB;
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

namespace Cactuses.Pages
{
    /// <summary>
    /// Логика взаимодействия для ExhibitionsPage.xaml
    /// </summary>
    public partial class ExhibitionsPage : Page
    {
        string rights;
        public ExhibitionsPage(string _rights)
        {
            InitializeComponent();
            ListCactuses.ItemsSource = ConnectionClass.db.Cactuses_Exhibitions.ToList();
            rights = _rights;
        }

        private void Refresh()
        {
            ListCactuses.ItemsSource = null;
            ListCactuses.ItemsSource = ConnectionClass.db.Cactuses_Exhibitions.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (rights != "admin")
            {
                MessageBox.Show("У вас нет прав администратора!");
                return;
            }
            NavigationService.Navigate(new ExhibitionsAdd(rights));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CactusPage(rights));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (rights != "admin")
            {
                MessageBox.Show("У вас нет прав администратора!");
                return;
            }
            if (MessageBox.Show("Удалить?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                var d = (sender as Button).DataContext as DB.Cactuses_Exhibitions;
                if (d != null)
                {
                    Exhibition ex = ConnectionClass.db.Exhibitions.Where(x => x.ID == d.ExhibitionID).FirstOrDefault();
                    ConnectionClass.db.Exhibitions.Remove(ex);
                    ConnectionClass.db.SaveChanges();
                    Refresh();
                    MessageBox.Show($"Выставка удалена!", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (rights != "admin")
            {
                MessageBox.Show("У вас нет прав администратора!");
                return;
            }
            var h = (sender as Button).DataContext as Cactuses_Exhibitions;
            NavigationService.Navigate(new ExhibitionsEdit(rights, h));
        }
    }
}
