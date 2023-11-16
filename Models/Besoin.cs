using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using OfficeOpenXml;
using Systeme_Commerciale.Models;

namespace System_Commercial.Models{
    public class Besoin{
        int idDemande;
        string? nomProduit;
        double quantite;
        string? nomUnite;
        int idDepartement;
        string? nomDepartement;
        DateTime dateDemande;
        int etat;
        public Besoin(){}
        public Besoin(string? nomProduit,double quantite, string? nomUnite){
            this.nomUnite = nomUnite;
            this.quantite = quantite;
            this.nomProduit = nomProduit;
        }
        public void exel(Besoin [] besoins){
            string excelFilePath = "D:\\ITU\\s5\\Mr Tovo\\System-Commercial\\uploads\\ProformatClients.xlsx";
                using (var package = new ExcelPackage())
                {
                    // Ajouter une feuille de calcul au fichier Excel
                    var worksheet = package.Workbook.Worksheets.Add("Feuille1");
                    // Ajouter des données à la feuille de calcul
                    worksheet.Cells["A1"].Value = "Produit";
                    worksheet.Cells["B1"].Value = "Quantite";
                    worksheet.Cells["C1"].Value = "Unite";
                    // Exemple de données
                    int j = 2;
                    for(int i=0; i<besoins.Length; i++){
                        j = i+j;
                        worksheet.Cells["A"+j].Value = besoins[i].NomProduit;
                        worksheet.Cells["B"+j].Value = besoins[i].Quantite;
                        worksheet.Cells["C"+j].Value = besoins[i].NomUnite;

                    }
                    // Enregistrer le fichier Excel
                    File.WriteAllBytes(excelFilePath, package.GetAsByteArray());
                }
        }
        public Besoin[] GetService(Connexion c){
            List<Besoin> Besoins = new List<Besoin>();
            SqlConnection con = c.connexion();
            con.Open();
            string sql = "select nomProduit,sum(quantite) quantite,nomunite from besoin where etat = 2 group by nomProduit,nomunite; ";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read()){
                Besoin temp = new Besoin(data.GetString(0),data.GetDouble(1),data.GetString(2));
                Besoins.Add(temp);
            }
            con.Close();
            return Besoins.ToArray();
        }
        public Besoin[] GetAllDonnee(Connexion c){
            List<Besoin> Besoins = new List<Besoin>();
            SqlConnection con = c.connexion();
            con.Open();
            string sql = "SELECT * FROM Besoin ";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read()){
                Besoin temp = new Besoin(data.GetInt32(0),data.GetString(1),data.GetDouble(2),data.GetString(3),data.GetInt32(4),data.GetString(5),data.GetDateTime(6),data.GetInt32(7));
                Besoins.Add(temp);
            }
            con.Close();
            return Besoins.ToArray();
        }

        public Besoin[] GetDonnee(Connexion c,int idDepartement){
            List<Besoin> Besoins = new List<Besoin>();
            SqlConnection con = c.connexion();
            con.Open();
            string sql = $"SELECT * FROM Besoin where idDepartement = {idDepartement}";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader data = command.ExecuteReader();
            while (data.Read()){
                Besoin temp = new Besoin(data.GetInt32(0),data.GetString(1),data.GetDouble(2),data.GetString(3),data.GetInt32(4),data.GetString(5),data.GetDateTime(6),data.GetInt32(7));
                Besoins.Add(temp);
            }
            con.Close();
            return Besoins.ToArray();
        }
        public Besoin(int idDemande,string? nomProduit,double quantite,string? nomUnite,int idDepartement,string? nomDepartement,DateTime dateDemande,int etat){
            this.idDemande = idDemande;
            this.nomProduit = nomProduit;
            this.quantite = quantite;
            this.NomUnite = nomUnite;
            this.idDepartement = idDepartement;
            this.nomDepartement = nomDepartement;
            this.dateDemande = dateDemande;
            this.etat = etat;
        }

        public int IdDemande { get => idDemande; set => idDemande = value; }
        public string? NomProduit { get => nomProduit; set => nomProduit = value; }
        public double Quantite { get => quantite; set => quantite = value; }
        public string? NomUnite { get => nomUnite; set => nomUnite = value; }
        public int IdDepartement { get => idDepartement; set => idDepartement = value; }
        public string? NomDepartement { get => nomDepartement; set => nomDepartement = value; }
        public DateTime DateDemande { get => dateDemande; set => dateDemande = value; }
        public int Etat { get => etat; set => etat = value; }
    }
}