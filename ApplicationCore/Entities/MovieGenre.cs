using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("MovieGenre")]
    public class MovieGenre
    {
        //pk and fk
        public int MovieId { get; set; }

        //pk and fk
        public int GenreId { get; set; }

        //Navigation property
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }

    }
}
