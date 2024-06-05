using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Configurations
{
    public class TokenServiceOptions
    {
        public string Key { get; set; }
        public string Issuer { get; set; }

        public TokenServiceOptions()
        {
            // Optionally initialize properties if necessary
            Key = "default_key";
            Issuer = "default_issuer";
        }
    }
}
