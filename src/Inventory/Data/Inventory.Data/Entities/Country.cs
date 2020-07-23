//using Common.Data.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace Inventory.Data.Entities
//{
//    public class Country : IDateTimeEntity
//    {
//        public Country()
//        {
//            Locations = new HashSet<Location>();
//        }

//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public int Id { get; set; }

//        [Required]
//        [MaxLength(100)]
//        public string Name { get; set; }

//        [Required]
//        [MaxLength(3)]
//        public string Code { get; set; }

//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public DateTimeOffset CreatedOn { get; set; } = DateTime.UtcNow;

//        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
//        public DateTimeOffset? UpdatedOn { get; set; }

//        public ICollection<Location> Locations { get; set; }
//    }
//}

//MOVE TO LOCATION MICROSERIVCE