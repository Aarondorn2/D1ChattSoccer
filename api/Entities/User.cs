using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D1SoccerApi.Entities {
    [Table("User")]
    public partial class User {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(255), Required]
        public string Email { get; set; }
        
        [MaxLength(255), Required]
        public string FirstName { get; set; }
        
        [MaxLength(255), Required]
        public string LastName { get; set; }
        
        public UserType UserType { get; set; }
        public bool IsEmailVerified { get; set; }
        public int? UserInfoId { get; set; }
        public DateTime SystemLoadDate { get; set; }
        public DateTime SystemUpdateDate { get; set; }

        [ForeignKey("UserInfoId")]
        public UserInfo UserInfo { get; set; }
        public List<UserSeason> UserSeasons { get; set; }
    }
}
