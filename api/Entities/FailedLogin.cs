﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D1SoccerApi.Entities {
    [Table("FailedLogin")]
    public partial class FailedLogin {
	    [Key, MaxLength(255), Required]
	    public string Email { get; set; }
        public DateTime Attempt { get; set; }
    }
}
