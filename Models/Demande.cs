using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Systeme_Commerciale.Models;

namespace System_Commercial.Models
{
    public class Demande{
        int idDemande;
        int idProduit;
        double quantite;
        int unite;
        int idDepartement;
        DateTime dateDemande;
        int etat=0;
        public Demande(){}
        public Demande(int idProduit,double quantite,int unite, int iddepartement,DateTime date){
            this.idProduit = idProduit;
            this.quantite = quantite;
            this.unite = unite;
            this.idDepartement = iddepartement;
            this.dateDemande = date;
        }
        public void Insert(Connexion c){
            SqlConnection con = c.connexion();
            con.Open();
            string sql = "INSERT INTO Demande (idproduit,quantite,unite,idDepartement,dateDemande,etat) VALUES (@idproduit, @quantite, @unite, @idDepartement,@dateDemande,@etat)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@idproduit",IdProduit );
            cmd.Parameters.AddWithValue("@quantite",Quantite);
            cmd.Parameters.AddWithValue("@unite",Unite);
            cmd.Parameters.AddWithValue("@idDepartement",IdDepartement);
            cmd.Parameters.AddWithValue("@dateDemande",DateDemande);
            cmd.Parameters.AddWithValue("@etat",Etat);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Update(Connexion c,int idDemande,int etat){
            SqlConnection con = c.connexion();
            con.Open();
            string sql = $"UPDATE demande set etat = {etat} where idDemande={idDemande}";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public int IdDemande { get => idDemande; set => idDemande = value; }
        public int IdProduit { get => idProduit; set => idProduit = value; }
        public double Quantite { get => quantite; set => quantite = value; }
        public int Unite { get => unite; set => unite = value; }
        public int IdDepartement { get => idDepartement; set => idDepartement = value; }
        public DateTime DateDemande { get => dateDemande; set => dateDemande = value; }
        public int Etat { get => etat; set => etat = value; }
    }
}