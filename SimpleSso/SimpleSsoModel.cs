using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSso
{
    public class SimpleSsoModel
    {
        public string Token { get; set; }
        public string LoginId { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public string Source { get; set; }

    }
}
