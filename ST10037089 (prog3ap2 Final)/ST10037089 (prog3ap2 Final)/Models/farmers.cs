using System.ComponentModel.DataAnnotations;

namespace ST10037089__prog3ap2_Final_.Models
{
    //farmers model --> poppulates the database
    public class farmers
    {
        [Key]
        public int farmerid { get; set; }

        [Display(Name = "Farmers Name")]
        public string farmername { get; set; }

        [Display(Name = "Farmers Surname")]
        public string farmersurname { get; set; }

        [Display(Name = "Farmers Email")]
        public string farmeremail {  get; set; }

        [Display(Name = "Farmers Password")]
        public string password { get; set; }    

        [Display(Name = "Farmer Speciality")]
        public string farmerType { get; set; }
        [Display(Name = "Farmers Location")]
        public string farmerLocation { get; set; }

    }
}
