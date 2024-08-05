using System.Linq.Expressions;
using alimenta.bem.entity.metadata;
using alimenta_bem.src.modules.role.repository;
using alimenta_bem.src.modules.user.repository;
using alimenta_bem.src.natural.person.repository;
using alimenta_bem.src.organization.repository;

namespace alimenta_bem.db.context;

public class AlimentaBemContext : DbContext
{

    public AlimentaBemContext(DbContextOptions options) : base(options) { }

    #region 
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<NaturalPerson> NaturalPersons { get; set; }

    public DbSet<Organization> Organizations { get; set; }

    #endregion
    protected override void OnModelCreating(ModelBuilder mb)
    {
        ConfigureSoftDelete(ref mb);

        base.OnModelCreating(mb);
    }
    private void ConfigureSoftDelete(ref ModelBuilder mb)
    {
        foreach (var entityType in mb.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType);

                var body = Expression.Equal(

                    Expression.Property(parameter, nameof(BaseEntity.deletedAt)),

                    Expression.Constant(null, typeof(DateTime?))
                );

                mb.Entity(entityType.ClrType).HasQueryFilter(Expression.Lambda(body, parameter));
            }
        }
    }
}