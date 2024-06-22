using System.Linq.Expressions;
using alimenta.bem.entity.metadata;
using alimenta.bem.user.repository;
using alimenta.bem.role.repository;
using alimenta.bem.natural.person.repository;

namespace alimenta.bem.db.context;

public class AlimentaBemContext : DbContext
{

    public AlimentaBemContext(DbContextOptions options) : base(options) { }

    #region 
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<NaturalPerson> NaturalPersons { get; set; }

    // public DbSet<Beneficiary> Beneficiaries { get; set; }

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

                    Expression.Property(parameter, nameof(BaseEntity.DeletedAt)),

                    Expression.Constant(null, typeof(DateTime?))
                );

                mb.Entity(entityType.ClrType).HasQueryFilter(Expression.Lambda(body, parameter));
            }
        }
    }
}