using CareerSite.Entity.Concrete;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CareerSite.MvcWebUI.Models
{
    public class CourseModel
    {
        public int CourseId { get; set; }

        // [Display(NameTr="NameTr",Prompt="Enter product name")]
        // [Required(ErrorMessage="NameTr zorunlu bir alan.")]
        // [StringLength(60,MinimumLength=5,ErrorMessage="Ürün ismi 5-10 karakter aralığında olmalıdır.")]
        public string NameTr { get; set; }
        public string NameEn { get; set; }

        [Required(ErrorMessage = "UrlTr zorunlu bir alan.")]
        public string UrlTr { get; set; }

        [Required(ErrorMessage = "UrlTr zorunlu bir alan.")]
        public string UrlEn { get; set; }

        // [Required(ErrorMessage="Price zorunlu bir alan.")]  
        // [Range(1,10000,ErrorMessage="Price için 1-10000 arasında değer girmelisiniz.")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "DescriptionTr zorunlu bir alan.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "DescriptionTr 5-100 karakter aralığında olmalıdır.")]

        public string DescriptionTr { get; set; }
        public string DescriptionEn { get; set; }

        [Required(ErrorMessage = "ImageUrl zorunlu bir alan.")]
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public List<Category> SelectedCategories { get; set; }
    }
}
