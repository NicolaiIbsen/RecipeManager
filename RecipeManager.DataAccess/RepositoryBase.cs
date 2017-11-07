namespace RecipeManager.DataAccess
{
    /// <summary>Abstract base class for repositories. Is composed of <see cref="QueryExecutor"/>.
    /// </summary>
    public abstract class RepositoryBase
    {
        #region Fields
        /// <summary>The object of <see cref="QueryExecutor"/>.</summary>
        protected QueryExecutor executor;
        #endregion


        #region Constructors
        /// <summary>Creates a new object of a deriving c, and instantiates attempts to test the connection to the database.</summary>
        public RepositoryBase()
        {
            executor = new QueryExecutor();
        }
        #endregion
    }
}