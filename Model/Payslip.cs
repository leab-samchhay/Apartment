using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APARTMENT_API.Model
{
    [Table("TblPayslip")]
    public class Payslip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("date", TypeName = "DATE")]
        public DateTime date { get; set; }

        [Required]
        [Column("staffid")]
        [ForeignKey(nameof(Staff))]
        public int staffId { get; set; }
        public Staff? Staff { get; set; }

        [Required]
        [Column("salary", TypeName = "NUMBER(18,2)")]
        public decimal salary { get; set; }

        [Required]
        [Column("vat", TypeName = "NUMBER(18,2)")]
        public decimal vat { get; set; }

        [Required]
        [Column("penanty", TypeName = "NUMBER(18,2)")]
        public decimal penanty { get; set; }

        [Required]
        [Column("bonus", TypeName = "NUMBER(18,2)")]
        public decimal bonus { get; set; }

        [Required]
        [Column("totalsalary", TypeName = "NUMBER(18,2)")]
        public decimal totalsalary { get; set; }

        [Required]
        [Column("createdate", TypeName = "DATE")]
        public DateTime createdate { get; set; }

        [Required]
        [Column("createby", TypeName = "NVARCHAR2(100)")]
        [StringLength(100)]
        public string createby { get; set; } = string.Empty;

    }
}
