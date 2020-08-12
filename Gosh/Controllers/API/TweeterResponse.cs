using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gosh.Controllers.API
{
    public class TweeterResponse
    {

        public long Date { get; set; }
        public string CreatorName { get; set; }

        public string CreatorImageUrl { get; set; }

        public string Type;

        public string UpdateText { get; set; }

        public string UpdateUrl { get; set; }

        public string UpdateImage { get; set; }
    }
}