using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APARTMENT_API.Model
{
    [Table("TblFloors")]
    public class Floors
    {
        [Key]
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [Column("FloorNo", TypeName = "number(3)")]
        public int FloorNo { get; set; }


        // foreign key
        [Required]
        [Column("BuildingId", TypeName = "number")]
        public int BuildingId { get; set; }
        public Building? Building { get; set; }
    }
}
