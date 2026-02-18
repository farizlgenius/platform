using System;
using System.ComponentModel.DataAnnotations;

namespace Location.Infrastructure.Persistence.Entities;

public class BaseEntity
{
    [Key]
    public int id { get; set; }
    public bool is_active { get; set; }
    public DateTime created_date { get; set; } = DateTime.UtcNow;
    public DateTime updated_date { get; set; } = DateTime.UtcNow;

}
