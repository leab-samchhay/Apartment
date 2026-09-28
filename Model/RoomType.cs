using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APARTMENT_API.Model
{
    [Table("TblRoomType")]
    public class RoomType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("RoomTypeName", TypeName = "nvarchar2")]
        [StringLength(50)]
        public string RoomTypeName { get; set; } = string.Empty;


        [Column("RoomTypeNameKh", TypeName = "nvarchar2")]
        [StringLength(50)]
        public string RoomTypeNameKh { get; set; } = string.Empty;
    }
}
