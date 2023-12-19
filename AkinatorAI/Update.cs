using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinatorAI
{
    internal class Update
    {
        public void updateAge(int choice)
        {
            int upper = 0;
            int lower = 0;
            Connection obj = new Connection();
            string query = "SELECT COUNT(age) AS COUNT FROM footballPlayers WHERE age<=20";
            int age20 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            query = "SELECT COUNT(age) AS COUNT FROM footballPlayers WHERE age>20 AND age<=30";
            int age30 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            query = "SELECT COUNT(age) AS COUNT FROM footballPlayers WHERE age>30";
            int age40 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            int max = Math.Max(Math.Max(age20, age30), age40);
            if (age20 == max)
            {
                upper = 20;
                lower = 0;
            }
            else if (age30 == max)
            {
                upper = 30;
                lower = 20;
            }
            else
            {
                upper = 100;
                lower = 30;
            }

            if (choice == 1)
            {
                query = "DELETE FROM footballPlayers WHERE age<=" + lower + ";\r\nDELETE FROM footballPlayers WHERE age>" + upper + ";";
                obj.DataReader(query);
                //query = "ALTER TABLE footballPlayers DROP COLUMN age;";
                //obj.DataReader(query);
                updateDelete(0);
            }
            else
            {
                query = "DELETE FROM footballPlayers WHERE age<=" + upper + " AND age>" + lower;
                obj.DataReader(query);
            }
            updateAvoid(0);
        }

        public void updateHeight(int choice)
        {
            int upper = 0;
            int lower = 0;
            int max = 0;
            Connection obj = new Connection();
            string query = "";
            query = "SELECT COUNT(height_cm) AS COUNT FROM footballPlayers WHERE height_cm<=160";
            int height160 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            query = "SELECT COUNT(height_cm) AS COUNT FROM footballPlayers WHERE height_cm>160 AND height_cm<=180";
            int height180 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            query = "SELECT COUNT(height_cm) AS COUNT FROM footballPlayers WHERE height_cm>180";
            int height200 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            max = Math.Max(Math.Max(height160, height180), height200);
            if (height160 == max)
            {
                lower = 0;
                upper = 160;
            }
            else if (height180 == max)
            {
                lower = 160;
                upper = 180;
            }
            else
            {
                lower = 180;
                upper = 250;
            }

            if (choice == 1)
            {
                query = "DELETE FROM footballPlayers WHERE height_cm<=" + lower + ";\r\nDELETE FROM footballPlayers WHERE height_cm>" + upper + ";";
                obj.DataReader(query);
                //query = "ALTER TABLE footballPlayers DROP COLUMN height_cm;";
                //obj.DataReader(query);
                updateDelete(1);
            }
            else
            {
                query = "DELETE FROM footballPlayers WHERE height_cm<=" + upper + " AND height_cm>" + lower;
                obj.DataReader(query);
            }
            updateAvoid(1);
        }

        public void updateWeight(int choice)
        {
            int upper = 0;
            int lower = 0;
            int max = 0;
            Connection obj = new Connection();
            string query = "";
            query = "SELECT COUNT(weight_kg) AS COUNT FROM footballPlayers WHERE weight_kg<=60";
            int weight60 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            query = "SELECT COUNT(height_cm) AS COUNT FROM footballPlayers WHERE weight_kg>60 AND weight_kg<=80";
            int weight80 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            query = "SELECT COUNT(height_cm) AS COUNT FROM footballPlayers WHERE weight_kg>80";
            int weight100 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            max = Math.Max(Math.Max(weight60, weight80), weight100);
            if (weight60 == max)
            {
                lower = 0;
                upper = 60;
            }
            else if (weight80 == max)
            {
                lower = 60;
                upper = 80;
            }
            else
            {
                lower = 80;
                upper = 120; 
            }

            if (choice == 1)
            {
                query = "DELETE FROM footballPlayers WHERE weight_kg<=" + lower + ";\r\nDELETE FROM footballPlayers WHERE weight_kg>" + upper + ";";
                obj.DataReader(query);
                //query = "ALTER TABLE footballPlayers DROP COLUMN weight_kg;";
                //obj.DataReader(query);
                updateDelete(2);
            }
            else
            {
                query = "DELETE FROM footballPlayers WHERE weight_kg<=" + upper + " AND weight_kg>" + lower;
                obj.DataReader(query);
            }
            updateAvoid(2);
        }

        public void updateNationality(int choice)
        {
            Connection obj = new Connection();
            string query = "";
            query = "select top 1 nationality,count(nationality) as num from footballPlayersMain group by nationality order by num desc";
            string maxS = obj.getDataSet(query).Tables[0].Rows[0]["nationality"].ToString();

            if (choice == 1)
            {
                query = "DELETE FROM footballPlayers WHERE nationality <> '"+maxS+"';";
                obj.DataReader(query);
                //query = "ALTER TABLE footballPlayers DROP COLUMN nationality;";
                //obj.DataReader(query);
                updateDelete(3);
            }
            else
            {
                query = "DELETE FROM footballPlayers WHERE nationality = '" + maxS + "';";
                obj.DataReader(query);
            }
            updateAvoid(3);
        }

        public void updateClub(int choice)
        {
            Connection obj = new Connection();
            string query = "";
            query = "select top 1 club,count(club) as num\r\nfrom footballPlayersMain\r\ngroup by club\r\norder by num desc";
            string maxS = obj.getDataSet(query).Tables[0].Rows[0]["club"].ToString();

            if (choice == 1)
            {
                query = "DELETE FROM footballPlayers WHERE club <> '" + maxS + "';";
                obj.DataReader(query);
                //query = "ALTER TABLE footballPlayers DROP COLUMN club;";
                //obj.DataReader(query);
                updateDelete(4);
            }
            else
            {
                query = "DELETE FROM footballPlayers WHERE club = '" + maxS + "';";
                obj.DataReader(query);
            }
            updateAvoid(4);
        }

        public void updateOvr(int choice)
        {
            int upper = 0;
            int lower = 0;
            int max = 0;
            Connection obj = new Connection();
            string query = "";

            query = "SELECT COUNT(overall) AS COUNT FROM footballPlayers WHERE overall<=75";
            int ovr75 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            query = "SELECT COUNT(overall) AS COUNT FROM footballPlayers WHERE overall>75 AND overall<=85";
            int ovr85 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            query = "SELECT COUNT(overall) AS COUNT FROM footballPlayers WHERE overall>85";
            int ovr100 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            max = Math.Max(Math.Max(ovr75, ovr85), ovr100);
            if (ovr75 == max)
            {
                lower = 0;
                upper = 75;
            }
            else if (ovr85 == max)
            {
                lower = 75;
                upper = 85;
            }
            else
            {
                lower = 85;
                upper = 100;
            }

            if (choice == 1)
            {
                query = "DELETE FROM footballPlayers WHERE overall<=" + lower + ";\r\nDELETE FROM footballPlayers WHERE overall>" + upper + ";";
                obj.DataReader(query);
                //query = "ALTER TABLE footballPlayers DROP COLUMN overall;";
                //obj.DataReader(query);
                updateDelete(5);
            }
            else
            {
                query = "DELETE FROM footballPlayers WHERE overall<=" + upper + " AND overall>" + lower;
                obj.DataReader(query);
            }
            updateAvoid(5);
        }

        public void updateFoot(int choice)
        {
            Connection obj = new Connection();
            string query = "";
            query = "select top 1 preferred_foot,count(preferred_foot) as num\r\nfrom footballPlayersMain\r\ngroup by preferred_foot\r\norder by num desc";
            string maxS = obj.getDataSet(query).Tables[0].Rows[0]["preferred_foot"].ToString();

            if (choice == 1)
            {
                query = "DELETE FROM footballPlayers WHERE preferred_foot <> '" + maxS + "';";
                obj.DataReader(query);
                //query = "ALTER TABLE footballPlayers DROP COLUMN preferred_foot;";
                //obj.DataReader(query);
                updateDelete(6);
            }
            else
            {
                query = "DELETE FROM footballPlayers WHERE preferred_foot = '" + maxS + "';";
                obj.DataReader(query);
            }
            updateAvoid(6);
        }

        public void updatePosition(int choice)
        {
            Connection obj = new Connection();
            string query = "";
            query = "select top 1 team_position,count(team_position) as num\r\nfrom footballPlayersMain\r\ngroup by team_position\r\norder by num desc";
            string maxS = obj.getDataSet(query).Tables[0].Rows[0]["team_position"].ToString();

            if (choice == 1)
            {
                query = "DELETE FROM footballPlayers WHERE team_position <> '" + maxS + "';";
                obj.DataReader(query);
                //query = "ALTER TABLE footballPlayers DROP COLUMN team_position;";
                //obj.DataReader(query);
                updateDelete(7);
            }
            else
            {
                query = "DELETE FROM footballPlayers WHERE team_position = '" + maxS + "';";
                obj.DataReader(query);
            }
            updateAvoid(7);
        }

        public void updateJersey(int choice)
        {

            Connection obj = new Connection();
            string query = "";
            query = "select top 1 team_jersey_number,count(team_jersey_number) as num\r\nfrom footballPlayersMain\r\ngroup by team_jersey_number\r\norder by num desc";
            int maxS = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0]["team_jersey_number"]);

            if (choice == 1)
            {
                query = "DELETE FROM footballPlayers WHERE team_jersey_number <> " + maxS + ";";
                obj.DataReader(query);
                //query = "ALTER TABLE footballPlayers DROP COLUMN team_jersey_number;";
                //obj.DataReader(query);
                updateDelete(8);
            }
            else
            {
                query = "DELETE FROM footballPlayers WHERE team_jersey_number = " + maxS + ";";
                obj.DataReader(query);
            }
            updateAvoid(8);
        }

        public void updateAvoid(int index)
        {
            Connection obj = new Connection();
            int a1, a2, a3,a4;
            string query = "SELECT TOP 1 * FROM Avoid;";
            a1 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0]["avoid1"]);
            a2 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0]["avoid2"]);
            a3 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0]["avoid3"]);
            a4 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0]["avoid4"]);


            query = "UPDATE Avoid SET avoid3 =" + a2 + ";";
            obj.DataReader(query);
            query = "UPDATE Avoid SET avoid2 =" + a1 + ";";
            obj.DataReader(query);
            query = "UPDATE Avoid SET avoid4 =" + a3 + ";";
            obj.DataReader(query);
            query = "UPDATE Avoid SET avoid5 =" + a4 + ";";
            obj.DataReader(query);
            query = "UPDATE Avoid SET avoid1 =" + index + ";";
                obj.DataReader(query);
        }

        public void updateDelete(int index)
        {
            Connection obj = new Connection();
            int d1, d2, d3, d4;
            string query = "SELECT TOP 1 * FROM DeleteCol;";
            d1 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0]["delete1"]);
            d2 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0]["delete2"]);
            d3 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0]["delete3"]);
            d4 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0]["delete4"]);


            query = "UPDATE DeleteCol SET delete3 =" + d2 + ";";
            obj.DataReader(query);
            query = "UPDATE DeleteCol SET delete2 =" + d1 + ";";
            obj.DataReader(query);
            query = "UPDATE DeleteCol SET delete4 =" + d3 + ";";
            obj.DataReader(query);
            query = "UPDATE DeleteCol SET delete5 =" + d4 + ";";
            obj.DataReader(query);
            query = "UPDATE DeleteCol SET delete1 =" + index + ";";
            obj.DataReader(query);
        }
    }
}
