using Common.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Data.Entities
{
    public class Category : IDateTimeEntity
    {
        public Category()
        {
            Things = new HashSet<Thing>();
            Categories = new HashSet<Category>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset CreatedOn { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset? UpdatedOn { get; set; }

        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }

        public ICollection<Thing> Things { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}