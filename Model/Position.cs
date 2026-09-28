using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APARTMENT_API.Model
{
    [Table("TblPosition")]
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("positionName", TypeName = "nvarchar")]
        [MaxLength(50)]
        public string? positionName { get; set; }

        [Required]
        [Column("positionNameKh", TypeName = "nvarchar")] // កែអក្ខរាវិរុទ្ធរួចរាល់
        [MaxLength(50)]
        public string? positionNameKh { get; set; }

        [Required]
        [Column("status", TypeName = "int")]
        public int? status { get; set; }
    }
}
