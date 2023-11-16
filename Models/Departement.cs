using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Systeme_Commerciale.Models;

namespace System_Commercial.Models
{
    public class Departement
    {
        int idDepartement;
        string nomDepartement;
        public Departement[] GetDonnee(Connexion c){
            List<Departement> Departements = new List<Departement>();
            SqlConnection con = c.connexion();
            con.Open();
            string sql = "SELECT * FROM Departement";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read()){
                Departement temp = new Departement(data.GetInt32(0),data.GetString(1));
                Departements.Add(temp);
            }
            con.Close();
            return Departements.ToArray();
        }

        public Departement(int id,string nom){
            this.idDepartement=id;
            this.nomDepartement = nom;
        }

        public Departement()
        {
        }

        public int IdDepartement { get => idDepartement; set => idDepartement = value; }
        public string NomDepartement { get => nomDepartement; set => nomDepartement = value; } 
    }
}