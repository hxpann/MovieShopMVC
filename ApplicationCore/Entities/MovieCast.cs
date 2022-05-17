using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("MovieCast")]

    public class MovieCast
    {
        //pk and fk
        public int MovieId { get; set; }

        //pk and fk
        public int CastId { get; set; }

        //pk
        [MaxLength(450)]
        public string Character { get; set; }

        //Navigation property
        public Movie Movie { get; set; }
        public Cast Cast { get; set; }


    }
}
