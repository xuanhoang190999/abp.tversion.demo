using Microsoft.EntityFrameworkCore;
using TVersion.Models;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace TVersion.EntityFrameworkCore
{
    public static class TVersionDbContextModelCreatingExtensions
    {
        public static void ConfigureTVersion(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<Package>(b =>
            {
                b.ToTable(TVersionConsts.DbTablePrefix + "Packages",
                          TVersionConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
            });

            builder.Entity<ChangeLog>(b =>
            {
                b.ToTable(TVersionConsts.DbTablePrefix + "ChangeLogs",
                          TVersionConsts.DbSchema);
                b.HasOne(e => e.Package)
                    .WithMany(e => e.ChangeLogs)
                    .HasForeignKey(e => e.Id)
                    .OnDelete(DeleteBehavior.Cascade);
                b.ConfigureByConvention(); //auto configure for the base class props
            });

            //builder.Entity<Entity>(b =>
            //{
            //    b.ToTable(TVersionConsts.DbTablePrefix + "ten bang",
            //              TVersionConsts.DbSchema);
            //    b.HasOne(e => e.CreatedBy)
            //        .WithMany(e => e.CreatedByEntities)
            //        .HasForeignKey(e => e.CreatedById)
            //        .OnDelete(DeleteBehavior.Cascade);

            //    b.HasOne(e => e.WritedBy)
            //        .WithMany(e => e.UpdatedByEntities)
            //        .HasForeignKey(e => e.WritedById)
            //        .OnDelete(DeleteBehavior.Cascade);

            //    b.ConfigureByConvention(); //auto configure for the base class props
            //});

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(TVersionConsts.DbTablePrefix + "YourEntities", TVersionConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}