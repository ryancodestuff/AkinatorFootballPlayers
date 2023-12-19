using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AkinatorAI
{
    internal class Connection
    {
        private static string conString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ryan\\Documents\\male_players_football.mdf;Integrated Security=True;Connect Timeout=30";
        private static SqlConnection conToDB;

        public DataSet getDataSet(string query) {
            DataSet dataSet = new DataSet();
            using (conToDB = new SqlConnection(conString))
            {
                conToDB.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, conToDB);
                adapter.Fill(dataSet);
                conToDB.Close();
            }
            return dataSet;

        }

        public SqlDataReader DataReader(string Query_)
        {
            //the data reader works with SQL connection so when writing the query it can connect the database with the back-end 
            using (conToDB = new SqlConnection(conString))
            {
                conToDB.Open();
                SqlCommand cmd = new SqlCommand(Query_, conToDB);
                SqlDataReader dr = cmd.ExecuteReader();

                conToDB.Close();
                return dr;
            }

        }
    }
}
