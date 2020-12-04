using System;
using System.Collections.Generic;
using System.Text;
using model.business;
using model.data;

namespace model.business
{
    public class equipe
    {
        private int _id;
        private string _nom;
        private DateTime _creation;
        public List<joueur> _listjoueur;


        public equipe(int id = 0, string nom = "", DateTime creation = new DateTime())
        {
            _id=id;
            _nom=nom;
            _creation = creation;
            _listjoueur = new List<joueur>();

        }

        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public DateTime Creation { get => _creation; set => _creation = value; }
        public List<joueur> Listjoueur { get => _listjoueur; set => _listjoueur = value; }



        public override string ToString()
        {
            return this.Nom;
        }
    }

    

}