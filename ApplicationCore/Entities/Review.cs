using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("Review")]
    public class Review
    {
        //pk and fk, principle table is Movie
        public int MovieId { get; set; }
        //pk and fk, principle table is User
        public int UserId { get; set; }
        public string Rating { get; set; }

        [MaxLength(4096)]
        public string? ReviewText { get; set; }

        //Navigation property
        public Movie Movie { get; set; }
        public User User { get; set; }

    }
}
