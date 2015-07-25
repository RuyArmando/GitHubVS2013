using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace blog.DAL
{
    class ConnectionFactory
    {
        public static IDbConnection CriarConexao()
        {
            var stringConexao = ConfigurationManager.ConnectionStrings["blog"];
            IDbConnection conexao = new SqlConnection();
            conexao.ConnectionString = stringConexao.ConnectionString;
            conexao.Open();
            return conexao;
        }
    }
}
