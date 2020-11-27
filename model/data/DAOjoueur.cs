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
    public class DAOjoueur
    {
        private dbal _dbal;
        private DAOpays _pays;
        private DAOpost _post;


        public DAOjoueur(dbal mydbal, DAOpays pays, DAOpost post )
        {
            this._dbal = mydbal;
            this._pays = pays;
            this._post = post;
            
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





        public List<joueur> SelectAll()
        {
            List<joueur> lesjoueurs = new List<joueur>();
            foreach (DataRow dl in _dbal.SelectAll("joueur").Rows)
            {
                lesjoueurs.Add(new joueur((int)dl["id"],(string)dl["nom"],(DateTime)dl["dateEntree"], (DateTime)dl["DDN"],(pays)dl["id"],(post)dl["id"]));
                //Console.WriteLine(dl["id"] + " " + dl["nom"] + " " + dl["dateEntree"] +" " +dl["DDN"] +" " +dl["id"] + " "+ dl["id"]);
            }
            return lesjoueurs;
        }

        public joueur SelectByName(string nomjoueur)
        {
            
            DataRow nom = _dbal.SelectByField("joueur", "nom like '" + nomjoueur + "'").Rows[0];
            pays lepays = this._pays.SelectById((int)nom["id"]);
            post lepost = this._post.SelectById((int)nom["id"]);
            joueur unjoueur = new joueur((int)nom["id"], (string)nom["nom"], (DateTime)nom["dateEntree"], (DateTime)nom["DDN"], lepays, lepost);
            

            return unjoueur;

        }

        public joueur SelectById(int idjoueur)
        {
            DataRow id = _dbal.SelectById("joueur", idjoueur);
            pays lepays = this._pays.SelectById((int)id["id"]);
            post lepost = this._post.SelectById((int)id["id"]);
            joueur idj = new joueur((int)id["id"], (string)id["nom"], (DateTime)id["dateEntree"], (DateTime)id["DDN"], lepays,lepost );
            
            return idj;
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