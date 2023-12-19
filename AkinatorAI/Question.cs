using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinatorAI
{
    internal class Question
    {
        public void question(int index)
        {
            Connection obj = new Connection();
            Update update = new Update();
            int choice = 100;
            int max = 0;
            string maxS = "";
            string query = "";
            switch(index) {      
            case 0:
                    
                    query = "SELECT COUNT(age) AS COUNT FROM footballPlayers WHERE age<=20";
                    int age20 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
                    query = "SELECT COUNT(age) AS COUNT FROM footballPlayers WHERE age>20 AND age<=30";
                    int age30 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
                    query = "SELECT COUNT(age) AS COUNT FROM footballPlayers WHERE age>30";
                    int age40 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
                    max = Math.Max(Math.Max(age20, age30), age40);
                    if(age20==max)
                    {
                        Console.WriteLine(" IS YOUR PLAYER UNDER THE AGE OF 20 ??");
                        choice = displayOptions();
                    }else if(age30 == max)
                    {
                        Console.WriteLine(" IS YOUR PLAYER BETWEEN 20 AND 30 YEARS OF AGE ?? ");
                        choice = displayOptions();
                    }
                    else
                    {
                        Console.WriteLine(" IS YOUR PLAYER OLDER THAN 30 ??");
                        choice = displayOptions();
                    }
                    update.updateAge(choice);
                    break;
                case 1:                   
                    query = "SELECT COUNT(height_cm) AS COUNT FROM footballPlayers WHERE height_cm<=160";
                    int height160 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
                    query = "SELECT COUNT(height_cm) AS COUNT FROM footballPlayers WHERE height_cm>160 AND height_cm<=180";
                    int height180 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
                    query = "SELECT COUNT(height_cm) AS COUNT FROM footballPlayers WHERE height_cm>180";
                    int height200 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
                    max = Math.Max(Math.Max(height160, height180), height200);
                    if (height160 == max)
                    {
                        Console.WriteLine(" IS YOUR PLAYER SHORT (UNDER 160CM) ??");
                        choice = displayOptions();
                    }
                    else if (height180 == max)
                    {
                        Console.WriteLine(" IS YOUR PLAYER MEDIUM HEIGHT (BETWEEN 160CM AND 180CM) ?? ");
                        choice = displayOptions();
                    }
                    else
                    {
                        Console.WriteLine(" IS YOUR PLAYER TALL (OVER 180CM) ??");
                        choice = displayOptions();
                    }
                    update.updateHeight(choice);
                    break;
                case 2:     
                    query = "SELECT COUNT(weight_kg) AS COUNT FROM footballPlayers WHERE weight_kg<=60";
                    int weight60 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
                    query = "SELECT COUNT(height_cm) AS COUNT FROM footballPlayers WHERE weight_kg>60 AND weight_kg<=80";
                    int weight80 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
                    query = "SELECT COUNT(height_cm) AS COUNT FROM footballPlayers WHERE weight_kg>80";
                    int weight100 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
                    max = Math.Max(Math.Max(weight60, weight80), weight100);
                    if (weight60 == max)
                    {
                        Console.WriteLine(" IS YOUR PLAYER UNDER 60KG ??");
                        choice = displayOptions();
                    }
                    else if (weight80 == max)
                    {
                        Console.WriteLine(" IS YOUR PLAYER HEAVIER THAN 60KG AND LIGHTER THAN 80KG ?? ");
                        choice = displayOptions();
                    }
                    else
                    {
                        Console.WriteLine(" IS YOUR PLAYER HEAVIER THAN 80KG ??");
                        choice = displayOptions();
                    }
                    update.updateWeight(choice);
                    break;
                case 3:
                    query = "select top 1 nationality,count(nationality) as num from footballPlayersMain group by nationality order by num desc";
                    maxS = obj.getDataSet(query).Tables[0].Rows[0]["nationality"].ToString();
                    Console.WriteLine(" IS YOUR PLAYER FROM THE COUNTRY " + maxS);
                    choice = displayOptions();
                    update.updateNationality(choice);
                    break;
                case 4:
                    query = "select top 1 club,count(club) as num\r\nfrom footballPlayersMain\r\ngroup by club\r\norder by num desc";
                    maxS = obj.getDataSet(query).Tables[0].Rows[0]["club"].ToString();
                    Console.WriteLine(" IS YOUR PLAYER FROM THE CLUB " + maxS);
                    choice = displayOptions();
                    update.updateClub(choice);
                    break;
                case 5:
                    query = "SELECT COUNT(overall) AS COUNT FROM footballPlayers WHERE overall<=75";
                    int ovr75 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
                    query = "SELECT COUNT(overall) AS COUNT FROM footballPlayers WHERE overall>75 AND overall<=85";
                    int ovr85 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
                    query = "SELECT COUNT(overall) AS COUNT FROM footballPlayers WHERE overall>85";
                    int ovr100 = Convert.ToInt32(obj.getDataSet(query).Tables[0].Rows[0][0]);
                    max = Math.Max(Math.Max(ovr75, ovr85), ovr100);
                    if (ovr75 == max)
                    {
                        Console.WriteLine(" IS YOUR PLAYER'S OVERALL RATING LESS THAN 75 ??");
                        choice = displayOptions();
                    }
                    else if (ovr85 == max)
                    {
                        Console.WriteLine(" IS YOUR PLAYER'S OVERALL RATING BETWEEN 75 AND 85 ??");
                        choice = displayOptions();
                    }
                    else
                    {
                        Console.WriteLine(" IS YOUR PLAYER'S OVERALL HIGHER THAN 85 ??");
                        choice = displayOptions();
                    }
                    update.updateOvr(choice);
                    break;
                case 6:
                    query = "select top 1 preferred_foot,count(preferred_foot) as num\r\nfrom footballPlayersMain\r\ngroup by preferred_foot\r\norder by num desc";
                    maxS = obj.getDataSet(query).Tables[0].Rows[0]["preferred_foot"].ToString();
                    Console.WriteLine(" IS YOUR PLAYER'S PREFERRED FOOT " + maxS);
                    choice = displayOptions();
                    update.updateFoot(choice);
                    break;
                case 7:
                    query = "select top 1 team_position,count(team_position) as num\r\nfrom footballPlayersMain\r\ngroup by team_position\r\norder by num desc";
                    maxS = obj.getDataSet(query).Tables[0].Rows[0]["team_position"].ToString();
                    Console.WriteLine(" IS YOUR PLAYER'S TEAM POSITION " + maxS);
                    choice = displayOptions();
                    update.updatePosition(choice);
                    break;
                case 8:
                    query = "select top 1 team_jersey_number,count(team_jersey_number) as num\r\nfrom footballPlayersMain\r\ngroup by team_jersey_number\r\norder by num desc";
                    maxS = obj.getDataSet(query).Tables[0].Rows[0]["team_jersey_number"].ToString();
                    Console.WriteLine(" IS YOUR PLAYER'S JERSEY NUMBER " + maxS);
                    choice = displayOptions();
                    update.updateJersey(choice);
                    break;
            }
            
        }

        public int displayOptions()
        {
            Console.WriteLine(" YES (Y/y)");
            Console.WriteLine(" DON't KNOW (D/d)");
            Console.WriteLine(" NO (N/n)");
            string answer = Console.ReadLine();
            if(answer == "Y" || answer == "y")
            {
                return 1;
            }
            else if(answer == "D" || answer == "d")
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
    }
}
