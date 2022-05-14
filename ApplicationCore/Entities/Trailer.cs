using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("Trailer")]
    public class Trailer
    {
        public int Id { get; set; }

        //foregin key, principle table is movie
        public int MovieId { get; set; }

        [MaxLength(2084)]
        public string? TrailerUrl { get; set; }

        [MaxLength(2084)]
        public string? Name { get; set; }

        //Navigagtion property
        public Movie Movie { get; set; }
    }
}
