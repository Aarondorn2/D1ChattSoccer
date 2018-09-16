using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D1SoccerApi.Entities {
    [Table("Season")]
    public partial class Season {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(255), Required]
        public string Name { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RegistrationStartDate { get; set; }
        public DateTime RegistrationEndDate { get; set; }
        public DateTime SystemLoadDate { get; set; }
        public DateTime SystemUpdateDate { get; set; }
        
        public virtual List<ManualUserSeason> ManualUserSeasons { get; set; }
        public virtual List<UserSeason> UserSeasons { get; set; }
        public virtual List<Team> Teams { get; set; }
    }
}
