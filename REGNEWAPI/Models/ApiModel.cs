using System.ComponentModel.DataAnnotations;

namespace REGNEWAPI.Models
{
    public class ApiModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? FName { get; set; }
        [Required]
        [StringLength(100)]
        public string? LName { get; set; }


        [Required]
        [StringLength(100)]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'+/=?^_`{|}~-]+)@(?:[a-z0-9](?:[a-z0-9-][a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "email address is invalid")]
        public string? Email { get; set; }
        [Required]
        [StringLength(100)]
        public string? DOB { get; set; }
        [Required]
        [StringLength(100)]
        public string? Department { get; set; }
        [Required]
        [StringLength(100)]
        public string? Designation { get; set; }
        [Required]
        [StringLength(100)]
        public string? City { get; set; }
        [Required]
        [StringLength(10)]
        public string? ContactNo { get; set; }
    }
}
