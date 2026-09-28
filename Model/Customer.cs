using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APARTMENT_API.Model
{
    [Table("CUSTOMER")]
    public class Customer
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required,StringLength(50)]
        [Column("NAME",TypeName = "NVARCHAR2")]
        public string? NAME {  get; set; }

        [Required, StringLength(50)]
        [Column("GENDER", TypeName = "NVARCHAR2")]
        public string? GENDER { get; set; }

        [Required, StringLength(100)]
        [Column("PHONE",TypeName = "NVARCHAR2")]
        public string? PHONE { get; set; }

        [Column, StringLength(150)]
        public string? ADDRESS { get; set; }

    }
}
