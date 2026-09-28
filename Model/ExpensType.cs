using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APARTMENT_API.Model
{
    [Table("ExpensType")]
    public class ExpensType
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        [Column("expensType", TypeName = "nvarchar2"), MaxLength(50)]
        public string? expensType { get; set; }
    }
}
