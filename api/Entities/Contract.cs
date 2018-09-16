using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D1SoccerApi.Entities {
    [Table("Contract")]
    public partial class Contract {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [MaxLength(255), Required]
        public string ContractName { get; set; }
        
        [MaxLength(255), Required]
        public string ContractDisplayName { get; set; }
        
        [Required]
        public string ContractText { get; set; }
        
        public DateTime ContractValidStartDate { get; set; }
        public DateTime? ContractValidEndDate { get; set; }
        public DateTime SystemLoadDate { get; set; }

        public List<Waiver> Waivers { get; set; }
    }
}
