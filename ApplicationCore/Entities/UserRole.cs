using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("UserRole")]
    public class UserRole
    {
        //pk and fk, principle table is User
        public int UserId { get; set; }
        //pk and fk, principle table is Role
        public int RoleId { get; set; }

        //Navigation property
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
