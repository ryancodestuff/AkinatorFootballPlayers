using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;

namespace AkinatorAI
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Connection connect = new Connection();
            Compare obj = new Compare();
            Update update = new Update();
            Program pr = new Program();
            pr.setAvoid();
            SqlDataReader de = connect.DataReader("DROP TABLE IF EXISTS footballPlayers");
            SqlDataReader dr = connect.DataReader("SELECT *\r\nINTO footballPlayers\r\nFROM footballPlayersMain;");
            string query = "SELECT COUNT(*) FROM footballPlayers";
            int max = Convert.ToInt32(connect.getDataSet(query).Tables[0].Rows[0][0]);
            while(true)
            {
                Console.Clear();
                obj.compare();
                max = Convert.ToInt32(connect.getDataSet(query).Tables[0].Rows[0][0]);
                
                if(max<200)
                {
                    query = "select top 1 long_name from footballPlayers order by value_eur desc;";
                    string name = connect.getDataSet(query).Tables[0].Rows[0]["long_name"].ToString();
                    Console.WriteLine(" IS YOUR PLAYER " + name +" (Yy/Nn)");
                    string answer = Console.ReadLine();
                    if(answer == "Y" || answer == "y")
                    {
                        Environment.Exit(0);
                    }
                }
            }
            SqlDataReader ds = connect.DataReader("DROP TABLE IF EXISTS footballPlayers;");
        }

        public void setAvoid()
        {
            Connection obj = new Connection();
            string query = "UPDATE Avoid SET avoid3 = 100;";
            obj.DataReader(query);
            query = "UPDATE Avoid SET avoid2 = 100;";
            obj.DataReader(query);
            query = "UPDATE Avoid SET avoid4 = 100;";
            obj.DataReader(query);
            query = "UPDATE Avoid SET avoid5 = 100;";
            obj.DataReader(query);
            query = "UPDATE Avoid SET avoid1 = 100;";
            obj.DataReader(query);

            query = "UPDATE DeleteCol SET delete1 = 100;";
            obj.DataReader(query);
            query = "UPDATE DeleteCol SET delete2 = 100;";
            obj.DataReader(query);
            query = "UPDATE DeleteCol SET delete3 = 100;";
            obj.DataReader(query);
            query = "UPDATE DeleteCol SET delete4 = 100;";
            obj.DataReader(query);
            query = "UPDATE DeleteCol SET delete5 = 100;";
            obj.DataReader(query);
        }
       
    }
}
