using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D1SoccerApi.Entities {
    [Table("Team")]
    public partial class Team {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [MaxLength(255), Required]
        public string TeamName { get; set; }

        [MaxLength(50), Required]
        public string TeamColor { get; set; }
        
        public int? CaptainUserId { get; set; }
        public int SeasonId { get; set; }
        public DateTime SystemLoadDate { get; set; }
        public DateTime SystemUpdateDate { get; set; }
        
        [ForeignKey("SeasonId")]
        public Season Season { get; set; }
        
        [ForeignKey("CaptainUserId")]
        public User User { get; set; }
    }
}
