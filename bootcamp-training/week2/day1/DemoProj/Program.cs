using System;
using System.Data.SqlClient;


namespace ConsoleAppDemo
{
    class Program
    {
        static void Main(string[] args)
        {
           createTable();
            Console.ReadKey();
        }
        public static void createTable()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(@"data source=WKWIN5812429\ANSHUL; database=Library; integrated security=SSPI");

                SqlCommand cm = new SqlCommand("create table student(id int not null, name varchar(100), email varchar(50), join_date date)", con);

                con.Open();
                cm.ExecuteNonQuery();


                Console.WriteLine("Table created Successfully");

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
                {
                con.Close();
            }
        }
    }
}
