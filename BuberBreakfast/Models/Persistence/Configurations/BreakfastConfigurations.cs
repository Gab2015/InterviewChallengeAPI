﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberBreakfast.Models.Persistence.Configurations
{
    public class BreakfastConfigurations : IEntityTypeConfiguration<Breakfast>
    {
        public void Configure(EntityTypeBuilder<Breakfast> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name).HasMaxLength(Breakfast.MaxNameLength);

            builder.Property(b => b.Description).HasMaxLength(Breakfast.MaxDescriptionLength);

            builder.Property(b => b.Savory).HasConversion(
        v => string.Join(',', v),
        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(), new ValueComparer<List<string>>(
                            (c1, c2) => c1.SequenceEqual(c2),
                            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                            c => c.ToList()
                        ));
            builder.Property(b => b.Sweet).HasConversion(
    v => string.Join(',', v),
    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(), new ValueComparer<List<string>>(
                            (c1, c2) => c1.SequenceEqual(c2),
                            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                            c => c.ToList()
                        ));
        }
    }
}
