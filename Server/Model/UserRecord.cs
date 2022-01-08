using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dto;

namespace Server.Model
{
    [Table("base_users")]
    public class UserRecord
    {
        [Column("name"), Key]
        public string Name { set; get; }
        
        [Column("password"), Required(AllowEmptyStrings = false)]
        public string Password { set; get; }


        public List<TrackRecord> Tracks { get; set; }

        public UserDto ToDto()
        {
            return new UserDto()
            {
                Name = Name
            };
        }
    }
}
