using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace MundoBalloonApi.infrastructure.Data.Models;

public static class ModelBuilderExtension
{
    public static void ApplyGlobalFilters<TInterface>(this ModelBuilder modelBuilder,
        Expression<Func<TInterface, bool>> expression)
    {
        var entities = modelBuilder.Model
            .GetEntityTypes()
            .Where(e => e.ClrType.GetInterface(typeof(TInterface).Name) != null)
            .Select(e => e.ClrType);
        foreach (var entity in entities)
        {
            var newParam = Expression.Parameter(entity);
            var newBody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);
            modelBuilder.Entity(entity).HasQueryFilter(Expression.Lambda(newBody, newParam));
        }
    }
}