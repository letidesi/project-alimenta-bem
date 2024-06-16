using System.Linq.Expressions;
using alimenta.bem.entity.metadata;
using Microsoft.EntityFrameworkCore;

namespace alimenta.bem.db.context;

public class AlimentaBemContext : DbContext
{

    public AlimentaBemContext(DbContextOptions options) : base(options) { }

    #region 
    // public DbSet<>  { get; set; }

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