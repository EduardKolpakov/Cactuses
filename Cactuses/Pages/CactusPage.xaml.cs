using Cactuses.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
    /// Логика взаимодействия для CactusPage.xaml
    /// </summary>
    public partial class CactusPage : Page
    {
        string rights;
        public CactusPage(string _rights)
        {
            InitializeComponent();
            ListCactuses.ItemsSource = ConnectionClass.db.Cactuses.ToList();
            rights = _rights;
        }

        public void Refresh()
        {
            ListCactuses.ItemsSource = null;
            ListCactuses.ItemsSource = ConnectionClass.db.Cactuses.ToList();
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
                var d = (sender as Button).DataContext as DB.Cactus;
                if (d != null)
                {
                    ConnectionClass.db.Cactuses.Remove(d);
                    ConnectionClass.db.SaveChanges();
                    Refresh();
                    MessageBox.Show($"Кактус {d.Sort} удален", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
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
            var a = (sender as Button).DataContext as DB.Cactus;
            NavigationService.Navigate(new CactusEdit(a, rights));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (rights != "admin")
            {
                MessageBox.Show("У вас нет прав администратора!");
                return;
            }
            NavigationService.Navigate(new CactusAdd(rights));
        }

        private void BtnExh_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ExhibitionsPage(rights));
        }
    }
}
