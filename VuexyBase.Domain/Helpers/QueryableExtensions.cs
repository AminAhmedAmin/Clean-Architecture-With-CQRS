using System.Linq.Expressions;
using System.Net.Http.Headers;
using VuexyBase.Domain.Constants;

namespace VuexyBase.Domain.Helpers
{
    public static class QueryableExtensions
    {

        public static IQueryable<T> SearchInAllStringProperties<T>(this IQueryable<T> query, string searchTerm)
        {
            //x=>x.property!=null && x.property.contaians(search string) or x=>x.property!=null && x.property.contaians(search string) or etc
            if (string.IsNullOrWhiteSpace(searchTerm))
                return query;
            // GET ALL STRING PROPERTIES 
            var stringProperties = typeof(T).GetProperties()
                .Where(p => p.PropertyType == typeof(string) &&
                           !p.Name.ToLower().Contains("image"));

            if (!stringProperties.Any())
                return query;
            //X
            var parameter = Expression.Parameter(typeof(T), "x");
            Expression combinedExpression = null;

            foreach (var property in stringProperties)
            {
                //X.[Property]
                var propertyAccess = Expression.Property(parameter, property);
                //search string 
                var searchConstant = Expression.Constant(searchTerm, typeof(string));
                //method for filtering 
                var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                var startsWithMethod = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
                var endsWithMethod = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });
                //x.[Property] !=null
                var nullCheck = Expression.NotEqual(propertyAccess, Expression.Constant(null, typeof(string)));
                //x.[Property].[method](string search)
                var containsExpression = Expression.Call(propertyAccess, containsMethod, searchConstant);
                var startsWithExpression = Expression.Call(propertyAccess, startsWithMethod, searchConstant);
                var endsWithExpression = Expression.Call(propertyAccess, endsWithMethod, searchConstant);

                //search expression x=>x.[Property].Contains(string search) or x=>x.[Property].startswith(string search) or etc
                var compinedExpressionSearchString = Expression.Or(containsExpression, startsWithExpression);
                var compinedExpressionContainsAndStartAndEnd = Expression.Or(compinedExpressionSearchString, endsWithExpression);
                //x.[Property] !=null && (x.[Property].Contains(string search)||x.[property].startsWith(string search)||etc)
                var combinedPropertyExpression = Expression.And(nullCheck, compinedExpressionContainsAndStartAndEnd);
                combinedExpression = (combinedExpression == null ? combinedPropertyExpression : Expression.Or(combinedExpression, combinedPropertyExpression));
            }

            if (combinedExpression == null)
                return query;
            //x=>x.property!=null && x.property.contaians(search string) or x=>x.property!=null && x.property.contaians(search string)
            var lambda = Expression.Lambda<Func<T, bool>>(combinedExpression, parameter);
            //filter the iquerable with the expression
            return query.Where(lambda);
        }

        public static IQueryable<T> FilterWithDate<T>(this IQueryable<T> query, DateTime? startDate, DateTime? endDate)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            Expression combinedExpression = null;
            if (startDate == null && endDate == null)
                return query;
            if (startDate.HasValue)
            {
                var startDateProperty = typeof(T).GetProperties()
                .FirstOrDefault(p => p.PropertyType == typeof(DateTime) &&
                                   p.Name.ToLower() == "creationdate");
                if (startDateProperty != null)
                {
                    if (startDateProperty != null)
                    {
                        var propertyAccess = Expression.Property(parameter, startDateProperty);
                        var startDateConstant = Expression.Constant(startDate.Value, typeof(DateTime));
                        var greaterThanOrEqual = Expression.GreaterThanOrEqual(propertyAccess, startDateConstant);
                        combinedExpression = greaterThanOrEqual;
                    }
                }
            }

            if (endDate != null)
            {
                var endDateProperty = typeof(T).GetProperties()
                .FirstOrDefault(p => p.PropertyType == typeof(DateTime) &&
                                   p.Name.ToLower() == "enddate");

                if (endDateProperty != null)
                {
                    var propertyAccess = Expression.Property(parameter, endDateProperty);
                    var endDateConstant = Expression.Constant(endDate.Value, typeof(DateTime));
                    var lessThanOrEqual = Expression.LessThanOrEqual(propertyAccess, endDateConstant);

                    combinedExpression = combinedExpression == null
                        ? lessThanOrEqual
                        : Expression.And(combinedExpression, lessThanOrEqual);
                }
            }
            if (combinedExpression == null)
                return query;

            var lambda = Expression.Lambda<Func<T, bool>>(combinedExpression, parameter);
            return query.Where(lambda);
        }

        public static IQueryable<T> OrderByExtension<T>(this IQueryable<T> query, string property, string dir)
        {
            if (string.IsNullOrWhiteSpace(property))
                return query;

            var parameter = Expression.Parameter(typeof(T), "x");
            var propertyInfo = typeof(T).GetProperties()
                .FirstOrDefault(x => x.Name.Equals(property, StringComparison.OrdinalIgnoreCase));

            if (propertyInfo == null)
                return query;

            var propertyAccess = Expression.Property(parameter, propertyInfo);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);

            // Determine sorting direction (default to ascending if dir is invalid)
            bool isAscending = string.Equals(dir, "asc", StringComparison.OrdinalIgnoreCase);

            // Use MethodInfo to dynamically call OrderBy or OrderByDescending
            var methodName = isAscending ? "OrderBy" : "OrderByDescending";
            return query.Provider.CreateQuery<T>(
            Expression.Call(
                typeof(Queryable),
                methodName,
                new Type[] { typeof(T), propertyInfo.PropertyType },
                query.Expression,
                Expression.Quote(orderByExpression)
            ));
        }

    }
}
