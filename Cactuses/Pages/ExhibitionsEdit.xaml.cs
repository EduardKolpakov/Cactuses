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
    /// Логика взаимодействия для ExhibitionsEdit.xaml
    /// </summary>
    public partial class ExhibitionsEdit : Page
    {
        string rights;
        Exhibition hib;
        Cactuses_Exhibitions CE;
        public ExhibitionsEdit(string _rights, Cactuses_Exhibitions h)
        {
            CE = h;
            hib = ConnectionClass.db.Exhibitions.Where(x => x.ID == h.ExhibitionID).FirstOrDefault();
            Cactus ca = ConnectionClass.db.Cactuses.Where(x => x.ID == h.CactusID).FirstOrDefault();
            InitializeComponent();
            rights = _rights;
            DateA.DisplayDate = Convert.ToDateTime(hib.Date);
            TxtAddress.Text = Convert.ToString(hib.Address);
            TxtAwards.Text = Convert.ToString(hib.Awards);
            TxtComm.Text = Convert.ToString(hib.Commentaries);
            Selection_Cactus.SelectedValue = ca.Sort;
        }

        private void Selection_Cactus_Initialized(object sender, EventArgs e)
        {
            List<Cactus> cacs = ConnectionClass.db.Cactuses.ToList();
            foreach (Cactus c in cacs)
            {
                Selection_Cactus.Items.Add(c.Sort);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Cactus cact = ConnectionClass.db.Cactuses.Where(x => x.Sort == Selection_Cactus.SelectedValue.ToString()).FirstOrDefault();
            hib.Date = DateA.DisplayDate;
            hib.Awards = TxtAwards.Text;
            hib.Address = TxtAddress.Text;
            hib.Commentaries = TxtComm.Text;
            CE.CactusID = cact.ID;
            ConnectionClass.db.SaveChanges();
            NavigationService.Navigate(new ExhibitionsPage(rights));

        }
    }
}
