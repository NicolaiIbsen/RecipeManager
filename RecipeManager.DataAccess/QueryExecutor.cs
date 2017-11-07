using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace RecipeManager.DataAccess
{
    /// <summary>Provides functionality to execute SQL queries against a SQL database.</summary>
    public class QueryExecutor
    {
        #region Fields
        /// <summary>The connection string.</summary>
        protected readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RecipeManagerDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        #endregion


        #region Constructors
        /// <summary>Creates a new object of <see cref="QueryExecutor"/>, and tests if a connection can be made. A <see cref="SqlException"/> is thrown if not so.</summary>
        public QueryExecutor()
        {
            try
            {
                SqlConnection testConnection = new SqlConnection(connectionString);
                testConnection.Open();
                testConnection.Close();
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion


        #region Methods
        /// <summary>Executes the provided <paramref name="sqlQuery"/> against the database, and returns a <see cref="DataSet"/> containing any data returned from the database.</summary>
        /// <param name="sqlQuery">The sQL query to execute.</param>
        /// <returns>A <see cref="DataSet"/> containing any data returned from the database.</returns>
        public virtual DataSet Execute(string sqlQuery)
        {
            try
            {
                DataSet resultSet = new DataSet();
                using(SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(sqlQuery, new SqlConnection(connectionString))))
                {
                    adapter.Fill(resultSet);
                }
                return resultSet;
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion
    }
}