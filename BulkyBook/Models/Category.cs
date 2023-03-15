using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyBook.Models
{
    [Table("category")]
    public class Category
    {
        [Column("category_id")]
        public int CategoryId { get; set; }

        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        // added so it wont call it as the model attribute such as DisplayOrder
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100 only!!!")]
        [Column("display_order")]
        public int DisplayOrder { get; set; }

        [Column("created_date_time")]
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;

    }
}

