using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APARTMENT_API.Model
{
    [Table("TblStaff")]
    public class Staff
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("positionId")]
        [ForeignKey(nameof(Position))]
        public int positionId { get; set; }
        public Position? Position { get; set; }

        [Required]
        [StringLength(50)]
        [Column("name", TypeName = "NVARCHAR2(50)")]
        public string? name { get; set; }

        [Required]
        [StringLength(50)]
        [Column("nameKh", TypeName = "NVARCHAR2(50)")]
        public string? nameKh { get; set; }

        [Required]
        [StringLength(10)]
        [Column("sex", TypeName = "NVARCHAR2(10)")]
        public string? sex { get; set; }

        [Required]
        [Column("dob", TypeName = "DATE")]
        public DateTime? dob { get; set; }

        [Required]
        [StringLength(50)]
        [Column("phone", TypeName = "NVARCHAR2(50)")]
        public string? phone { get; set; }

        [StringLength(255)]
        [Column("address", TypeName = "NVARCHAR2(255)")]
        public string? address { get; set; }

        [StringLength(50)]
        [Column("email", TypeName = "NVARCHAR2(50)")]
        public string? email { get; set; }

        [StringLength(50)]
        [Column("identityNo", TypeName = "NVARCHAR2(50)")]
        public string? identityNo { get; set; }

        
        [StringLength(500)]
        [Column("photo", TypeName = "NVARCHAR2(500)")]
        public string? photo { get; set; } 

        
        [Column("status")]
        public int status { get; set; }

        
        [Column("createAt", TypeName = "DATE")]
        public DateTime createAt { get; set; }

        
        [StringLength(100)]
        [Column("createBy", TypeName = "NVARCHAR2(100)")]
        public string createBy { get; set; } = string.Empty;
    }
}
