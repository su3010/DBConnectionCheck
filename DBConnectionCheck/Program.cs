using System;
using System.Security;
using Microsoft.Data.SqlClient;

namespace DBConnectionCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ServerName?");
            String ServerName = Console.ReadLine();
            Console.WriteLine("DatabaseName?");
            String DatabaseName = Console.ReadLine();
            Console.WriteLine("SQLLoginName");
            String UserName = Console.ReadLine();
            Console.WriteLine("Password");
            String strPassword = Console.ReadLine();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = $"Server={ServerName}; Initial Catalog={DatabaseName}; uid={UserName}; pwd={strPassword};";
            Console.WriteLine(con.ConnectionString);
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
