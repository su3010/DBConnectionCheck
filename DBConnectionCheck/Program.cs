using System;
using System.Net;
using System.Security;
using Microsoft.Data.SqlClient;

namespace DBConnectionCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            Console.WriteLine("ServerName?");
            String ServerName = Console.ReadLine();
            Console.WriteLine("DatabaseName?");
            String DatabaseName = Console.ReadLine();
            Console.WriteLine("SQLLoginName");
            String UserName = Console.ReadLine();
            Console.WriteLine("Password");
            String strPassword = Console.ReadLine();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = $"Server={ServerName}; Initial Catalog={DatabaseName}; uid={UserName}; pwd={strPassword};Connect Timeout=8;";
            Console.WriteLine(con.ConnectionString);
            Console.WriteLine("Connectiing....");
            try
                {                    
                    con.Open();
                    Console.WriteLine("Connection Opend");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Excption");
                    Console.WriteLine(ex.Message);
                }
        

            Console.Read();
        }

        static SecureString ReadPassword()
        {
            SecureString password = new SecureString();
            Console.WriteLine("Enter password: ");

            ConsoleKeyInfo nextKey = Console.ReadKey(true);

            while (nextKey.Key != ConsoleKey.Enter)
            {
                if (nextKey.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password.RemoveAt(password.Length - 1);
                        // erase the last * as well
                        Console.Write(nextKey.KeyChar);
                        Console.Write(" ");
                        Console.Write(nextKey.KeyChar);
                    }
                }
                else
                {
                    password.AppendChar(nextKey.KeyChar);
                    Console.Write("*");
                }
                nextKey = Console.ReadKey(true);
            }
            password.MakeReadOnly();
            return password;
        }
    }
}
