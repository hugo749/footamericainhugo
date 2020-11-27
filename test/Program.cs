using System;
using MySql;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Collections;
using System.ComponentModel.Design;
using System.Data;
using MySqlX.XDevAPI.Relational;
using model.data;
using model.business;


namespace test
{
    public class Program
    {
        

        static void Main(string[] args)
        {
            dbal ledbal = new dbal();
            DAOpays dAOpays = new DAOpays(ledbal);
            DAOpost dAOpost = new DAOpost(ledbal); 
            DAOjoueur dAOjoueur = new DAOjoueur(ledbal, dAOpays,dAOpost);
            DAOequipe dAOequipe = new DAOequipe(ledbal, dAOjoueur);
            joueur unjoueur = dAOjoueur.SelectById(1);
            Console.WriteLine("<---------------------->");
            Console.WriteLine("joueur: " + unjoueur.Nom);

            joueur unjouer = dAOjoueur.SelectByName("Alain Ducret");
            Console.WriteLine("id: " + unjoueur.Id);
        }
    }
}
