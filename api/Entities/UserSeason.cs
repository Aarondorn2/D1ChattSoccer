using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D1SoccerApi.Entities {
    [Table("User_Season")]
    public partial class UserSeason {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int UserId { get; set; }
        public int SeasonId { get; set; }
        public bool HasPaid { get; set; }
        public int? TeamId { get; set; }
        public int? WaiverId { get; set; }
        public DateTime SystemLoadDate { get; set; }
        public DateTime SystemUpdateDate { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }
        
        [ForeignKey("SeasonId")]
        public Season Season { get; set; }
        
        [ForeignKey("TeamId")]
        public Team Team { get; set; }

        [ForeignKey("WaiverId")]
        public Waiver Waiver { get; set; }
    }
}
