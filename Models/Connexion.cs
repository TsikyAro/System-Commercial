using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Systeme_Commerciale.Models
{
    public class Connexion
    {
        private SqlConnection connection;
        public Connexion(){
            string connectionString = "Server=ETU2035-ARO;Database=systemcom;Trusted_Connection=True;TrustServerCertificate=true;";
            SqlConnection connection = new SqlConnection(connectionString);
            this.connection = connection;
        }
        public SqlConnection connexion()
        {
            return this.connection;
        }
    }
}