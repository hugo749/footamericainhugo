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
    public class DAOpost
    {
        private dbal _dbal;
        

        public DAOpost(dbal mydbal)
        {
            this._dbal = mydbal;
            
        }

        //public void insert(post lefromage)
        //{

        //    string query = " fromage values " + "(" + lefromage.Id + "," + lefromage.Paysorigineid + ","+ lefromage.Nom + ","+lefromage.Creation+","+lefromage.Image+");";
        //    _dbal.Insert(query);
        //}

        //public void delete(post lefromage)
        //{
        //    string query = " FROM fromage where id = " + lefromage.Id + ";";
        //    _dbal.Delete(query);
        //}

        //public void update(post lefromage)
        //{
        //    string query = " fromage set nom = 'tome' where id = " + lefromage.Id + ";";
        //    _dbal.Update(query);
        //}




        //public void Insert(post unfromage)
        //{
        //    string query = " fromages (id, paysorigineid, nom, creation, image) VALUES (" + unfromage.Id + "," + unfromage.Paysorigineid.Id+"," + unfromage.Nom+","+ unfromage.Creation+",'"+unfromage.Image+  "' );";
        //    this._dbal.Insert(query);
        //}





        public List<post> SelectAll()
        {
            List<post> lespost = new List<post>();
            foreach (DataRow dl in _dbal.SelectAll("Poste").Rows)
            {
                lespost.Add(new post((int)dl["id"], (string)dl["nom"], (int)dl["escouade"]));
                Console.WriteLine(dl["id"] + " " + dl["nom"] + " " + dl["escouade"] );
            }
            return lespost;
        }

        public post SelectByName(string nompost)
        {
            DataRow nom = _dbal.SelectByField("Poste", "nom like '" + nompost + "'").Rows[0];
            post unpost = new post((int)nom["id"], (string)nom["nom"], (int)nom["escouade"]);
            Console.WriteLine(unpost.Id);

            return unpost;

        }

        public post SelectById(int idpost)
        {
            DataRow id = _dbal.SelectById("Poste", idpost);
            post idpo = new post((int)id["id"], (string)id["nom"], (int)id["escouade"]);
            Console.WriteLine(idpo.Nom);
            return idpo;
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