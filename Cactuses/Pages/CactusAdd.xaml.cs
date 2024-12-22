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
    /// Логика взаимодействия для CactusAdd.xaml
    /// </summary>
    public partial class CactusAdd : Page
    {
        string rights;
        public CactusAdd(string _rights)
        {
            InitializeComponent();
            rights = _rights;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            DB.Cactus _cac = new DB.Cactus();
            _cac.Sort = TxtSort.Text;
            _cac.Age = TxtAge.Text;
            _cac.Cost = Convert.ToDecimal(TxtCost.Text);
            _cac.Origin = TxtOrigin.Text;
            _cac.Instruction = TxtInstr.Text;
            ConnectionClass.db.Cactuses.Add(_cac);
            ConnectionClass.db.SaveChanges();
            NavigationService.Navigate(new CactusPage(rights));
        }
    }
}
