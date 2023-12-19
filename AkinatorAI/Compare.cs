using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinatorAI
{
    internal class Compare
    {
        public void compare() {
            Connection obj = new Connection();
            Question q = new Question();
            int[] a = new int[9];
            int temp;
            a[0] = age();
            a[1] = height();
            a[2] = weight();
            a[3] = nationality();
            a[4] = club();
            a[5] = overall();
            a[6] = foot();
            a[7] = pos();
            a[8] = jersey();

            int a1, a2, a3,a4,a5;
            string query = "SELECT TOP 1 * FROM Avoid;";
            a1 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0]["avoid1"]);
            a2 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0]["avoid2"]);
            a3 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0]["avoid3"]);
            a4 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0]["avoid4"]);
            a5 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0]["avoid5"]);

            int d1, d2, d3, d4, d5;
            query = "SELECT TOP 1 * FROM DeleteCol;";
            d1 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0]["delete1"]);
            d2 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0]["delete2"]);
            d3 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0]["delete3"]);
            d4 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0]["delete4"]);
            d5 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0]["delete5"]);

            

            for (int k = 0; k < 9; k++)
            {
                if (d1 == k)
                {
                    a[k] = 0;
                }
                if (d2 == k)
                {
                    a[k] = 0;
                }
                if (d3 == k)
                {
                    a[k] = 0;
                }
                if (d4 == k)
                {
                    a[k] = 0;
                }
                if (d5 == k)
                {
                    a[k] = 0;
                }
            }

            for (int j=0;j<9;j++)
            {
                if(a1 == j)
                {
                    a[j] = 0;
                }
                if(a2==j)
                {
                    a[j] = 0;
                }
                if(a3==j)
                {
                    a[j] = 0;   
                }
                if (a4 == j)
                {
                    a[j] = 0;
                }
                if (a5 == j)
                {
                    a[j] = 0;
                }
            }
            int max = a.Max();
            for (int i =0;i<9;i++)
            {
                
                    if (max == a[i])
                    {
                        q.question(i);
                    }   
            }
        }

        public int age()
        {
            Connection obj = new Connection();
            string query = "SELECT COUNT(age) AS COUNT FROM footballPlayers WHERE age<=20";
            int age20 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            query = "SELECT COUNT(age) AS COUNT FROM footballPlayers WHERE age>20 AND age<=30";
            int age30 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            query = "SELECT COUNT(age) AS COUNT FROM footballPlayers WHERE age>30";
            int age40 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            int max = Math.Max(Math.Max(age20, age30),age40);
            return max;
        }

        public int height()
        {
            Connection obj = new Connection();
            string query = "SELECT COUNT(height_cm) AS COUNT FROM footballPlayers WHERE height_cm<=160";
            int height160 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            query = "SELECT COUNT(height_cm) AS COUNT FROM footballPlayers WHERE height_cm>160 AND height_cm<=180";
            int height180 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            query = "SELECT COUNT(height_cm) AS COUNT FROM footballPlayers WHERE height_cm>180";
            int height200 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            int max = Math.Max(Math.Max(height160, height180), height200);
            return max;
        }

        public int weight()
        {
            Connection obj = new Connection();
            string query = "SELECT COUNT(weight_kg) AS COUNT FROM footballPlayers WHERE weight_kg<=60";
            int weight60 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            query = "SELECT COUNT(height_cm) AS COUNT FROM footballPlayers WHERE weight_kg>60 AND weight_kg<=80";
            int weight80 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            query = "SELECT COUNT(height_cm) AS COUNT FROM footballPlayers WHERE weight_kg>80";
            int weight100 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            int max = Math.Max(Math.Max(weight60, weight80), weight100);
            return max;
        }

        public int nationality ()
        {
            Connection obj = new Connection();
            string query = "select top 1 count(nationality) as num\r\nfrom footballPlayersMain\r\ngroup by nationality\r\norder by num desc";
            int max = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            return max;
        }

        public int club()
        {
            Connection obj = new Connection();
            string query = "select top 1 count(club) as num\r\nfrom footballPlayersMain\r\ngroup by club\r\norder by num desc";
            int max = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            return max;
        }

        public int overall()
        {
            Connection obj = new Connection();
            string query = "SELECT COUNT(overall) AS COUNT FROM footballPlayers WHERE overall<=75";
            int ovr75 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            query = "SELECT COUNT(overall) AS COUNT FROM footballPlayers WHERE overall>75 AND overall<=85";
            int ovr85 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            query = "SELECT COUNT(overall) AS COUNT FROM footballPlayers WHERE overall>85";
            int ovr100 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            int max = Math.Max(Math.Max(ovr75, ovr85), ovr100);
            return max;
        }

        public int foot()
        {
            Connection obj = new Connection();
            string query = "select top 1 count(preferred_foot) as num\r\nfrom footballPlayersMain\r\ngroup by preferred_foot\r\norder by num desc";
            int max = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            return max;
        }

        public int pos()
        {
            Connection obj = new Connection();
            string query = "select top 1 count(team_position) as num\r\nfrom footballPlayersMain\r\ngroup by team_position\r\norder by num desc";
            int max = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            return max;
        }

        public int jersey()
        {
            Connection obj = new Connection();
            string query = "select top 1 count(team_jersey_number) as num\r\nfrom footballPlayersMain\r\ngroup by team_jersey_number\r\norder by num desc";
            int max = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
            return max;
        }

    }
}
