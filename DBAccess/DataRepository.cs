using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager.DBAccess
{
    public abstract class DataRepository
    {
        private QueryExecutor executor;

        public DataRepository()
        {
            Executor = new QueryExecutor();
        }

        public QueryExecutor Executor { get => executor; set => executor = value; }
    }
}
