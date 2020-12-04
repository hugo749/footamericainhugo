using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using model.business;
using model.data;
using System.Windows;


namespace VisionEquipe.viewModel
{
    class viewModelJoueur : viewModelBase
    {
        //déclaration des attributs ...à compléter
        private DAOjoueur vmDAOjoueur;
        private DAOequipe vmDaoequipe;
        private ICommand updateCommand;
        private ObservableCollection<joueur> listjoueur;
        private ObservableCollection<equipe> listequipe;
        private ObservableCollection<pays> listpays;
        private ObservableCollection<post> listpost;
        private joueur selectedjoueur = new joueur();
        private post selectedpost = new post();
        private equipe selectedequipe = new equipe();
        


        //déclaration des listes...à compléter avec les fromages
        public ObservableCollection<joueur> Listjoueur { get => listjoueur; set => listjoueur = value; }
        public ObservableCollection<equipe> Listeequipe { get => listequipe; set => listequipe = value; }
        public ObservableCollection<pays> Listpays { get => listpays; set => listpays = value; }
        public ObservableCollection<post> Listepost { get => listpost; set => listpost = value; }
        //déclaration des propriétés avec OnPropertyChanged("nom_propriété_bindée")
        //par exemple...
        public string Nom
        {
            get => selectedjoueur.Nom;
            set
            {
                if (selectedjoueur.Nom != value)
                {
                   selectedjoueur.Nom = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    
                    OnPropertyChanged("Nom");
                }
            }
        }

        public DateTime DateEntre
        {
            get => selectedjoueur.DateEntree;
            set
            {
                if (selectedjoueur.DateEntree!=value)
                {
                    selectedjoueur.DateEntree = value;
                    OnPropertyChanged("DateE");
                }
            }
        }
        


        public post Unpost
        {
            get => selectedjoueur.Unpost;
            set
            {
                if (selectedjoueur.Unpost!=value)
                {
                    selectedjoueur.Unpost = value;
                    OnPropertyChanged("Post");
                }
            }
        }


        public DateTime DDN
        {
            get => selectedjoueur.DDN;
            set
            {
                if (selectedjoueur.DDN!=value)
                {
                    selectedjoueur.DDN = value;
                    OnPropertyChanged("DDN");
                }
            }
        }


        public pays Origin
        {
            get => selectedjoueur.Unpays;
            set
            {
                if (selectedjoueur.Unpays != value)
                {
                    selectedjoueur.Unpays = value;
                    OnPropertyChanged("Origin");

                }
            }
        }



        public joueur Selectedjoueur
        {
            get => selectedjoueur;
            set
            {
                if (selectedjoueur!=value)
                {
                    selectedjoueur = value;
                    
                    OnPropertyChanged("Post");
                    OnPropertyChanged("Origin");
                    OnPropertyChanged("DDN");
                    OnPropertyChanged("Nom");
                    OnPropertyChanged("DateE");

                }
            }
        }



        //déclaration du contructeur de viewModelFromage
        public viewModelJoueur(DAOjoueur thedaojoueur, DAOequipe thedaoequipe, DAOpays thedaopays, DAOpost thedaopost)
        {
            vmDaoequipe = thedaoequipe;
            vmDAOjoueur = thedaojoueur;

            Listeequipe = new ObservableCollection<equipe>(thedaoequipe.SelectAll());
            listjoueur = new ObservableCollection<joueur>(thedaojoueur.SelectAll());
            listpays = new ObservableCollection<pays>(thedaopays.SelectAll());
            listpost = new ObservableCollection<post>(thedaopost.SelectAll());

            //foreach (Fromage lefromage in ListFromages)
            //{
            //    foreach (Pays lepays in ListPays)
            //    {
            //        if (lefromage.Origin.Id == lepays.Id)
            //        {
            //            lefromage.Origin = lepays;

            //        }
            //    }
            //}

            //foreach (joueur unjoueur in listjoueur)//elle va chercher dans la fromage (liste de droite du wpf)
            //{
            //   int i = 0;//i est à 0 ce qui va nous permettrent de chercher les id
            //   while (unjoueur.Unpays != listpays[i].Id)//le while nous permet de faire une boucle qui ne va pas s'arreter tant que l'id de fromage ne sera pas = à l'id de la liste pays à gauche 
            //    {
            //        i++;//va faire le tour de tous les id de la liste pays (gauche)
            //    }
            //    unjoueur.Unpays = listpays[i];//sors de la boucle quand les id sont les mêmes puis affiche dans origin le puis souhaité
            //}

        }

        //Méthode appelée au click du bouton UpdateCommand
        public ICommand UpdateCommand
        {
            get
            {
                if (this.updateCommand == null)
                {
                    this.updateCommand = new RelayCommand(() => Updatejoueur(), () => true);
                }
                return this.updateCommand;

            }

        }

        private void Updatejoueur()
        {
            //code du bouton - à coder
            this.vmDAOjoueur.update(this.selectedjoueur);
            MessageBox.Show("MAJ à été accepté avec succés","MISE A JOUR");
            //listFromages = (ObservableCollection<Fromage>)vmDAOfromage.SelectAll();
            int place = Listjoueur.IndexOf(selectedjoueur);
            Listjoueur.Remove(selectedjoueur);
            listjoueur.Insert(index: place , selectedjoueur); 

        }

        

        

    }
}
