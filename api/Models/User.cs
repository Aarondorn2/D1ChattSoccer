using D1SoccerService.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace D1SoccerService.Models {
    public class User {

        [JsonIgnore]
        public string Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("dob")]
        public DateTime Dob { get; set; }

        [JsonProperty("shirtSize")]
        public string ShirtSize { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("isKeeper")]
        public bool IsKeeper { get; set; }

        [JsonProperty("isOffense")]
        public bool IsOffense { get; set; }

        [JsonProperty("isDefense")]
        public bool IsDefense { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("emergencyContact")]
        public string EmergencyContact { get; set; }

        [JsonProperty("emergencyContactPhone")]
        public string EmergencyContactPhone { get; set; }

        [JsonProperty("userType")]
        public string UserType { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("systemLoadDate")]
        public DateTime SystemLoadDate { get; set; }

        [JsonProperty("systemUpdateDate")]
        public DateTime SystemUpdateDate { get; set; }


        [JsonProperty("userSeasons")]
        public ICollection<UserSeasons> UserSeasons { get; set; }
    }
}
