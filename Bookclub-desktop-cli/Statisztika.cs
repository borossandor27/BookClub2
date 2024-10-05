using System;
using System.Collections.Generic;
using MySqlConnector;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub_desktop_cli
{
    internal class Statisztika
    {
        List<Member> members = new List<Member>();
        MySqlConnection connection;
        MySqlCommand sql = null;

        public Statisztika()
        {
            Beolvasas();
        }

        public void feladat01()
        {
            //-- Határozza meg a kitiltott klubtagok számát
            Console.WriteLine($"Kitiltott tagok száma: {members.FindAll(a => a.Banned).Count()}");
        }
        public void feladat02()
        {
            //-- Döntse el, hogy szerepel-e az adatok között 18 évnél fiatalabb személy.
            string result = members.Exists(a => DateTime.Now.Year - a.Birth_date.Year < 18) ? "Van" : "Nincs";
            Console.WriteLine($"\n{result} a tagok között 18 évnél fiatalabb személy.");
        }
        public void feladat03()
        {
            //-- Határozza meg és írja ki a legidősebb klubtag nevét és születésnapját.
            Member oldest = members.OrderBy(a => a.Birth_date).First();
            Console.WriteLine($"\nA legidősebb klubtag: {oldest.Name} ({oldest.Birth_date.ToString("yyyy.MM.dd")})");
        }
        public void feladat04()
        {
            //-- Határozza meg és írja ki nemenként csoportosítva a tagok számát.
            Console.WriteLine("\nTagok száma:");
            Console.WriteLine($"\tNő: {members.Count(a => a.Gender.Equals("F"))}");
            Console.WriteLine($"\tFérfi: {members.Count(a => a.Gender.Equals("M"))}");
            Console.WriteLine($"\tIsmeretlen: {members.Count(a => a.Gender.Equals(String.Empty))}");
        }
        public void feladat05()
        {
            /* 
             * Kérjen be a konzolról egy nevet. 
             * Határozza meg, hogy az adott személy ki van-e tiltva a klubból. 
             * Ha a megadott névvel nem szerepel klubtag, akkor „Nincs ilyen tagja a klubnak” üzenet jelenjen meg.
             */
            Console.Write("\nAdjon meg egy nevet: ");
            string nev = Console.ReadLine();
            Member member = members.Find(a => a.Name.Equals(nev));
            if (member == null)
            {
                Console.WriteLine("Nincs ilyen tagja a klubnak");
            }
            else
            {
                Console.WriteLine(member.Banned ? "A tag ki van tiltva a klubból" : "A tag nincs kitiltva a klubból");
            }
        }

        private void Beolvasas()
        {
            members.Clear();
            Console.WriteLine("Adatok beolvasása...");
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "localhost";
            sb.Database = "members";
            sb.UserID = "root";
            sb.Password = "";
            sb.CharacterSet = "utf8";
            connection = new MySqlConnection(sb.ConnectionString);
            sql = connection.CreateCommand();
            try
            {
                connection.Open();
                //-- tagok tábla beolvasása -----------------------------------
                sql.CommandText = "SELECT `id`,`name`,`gender`,`birth_date`,`banned` FROM `members` WHERE 1";
                using (MySqlDataReader dr = sql.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string gender = dr.IsDBNull(dr.GetOrdinal("gender")) ? string.Empty : dr.GetString("gender");
                        Member uj = new Member(dr.GetInt32("id"), dr.GetString("name"), gender, dr.GetDateTime("birth_date"), (dr.GetInt16("banned") == 0 ? false : true));
                        members.Add(uj);
                    }
                }
                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }

    }
}
