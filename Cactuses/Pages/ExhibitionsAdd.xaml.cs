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
using Cactuses.DB;

namespace Cactuses.Pages
{
    /// <summary>
    /// Логика взаимодействия для ExhibitionsAdd.xaml
    /// </summary>
    public partial class ExhibitionsAdd : Page
    {
        string rights;
        public ExhibitionsAdd(string _rights)
        {
            InitializeComponent();
            rights = _rights;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Exhibition ex = new Exhibition();
            ex.Date = DateA.SelectedDate;
            ex.Address = TxtAddress.Text;
            ex.Awards = TxtAwards.Text;
            ex.Commentaries = TxtComm.Text;
            ConnectionClass.db.Exhibitions.Add(ex);
            Cactuses_Exhibitions CE = new Cactuses_Exhibitions();
            CE.ExhibitionID = ex.ID;
            string sor = Selection_Cactus.SelectedValue.ToString();
            Cactus c = ConnectionClass.db.Cactuses.Where(x => x.Sort == sor).FirstOrDefault();
            CE.CactusID = c.ID;
            ConnectionClass.db.Cactuses_Exhibitions.Add(CE);
            ConnectionClass.db.SaveChanges();
            NavigationService.Navigate(new ExhibitionsPage(rights));
        }

        private void Selection_Cactus_Initialized(object sender, EventArgs e)
        {
            List<Cactus> cacs = ConnectionClass.db.Cactuses.ToList();
            foreach (Cactus c in cacs)
            {
                Selection_Cactus.Items.Add(c.Sort);
            }
        }
    }
}
