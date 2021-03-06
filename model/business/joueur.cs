using System;
using System.Collections.Generic;
using System.Text;
using model.business;
using model.data;


namespace model.business
{
    public class joueur
    {
        private int _id;
        private string _nom;
        private DateTime _dateEntree;
        private DateTime _ddn;
        private pays _unpays;
        private post _unpost;

        public joueur(int id = 0, string nom = "", DateTime DateEntree = new DateTime(), DateTime uneddn = new DateTime(), pays lepays=null, post lepost=null)
        {
            _id=id;
            _nom=nom;
            _dateEntree = DateEntree;
            _ddn = uneddn;
            _unpays = lepays;
            _unpost = lepost;
        }

        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public DateTime DateEntree { get => _dateEntree; set => _dateEntree = value; }
        public DateTime DDN { get => _ddn; set => _ddn = value; }
        public pays Unpays { get => _unpays; set => _unpays = value; }
        public post Unpost { get => _unpost; set => _unpost = value; }


        public override string ToString()
        {
            return this.Nom;
        }
    }
    
}