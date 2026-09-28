using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APARTMENT_API.Model
{
    [Table("TblortherExpens")]
    public class OrtherExpense
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("DateTime")]
        public DateTime Date { get; set; }

        [Required]
        [Column("ExpenseTypeId")]
        [ForeignKey("ExpensType")]
        public int ExpenseTypeId { get; set; }
        public ExpensType? ExpensType { get; set; }

        [Required]
        [Column("Amount", TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [Column("Note")]
        public string? Note { get; set; }

        [Required]
        [Column("CreateBy")]
        public string? CreateBy { get; set; }

        [Required]
        [Column("CreateDate")]
        public DateTime CreateDate { get; set; }

        [Required]
        [Column("Image")]
        public string? Image { get; set; }


    }
}
