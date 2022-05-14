using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("MovieCrew")]
    public class MovieCrew
    {
        //pk and fk
        public int MovieId { get; set; }
        //pk and fk
        public int CrewId { get; set; }

        [MaxLength(128)]
        public string Department { get; set; }

        [MaxLength(128)]
        public string Job { get; set; }

        //Navigation property
        public Movie Movie { get; set; }
        public Crew Crew { get; set; }

    }
}
