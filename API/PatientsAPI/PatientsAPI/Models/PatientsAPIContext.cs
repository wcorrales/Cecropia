using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PatientsAPI.Models
{
    public class PatientsAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
     
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<BloodTypeModel> BloodTypes { get; set; }

        #region Constructors
        public PatientsAPIContext(string nameOrConnectionString, bool lazyLoading = false)
            : base(nameOrConnectionString)
        {
            Initialize(lazyLoading);
        }

        public PatientsAPIContext(bool lazyLoading = false)
            : base()
        {
            Initialize(lazyLoading);
        }

        public PatientsAPIContext(DbConnection existingConnection, bool lazyLoading = false)
            : base(existingConnection, true)
        {
            Initialize(lazyLoading);
        }

        public PatientsAPIContext(DbConnection existingConnection, DbTransaction currentTransaction, bool lazyLoading = false)
            : base(existingConnection, false)
        {
            if (currentTransaction != null)
                this.Database.UseTransaction(currentTransaction);
        }
        #endregion Constructors

     #region Private Methods
        private void Initialize(bool lazyLoading = false)
        {
            Database.SetInitializer<PatientsAPIContext>(null);
            Configuration.LazyLoadingEnabled = lazyLoading;
        }
        #endregion Private Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

        }
    }
}
