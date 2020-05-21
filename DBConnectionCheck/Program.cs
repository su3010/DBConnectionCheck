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
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 ;
            //ServicePointManager.SecurityProtocol =  SecurityProtocolType.Tls;

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
      
    }
}
