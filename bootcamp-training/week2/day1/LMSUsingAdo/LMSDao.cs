using System;
using System.Data.SqlClient;

namespace com.Sapient
{
    class LmsDao
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
                con = new SqlConnection(@"data source=WKWIN5812429\ANSHUL; database=LMS; integrated security=SSPI");

                SqlCommand cm = new SqlCommand("create table Books(Title varchar(200) not null, Author varchar(100), Price float, Id int )", con);

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
