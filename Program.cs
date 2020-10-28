using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectingToSql
{
    class Program
    {
        static void Main(string[] args)
        {
            string strConnection = @"data source =DESKTOP-7TC9CTO\SQLEXPRESS;database=ComptoirAnglais;Integrated Security=True";
            
            try
            {
                SqlConnection oConnection = new SqlConnection(strConnection);
                oConnection.Open();
                Console.WriteLine("Etat de la connection : "+oConnection.State);
                Console.ReadKey();
                SqlCommand command = new SqlCommand("SELECT CustomerID, ContactName FROM [Customers]", oConnection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("Customer ID : {0} ,ContactName : {1}",reader.GetString(0), reader.GetString(1));
                }
                oConnection.Close();
                Console.WriteLine("Etat de la connection : " + oConnection.State);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("l'erreur suivante a été rencontrée : " + e.Message);
            }
            Console.ReadKey();
        }
    }
}
