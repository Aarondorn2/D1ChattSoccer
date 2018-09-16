using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D1SoccerApi.Entities {
    [Table("User_Info")]
    public partial class UserInfo {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(55)]
        public string Phone { get; set; }

        [MaxLength(255)]
        public string EmergencyContact { get; set; }

        [MaxLength(55)]
        public string EmergencyContactPhone { get; set; }
        
        public DateTime Dob { get; set; }

        [MaxLength(25)]
        public string Gender { get; set; }

        [MaxLength(25)]
        public string ShirtSize { get; set; }
        
        public bool IsDefense { get; set; }
        public bool IsKeeper { get; set; }
        public bool IsOffense { get; set; }
        public DateTime SystemLoadDate { get; set; }
        public DateTime SystemUpdateDate { get; set; }
    }
}
