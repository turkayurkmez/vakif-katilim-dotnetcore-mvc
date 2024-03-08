using BookStore.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookStore.Services.DataTransferObjects.Requests
{
    public class CreateNewBookRequest
    {
        [Required(ErrorMessage = "Kitap adı boş olmamalı")]
        [MinLength(3, ErrorMessage = "En az 3 karakter olmalı")]
        [MaxLength(200, ErrorMessage = "MaxTitle")]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Yazar")]
        public string Author { get; set; }
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
        [Display(Name = "İndirim")]
        public decimal DiscountRate { get; set; }
        [Display(Name = "Resim Adresi")]
        public string ImageUrl { get; set; } = "https://i.dr.com.tr/cache/154x170-0/originals/0002103875001-1.jpg";
        [Display(Name = "Kitap türü")]
        public int GenreId { get; set; }
        [Display(Name = "Stok")]
        public int Stock { get; set; }
    }
}
