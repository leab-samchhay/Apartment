using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APARTMENT_API.Model
{
    [Table("TblItem")]
    public class Item
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        [Column("ItemName", TypeName = "nvarchar2"), MaxLength(50)]
        public string? ItemName { get; set; }

        [Required, StringLength(50)]
        [Column("NameKh", TypeName = "nvarchar2"), MaxLength(50)]
        public string? NameKh { get; set; }

        [Required]
        [Column("Price", TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [StringLength(250)]
        [Column("Remark", TypeName = "nvarchar2"), MaxLength(250)]
        public string? Remark { get; set; }

        [Required, StringLength(20)]
        [Column("Status", TypeName = "nvarchar2"), MaxLength(20)]
        public string? Status { get; set; }

    }
}
