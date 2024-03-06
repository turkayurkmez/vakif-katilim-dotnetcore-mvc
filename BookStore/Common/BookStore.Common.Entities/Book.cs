using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Common.Entities
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(200, ErrorMessage = "En fazla 200 karakter ")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountRate { get; set; }
        public string ImageUrl { get; set; } = "https://i.dr.com.tr/cache/154x170-0/originals/0002103875001-1.jpg";

        public int GenreId { get; set; }

        public Genre Genre { get; set; }


        public int Stock { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool? IsDeleted { get; set; }

        public bool? IsActive { get; set; }

    }
}
