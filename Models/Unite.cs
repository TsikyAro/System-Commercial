using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Systeme_Commerciale.Models;

namespace System_Commercial.Models{
    public class Unite{
        int idUnite;
        string nomUnite;
        public Unite[] GetDonnee(Connexion c){
            
            List<Unite> Unites = new List<Unite>();
            SqlConnection con = c.connexion();
            con.Open();
            string sql = "SELECT * FROM Unite";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read()){
                Unite temp = new Unite(data.GetInt32(0),data.GetString(1));
                Unites.Add(temp);
            }
            con.Close();
            return Unites.ToArray();
        }

        public Unite(int id,string nom){
            this.idUnite=id;
            this.nomUnite = nom;
        }

        public Unite()
        {
        }

        public int IdUnite { get => idUnite; set => idUnite = value; }
        public string NomUnite { get => nomUnite; set => nomUnite = value; }
    }
}