using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("Favorite")]
    public class Favorite
    {
        public int Id { get; set; }

        //fk
        public int MovieId { get; set; }

        //fk
        public int UserId { get; set; }

        //Navigation property
        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
