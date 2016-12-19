using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpticalShop.Data.Initialize
{

    /// <summary>
    /// SQLite Database Initializer
    /// </summary>
    public class SQLiteDbInitializer : IDatabaseInitializer<SQLiteDbContext>
    {

        private const string INITIALIZE_DB_FILE = "OpticalShop.Data.Initialize.initializer.sql";

        #region IDatabaseInitializer<SPCContext> Members

        public void InitializeDatabase(SQLiteDbContext context)
        {
            //From the assembly where this code lives!
            string[] file = this.GetType().Assembly.GetManifestResourceNames();

            //or from the entry point to the application - there is a difference!
            string[] files = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            using (StreamReader readmeStream = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(INITIALIZE_DB_FILE)))
            {
                string commands = readmeStream.ReadToEnd();
                context.Database.ExecuteSqlCommand(commands);
            }

        }

        #endregion
    }
}
