using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_code_first_tutorial.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;
        [StringLength(30), Required]
        public string City { get; set; } = String.Empty;
        [StringLength(2)]
        public string StateCode { get; set; } = "OH";
        [Column(TypeName = "decimal(9,2)")]
        public decimal Sales { get; set; }
        
        public bool Active { get; set; } = true;

        public virtual ICollection<Order> Orders { get; set; }

        public Customer(){ }


    }
}
