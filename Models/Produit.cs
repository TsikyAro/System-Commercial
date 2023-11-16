using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Systeme_Commerciale.Models;

namespace System_Commercial.Models
{
    public class Produit
    {
        int idProduit;
        string nomProduit;
        public Produit[] GetDonnee(Connexion c){
            List<Produit> Produits = new List<Produit>();
            SqlConnection con = c.connexion();
            con.Open();
            string sql = "SELECT * FROM Produit";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read()){
                Produit temp = new Produit(data.GetInt32(0),data.GetString(1));
                Produits.Add(temp);
            }
            con.Close();
            return Produits.ToArray();
        }

        public Produit(int id,string nom){
            this.idProduit=id;
            this.nomProduit = nom;
        }

        public Produit()
        {
        }

        public int IdProduit { get => idProduit; set => idProduit = value; }
        public string NomProduit { get => nomProduit; set => nomProduit = value; }
        
    }
}