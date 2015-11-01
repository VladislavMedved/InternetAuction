using System.Data.Entity;
using System.Diagnostics;
using ORM.CustomDbInitialization;
using ORM.EntitiesTypeConfiguration;

namespace ORM
{
    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer<EntityModel>(new EntityModelInitializer());
            #region Initializers
            //Database.SetInitializer<EntityModel>(new CreateDatabaseIfNotExists<EntityModel>());
            //Database.SetInitializer<EntityModel>(new DropCreateDatabaseIfModelChanges<EntityModel>());
            //Database.SetInitializer<EntityModel>(new DropCreateDatabaseAlways<EntityModel>());
            #endregion
            Debug.WriteLine("Context created!");
        }

        #region Properties
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductTypeConfiguration());
            modelBuilder.Configurations.Add(new UserTypeConfiguration());
            modelBuilder.Configurations.Add(new RoleTypeConfiguration());
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);            
        }
    }
}
