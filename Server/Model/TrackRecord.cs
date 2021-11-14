using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Model
{
    [Table("track")]
    public class TrackRecord
    {
        [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        
        [Column("author"), Required(AllowEmptyStrings = false)]
        public string Author { set; get; }
        
        [Column("composition"), Required(AllowEmptyStrings = false)]
        public string Composition { set; get; }

        public override string ToString()
        {
            return $"{Author} - {Composition}";
        }
    }
}