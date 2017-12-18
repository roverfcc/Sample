using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Models
{
    public class SampleInputModel
    {
        public string Band1 { get; internal set; }
        public string Band2 { get; internal set; }
        public string Band3 { get; internal set; }
        public string Multiplier { get; internal set; }
        public string Tolerance { get; internal set; }
        public string Temperature { get; internal set; }
    }

}