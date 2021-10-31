using System;
using System.Data;

using System.Data.SqlClient;

namespace AandelenBeheerData
{
    public class Rss
    {
        private string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        private SqlConnection GetDbConnectie()
        {
            return new SqlConnection(connectionString);
        }

        public void Bewaar(string titel, string auteur, string inhoud, string link, DateTime publicatieTijd)
        {
            string insertSqlText = "INSERT INTO Rss (Titel, Auteur, Inhoud, Link, Publicatietijd) " +
                                              "VALUES(@pTitel, @auteur, @inhoud, @link, @publicatieTijd)";
            SqlCommand insertSql = new SqlCommand(insertSqlText);
            insertSql.Connection = GetDbConnectie();
            insertSql.Parameters.Add(new SqlParameter("@pTitel", titel));
            insertSql.Parameters.Add(new SqlParameter("@auteur", auteur));
            insertSql.Parameters.Add(new SqlParameter("@inhoud", inhoud));
            insertSql.Parameters.Add(new SqlParameter("@link", link));
            insertSql.Parameters.Add(new SqlParameter("@publicatieTijd", publicatieTijd));
            try
            {
                insertSql.Connection.Open();
                int rowsAdded = insertSql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Bewaren van het RSS-record is mislukt." + ex.Message);
            }

            if (insertSql.Connection.State == ConnectionState.Open)
            {
                insertSql.Connection.Close();
            }
        }
    }
}
