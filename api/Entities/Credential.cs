using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D1SoccerApi.Entities {
    [Table("Credential")]
    public partial class Credential {
        [Key, MaxLength(255), Required]
        public string Email { get; set; }
        
        [MaxLength(255), Required]
        public string Password { get; set; }

		public DateTime LastLogin { get; set; }
    }
}
