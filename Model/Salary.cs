using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APARTMENT_API.Model
{
    [Table("TblSalary")]
    public class Salary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        // --- ចំណង Foreign Key ទៅកាន់ Table Staff ---
        [Required]
        [Column("staffid")]
        [ForeignKey(nameof(Staff))]
        public int staffId { get; set; }
        public Staff? Staff { get; set; }

        [Required]
        [Column("date", TypeName = "DATE")]
        public DateTime date { get; set; }

        [Required]
        [Column("salary", TypeName = "NUMBER(18,2)")] // NUMBER(18,2) ស័ក្តិសមបំផុតសម្រាប់ប្រាក់ខែ (មានក្បៀស២ខ្ទង់)
        public decimal salary { get; set; }

        [Column("note", TypeName = "NVARCHAR2(500)")]
        [StringLength(500)]
        public string? note { get; set; }

        [Required]
        [Column("createdate", TypeName = "DATE")]
        public DateTime createdate { get; set; }

        [Required]
        [Column("createby", TypeName = "NVARCHAR2(100)")]
        [StringLength(100)]
        public string createby { get; set; } = string.Empty;
    }
}
