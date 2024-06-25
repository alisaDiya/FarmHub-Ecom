using System.ComponentModel.DataAnnotations;

namespace ST10037089__prog3ap2_Final_.Models
{
    public class products
    {

        //products model --> poppulates the database
        [Key]
            public int productid { get; set; }

            [Display(Name = "farmer selling")]
            public string farmerName { get; set; }

            [Display(Name = "Product for sale")]
            public string productname { get; set; }
            public string category { get; set; }

            [Display(Name = "Produce Date")]
            public DateTime productionDate { get; set; }

            [Display(Name = "Product Image")]
            public string ImageUrl { get; set; }

            [DataType(DataType.Currency)]
            public int Price { get; set; }
        }
}
