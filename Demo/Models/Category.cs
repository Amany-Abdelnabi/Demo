using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Demo.Models
{
    public class Category
    {
                    //properites
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ValidateNever]
        public List<Product> products { get; set; }











    }
}
