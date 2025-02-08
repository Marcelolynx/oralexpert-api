using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;

namespace Eleven.OralExpert.Services.Filters;

public class UserQueryFilter : ICustomQueryable
{
    [QueryOperator(Operator = WhereOperator.Contains, CaseSensitive = false)]
    public string? Name { get; set; }
    
    [QueryOperator(Operator = WhereOperator.Equals)]
    public string? Email { get; set; }
    
    [QueryOperator(Operator = WhereOperator.GreaterThan)]
    public DateTime? CreatedAfter { get; set; }
    
    [QueryOperator(Operator = WhereOperator.LessThan)]
    public DateTime CreatedBefore { get; set; }
    
    public bool IgnoreQueryFilters { get; set; } = false;
}