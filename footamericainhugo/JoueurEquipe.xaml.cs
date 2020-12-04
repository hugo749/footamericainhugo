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
using model.data;
using model.business;


namespace VisionEquipe
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class JoueurEquipe : Window
    {
        public JoueurEquipe(DAOequipe thedaoequipe, DAOjoueur thedaojoueur, DAOpays thedaopays, DAOpost thedaopost)
        {
            InitializeComponent();
            Globale.DataContext = new viewModel.viewModelJoueur(thedaojoueur,thedaoequipe,thedaopays,thedaopost);
        }

        
    }
}
