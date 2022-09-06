using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsActive { get; set; }
    }
}
