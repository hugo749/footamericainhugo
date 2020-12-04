using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using model.business;
using model.data;
using System.Data;

using System.Globalization;


namespace model.data
{
    public class DAOequipe
    {
        private dbal _dbal;
        private DAOjoueur _daojoueur;

        public DAOequipe(dbal mydbal, DAOjoueur mydaojoueur)
        {
            this._dbal = mydbal;
            this._daojoueur = mydaojoueur;
        }

        //public void insert(equipe unequipe)
        //{

        //    string query = " Equipe values " + "(" + unequipe.Id + "," + unequipe.Nom + ","+ unequipe.Creation + ","+unequipe.Listjoueur+");";
        //    _dbal.Insert(query);
        //}

        //public void delete(equipe unequipe)
        //{
        //    string query = " FROM equipe where id = " + unequipe.Id + ";";
        //    _dbal.Delete(query);
        //}

        //public void update(equipe unequipe)
        //{
        //    string query = " equipe set nom = 'France' where id = " + unequipe.Id + ";";
        //    _dbal.Update(query);
        //}




        //public void Insert(equipe unequipe)
        //{
        //    string query = " Equipe (id, nom, datecreation,) VALUES (" + unfromage.Id + "," + unfromage.Paysorigineid.Id+"," + unfromage.Nom+","+ unfromage.Creation+",'"+unfromage.Image+  "' );";
        //    this._dbal.Insert(query);
        //}





        public List<equipe> SelectAll()
        {
            List<equipe> unequipe = new List<equipe>();
            DataTable mytable = this._dbal.SelectAll("Equipe");
            foreach (DataRow dl in mytable.Rows)
            {
                unequipe.Add(new equipe((int)dl["id"], (string)dl["nom"],(DateTime)dl["dateCreation"]));
               
            }
            return unequipe;
        }

        public equipe SelectByName(string nomequipe)
        {
            DataRow nom = _dbal.SelectByField("Equipe", "nom like '" + nomequipe + "'").Rows[0];
            equipe uneequipe = new equipe((int)nom["id"], (string)nom["nom"], (DateTime)nom["dateCreation"]);
            Console.WriteLine(uneequipe.Id);

            return uneequipe;

        }

        public equipe SelectById(int idequipe)
        {
            DataRow equipe = _dbal.SelectById("equipe", idequipe);
            equipe lequipe = new equipe((int)equipe["id"], (string)equipe["nom"], (DateTime)equipe["dateCreation"]);
            Console.WriteLine(lequipe.Nom);
            return lequipe;
        }


        //public void InsertByFile(string Chemin)
        //{
        //    using (var reader = new StreamReader(Chemin))
        //    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //    {
        //        csv.Configuration.Delimiter = ";";
        //        csv.Configuration.RegisterClassMap<MapFromage>();

        //        csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
        //        var record = new fromage();
        //        var records = csv.EnumerateRecords(record);
        //        foreach (fromage unfromage in records)
        //        {
        //            insert(unfromage);
        //        }
        //    }
        //}
    }
}