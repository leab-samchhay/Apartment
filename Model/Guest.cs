using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APARTMENT_API.Model
{
    [Table("TblGuest")]
    public class Guest
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name",TypeName = "Varchar2")]
        [StringLength(50)]
        public string? Name { get; set; }

        [Column("NameKh" ,TypeName = "varchar2")]
        [StringLength(50)]
        public string? NameKh { get; set; }

        [Column("Sex",TypeName = "varchar2")]
        [StringLength(50)]
        public string? Sex { get;set; }

        [Column("Date")]
        public DateTime Dob { get; set; }

        [Column("Address",TypeName ="nvarchar2")]
        [StringLength(50)]
        public string? Address { get; set; }

        [Column("Nationality",TypeName = "nvarchar2")]
        [StringLength(50)]
        public string? Nationality { get; set; }

        [Column("Phone", TypeName = "nvarchar2")]
        [StringLength(50)]
        public string? Phone { get; set; }

        [Column("Email", TypeName = "nvarchar2")]
        [StringLength(20)]
        public string? Email { get; set; }

        [Column("SSN", TypeName = "nvarchar2")]
        [StringLength(20)]
        public string? SSN { get; set; }

        [Column("Passport", TypeName = "nvarchar2")]
        [StringLength(20)]
        public string? Passport { get; set; }

        [Column("Status",TypeName = "nvarchar2")]
        [StringLength(20)]
        public string? Status { get; set; }

        [Column("Image", TypeName = "varchar2")]
        [StringLength(200)]
        public string? ImagePath { get; set; }

    }
}
