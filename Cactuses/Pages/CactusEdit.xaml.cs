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
    /// Логика взаимодействия для CactusEdit.xaml
    /// </summary>
    public partial class CactusEdit : Page
    {
        DB.Cactus _cactus;
        string rights;
        public CactusEdit(DB.Cactus cactus, string _rights)
        {
            InitializeComponent();
            _cactus = cactus;
            TxtSort.Text = _cactus.Sort;
            TxtAge.Text = _cactus.Age;
            TxtCost.Text = _cactus.Cost.ToString();
            TxtOrigin.Text = _cactus.Origin;
            TxtInstr.Text = _cactus.Instruction;
            rights = _rights;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var a = ConnectionClass.db.Cactuses.Where(z => z.ID == _cactus.ID).FirstOrDefault();
            a.Sort = TxtSort.Text;
            a.Age = TxtAge.Text;
            a.Cost = Convert.ToDecimal(TxtCost.Text);
            a.Origin = TxtOrigin.Text;
            a.Instruction = TxtInstr.Text;
            ConnectionClass.db.SaveChanges();
            NavigationService.Navigate(new CactusPage(rights));
        }
    }
}
