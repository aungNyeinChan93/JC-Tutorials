using Microsoft.Data.SqlClient;
using System.Data;

namespace Four.WebApi.Services
{
    public class BlogService
    {
        private  readonly string _connectionStr;
        private static SqlConnection _connection;


        //public BlogService(IConfiguration config)
        public BlogService( )
        {
            _connectionStr = "Data Source=.;Initial Catalog=KSLH_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True";
            _connection = new SqlConnection(_connectionStr);
        }

        public static void GetBlogs()
        {
            _connection.Open();
            DataTable tb = new ();
            string query = "select * from Tbl_blogs";

            SqlCommand cmd = new (query,_connection);
            SqlDataAdapter adapater = new (cmd);
            adapater.Fill(tb);

            foreach (DataRow blog in tb.Rows)
            {
                Console.WriteLine($"Blog title ==> {blog["title"]}");
            }
            _connection.Close();
        }
    }
}
