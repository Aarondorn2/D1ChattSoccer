using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D1SoccerApi.Entities {
    [Table("Manual_User_Season")]
    public partial class ManualUserSeason {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [MaxLength(255), Required]
        public string UserName { get; set; }
        
        public bool HasPaid { get; set; }
        public bool HasWaiver { get; set; }
        public int SeasonId { get; set; }
        public int? TeamId { get; set; }
        public DateTime SystemLoadDate { get; set; }
        public DateTime SystemUpdateDate { get; set; }
        
        [ForeignKey("SeasonId")]
        public Season Season { get; set; }
        
        [ForeignKey("TeamId")]
        public Team Team { get; set; }
    }
}
