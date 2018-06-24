﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DbPopulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the number of rows you that you want to add : ");
            int row = int.Parse(Console.ReadLine());
            Random rnd = new Random();
            int no_row=0;
            List<String> names = new List<string> { "Matt", "Jimmy", "Hyman", "Lane", "Morris", "Garry", "Randall", "Sydney", "Jefferey", "Ruben", "Jacelyn", "Keena", "Cecile", "Jazmin", "Joaquina", "Hyun", "Twana", "Luz", "Tari", "Rena", "Aaron", "Abdul", "Abe", "Abel", "Abraham", "Abram", "Adalberto", "Adam", "Adan", "Adolfo ", "Adolph", "Adrian", "Agustin", "Ahmad", "Ahmed", "Al", "Alan", "Albert", "Alberto", "Alden", "Aldo", "Alec", "Alejandro", "Alex", "Alexander", "Alexis", "Alfonso", "Alfonzo", "Alfred ", "Barney", "Barrett", "Barry", "Bart", "Barton", "Basil", "Beau", "Ben", "Benedict", "Benito", "Benjamin", "Bennett", "Bennie", "Benny", "Benton", "Bernard", "Bernardo", "Bernie", "Berry", "Bert", "Bertram", "Bill", "Billie", "Billy", "Caleb", "Calvin", "Cameron", "Carey", "Carl", "Carlo", "Carlos", "Carlton", "Carmelo", "Carmen", "Carmine", "Carol", "Carrol", "Carroll", "Carson", "Carter", "Cary", "Casey", "Cecil", "Cedric", "Cedrick", "Cesar", "Chad", "Chadwick", "Chance", "Chang", "Charles", "Charley", "Charlie" };
            List<String> surname = new List<string> { "King", "Morgan", "Kline", "Beck", "Gilbert", "Mcclure", "Lang", "Bolton", "Brown", "Hatfield", "Newton", "Bernard", "Short", "Hunter", "Jenkins", "Aguilar", "Riley", "Riggs", "Collins", "Valdez" };
            List<String> domain = new List<string> { "@gmail.com", "@yahoo.com", "@hotmail.com" };
            List<String> designation = new List<string> { ".NET DEVELOPER", "QA", "DBA", "DESIGNING", "SECURITY" };
            List<String> n_names = new List<string>();
            List<String> email_id = new List<string>();
            String cs = @"Server=DESKTOP-EOG8KD1\ADMIN;Database=Employee;User Id=sa;Password = webuser; ";
            SqlConnection sc = new SqlConnection(cs);
            try
            {
                sc.Open();
                SqlCommand command = new SqlCommand("select count(name) from EMPLOYEETBL", sc);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        no_row = reader.GetInt32(0);
                        Console.WriteLine(no_row);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace.ToString());
            }
            finally
            {
                Console.ReadLine();
                sc.Close();
            }
            for (int i = 0; i < row; i++){
                n_names.Add(names[(rnd.Next(no_row,no_row+row)%rnd.Next(1,102))] + " " + surname[(rnd.Next(35, 54)) % (19)]);
                email_id.Add(n_names[i] + rnd.Next(1234,9999) + domain[rnd.Next(3)]);
                email_id[i] = email_id[i].Replace(' ', '_');
            }
            
            if (no_row >= 0)
                no_row += 1;
            for (int i = no_row; i <= (no_row+row); i++){
                //Console.WriteLine(Convert.ToInt64("9841" + (rnd.Next(110000, 999999)).ToString()));
                try
                {
                    //OPEN CONNECTION 
                    sc.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO EMPLOYEETBL (ID,NAME,EMAIL_ID,DESIGNATION,PHONE_NO) VALUES (@ID, @NAME, @EMAILID,@DESIGN,@PHONE)", sc))
                    {
                        Console.WriteLine(i);
                        cmd.Parameters.AddWithValue("@ID",i );
                        cmd.Parameters.AddWithValue("@NAME", n_names[(i%49)]);
                        cmd.Parameters.AddWithValue("@EMAILID", email_id[(i%49)]);
                        cmd.Parameters.AddWithValue("@DESIGN", designation[rnd.Next(5)]);
                        cmd.Parameters.AddWithValue("@PHONE", Convert.ToInt64("9841" + (rnd.Next(110000, 999999)).ToString()));
                        cmd.ExecuteNonQuery();
                    }
                    /*SELECT COMMAND
                     * the following is select query
                     * 
                     *
                    SqlCommand command = new SqlCommand("SELECT * FROM EMPLOYEETBL", sc);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3), reader.GetInt64(4));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }*/
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace.ToString());
                }
                finally
                {
                    Console.WriteLine("SUCCESS");
                    Console.ReadLine();
                    sc.Close();
                }
            }
            Console.ReadLine();
        }
    }
}
    