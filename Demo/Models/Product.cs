using System.ComponentModel.DataAnnotations.Schema;
using System.Security;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;


namespace Demo.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

         //Name
        [Required (ErrorMessage ="your Name is requred")]
        [MinLength(4, ErrorMessage ="your name must not be less than 4 characters")]
        [MaxLength(50,ErrorMessage ="your name must not be exceed 10 characters")]
        public String Name { get; set; }

        //Price
        [Required(ErrorMessage = "your Price is requred")]
        [Range( 10000,40000,ErrorMessage ="your Price must between 10000 EGP,40000 EGP")]
        public int Price { get; set; }


        //Description
        [MinLength(2,ErrorMessage ="your desc must not be less than 2 characters")]
        [MaxLength(60,ErrorMessage ="your dec must  not be 60 characters")]
        public String Description { get; set; }

        //Image
        public string? Image { get; set; }   //null

        [NotMapped]
        public IFormFile? ImageFile { get; set; }    //null


        public int CategoryId { get; set; }

       // Navigation
        [ValidateNever]                 //instead of Cascade
        [DeleteBehavior(DeleteBehavior.NoAction)]
         public Category category { get; set; }

    }
}
