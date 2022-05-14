using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("Purchase")]
    public class Purchase
    {
        public int Id { get; set; }

        //fk
        public int UserId { get; set; }

        //fk
        public int MovieId { get; set; }

        public Guid PurchaseNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDateTime { get; set; }

        //Navigation property
        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
