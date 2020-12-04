using System;
using System.Collections.Generic;
using System.Text;
using model.business;
using model.data;

namespace model.business
{
    public class post
    {
        private int _id;
        private string _nom;
        private int _escouade;
        

        public post (int id=0, string nom="", int escouade=0 )
        {
            _id=id;
            _nom=nom;
            _escouade = escouade;
        }

        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public int Escouade { get => _escouade; set => _escouade = value; }

        public override string ToString()
        {
            return this.Nom;
        }
    }
    
}