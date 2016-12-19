using OpticalShop.Data.Initialize;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace OpticalShop.Data
{
    /// <summary>
    /// SQLite database context
    /// </summary>
    public class SQLiteDbContext : DbContext, IDbContext
    {
        static SQLiteDbContext()
        {
            Database.SetInitializer<SQLiteDbContext>(new SQLiteDbInitializer());
        }

        public SQLiteDbContext(DbConnection connection) : base(connection, true)
        {
            this.Database.Log = new Action<string>(OnLogging);
        }

        protected void OnLogging(string message)
        {
            Debug.WriteLine(message);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
               type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

        #region IDbContext Members

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        #endregion
    }
}
