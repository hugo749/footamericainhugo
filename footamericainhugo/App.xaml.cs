﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using model.data;
using model.business;

namespace footamericainhugo
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        //déclarer ici les attributs de la class App
        //on viendra y déclarer notamement nos objets Dbal et Dao
        //au lancement de la solutio, Dbal et Dao seront donc instanciés et passés aux différentes fenêtres

        private dbal thedbal;
        private DAOpays thedaopays;
        private DAOpost thedaopost;
        private DAOequipe thedaoequipe;
        private DAOjoueur thedaojoueur;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //C'est ici, dans la méthode Application_Startup, qu'on instancie nos objets Dbal et Dao

            thedbal = new dbal("dsfootamericain");
            thedaopays = new DAOpays(thedbal);
            thedaopost = new DAOpost(thedbal, thedaopays);

            // Create the startup window
            //là, on lance la fenêtre souhaitée en instanciant la classe de notre fenêtre
            GestionFromages wnd = new GestionFromages(thedaopays, thedaofromage);
            //et on utilise la méthode Show() de notre objet fenêtre pour afficher la fenêtre
            //exemple: MainWindow lafenetre = new MainWindow(); (et on y passe en paramètre Dbal et Dao au besoin)
            wnd.Show();

        }

        //Méthode permettant d'afficher les exceptions non gérées (voir wpftutorial.com)
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }
    }
}