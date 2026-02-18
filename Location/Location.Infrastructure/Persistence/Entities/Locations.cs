using System;

namespace Location.Infrastructure.Persistence.Entities;

public sealed class Locations : BaseEntity
{
    public string name { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public ICollection<OperatorLocation> operator_locations { get; set; }
}
