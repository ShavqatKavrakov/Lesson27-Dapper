using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
namespace Lesson27
{
    internal class CRUD
    {
       private static string cs = @"Server=DESKTOP-MH2OT2T\DEV;Database=Alif Academy;Trusted_Connection=True;";
       public static async  Task<bool>Insert(Car car)
        {        
            using (SqlConnection conn = new SqlConnection(cs))
            {              
                conn.Open();
                int Queary = await conn.ExecuteAsync("INSERT INTO Cars VALUES(@Name,@Price)", 
                    new { Name = car.Name, Price = car.Price });
                return Queary>0;
            }
        }
        public static async Task<Car> Read(string name)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                var Queary = await conn.QueryFirstOrDefaultAsync<Car>("SELECT * FROM Cars WHERE Name=@name",new {name});
                return Queary;
            }
        }
        public static List<Car> ReadAll()
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                var Queary =  conn.Query<Car>(@"SELECT * FROM Cars ").ToList();                 
                return Queary;
            }
        }

        public static async Task<bool> Update(string name ,string newname)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                int Queary = await conn.ExecuteAsync(@"Update Cars SET Name=@NewName Where Name=@Name",
                    new { NewName = newname,Name=name});
                return Queary>0;
            }
        }
        public static async Task<bool>Delete(string name)
        {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    int Queary = await conn.ExecuteAsync(@"DELETE FROM Cars WHERE Name=@Name", new { Name = name });
                    return Queary > 0;
                }
        }
        
    }

}
