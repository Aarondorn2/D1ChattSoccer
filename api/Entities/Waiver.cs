using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D1SoccerApi.Entities {
    [Table("Waiver")]
    public partial class Waiver {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [MaxLength(255), Required]
        public string AcceptedName { get; set; }

        [MaxLength(255), Required]
        public string AcceptedEmail { get; set; }

        [MaxLength(255), Required]
        public string AcceptedIpaddress { get; set; }
        
        public bool HasAccepted { get; set; }
        public int UserSeasonId { get; set; }
        public int ContractId { get; set; }
        public DateTime AcceptedDate { get; set; }
        public DateTime SystemLoadDate { get; set; }
        
        [ForeignKey("UserSeasonId")]
        public UserSeason UserSeason { get; set; }
    }
}
