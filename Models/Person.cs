using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using OfficeOpenXml;

namespace Systeme_Commerciale.Models
{
   public class Person{
        public int IdPerson { get; set; }
        public string NomPerson { get; set; }
        public int Ages { get; set; }
        public void Insert(Connexion c){
            SqlConnection con = c.connexion();
            con.Open();
            string sql = "INSERT INTO Person (nomPerson,ages) VALUES (@nomPerson,@ages)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@nomPerson",NomPerson);
            cmd.Parameters.AddWithValue("@ages",Ages);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void ImportDataFromExcel(string filePath,Connexion c)
        {
            SqlConnection connection = c.connexion();
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                int numberOfWorksheets = package.Workbook.Worksheets.Count;
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    connection.Open();

                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        string name = worksheet.Cells[row, 1].Text;
                        int age = int.Parse(worksheet.Cells[row, 2].Text);

                        using (SqlCommand command = new SqlCommand("INSERT INTO Person (nomPerson,ages) VALUES (@nomPerson,@ages)", connection))
                        {
                            command.Parameters.AddWithValue("@nomPerson", name);
                            command.Parameters.AddWithValue("@ages", age);
                            command.ExecuteNonQuery();
                        }
                    }

                connection.Close();

               
            }
        }
    }
}