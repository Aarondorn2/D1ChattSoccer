using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace D1SoccerApi {
    public static class Extensions {

        // DICTIONARY
        public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue)) {
            if (dictionary == null) { throw new ArgumentNullException(nameof(dictionary)); }
            if (key == null) { throw new ArgumentNullException(nameof(key)); }
            
            return dictionary.TryGetValue(key, out TValue value) ? value : defaultValue;
        }

        // PRINCIPAL
        public static JwtIdentity AsJwtIdentity(this ClaimsPrincipal principal) {
            if (principal == null) { throw new ArgumentNullException(nameof(principal)); }

            return new JwtIdentity(principal);
        }
    }
}
