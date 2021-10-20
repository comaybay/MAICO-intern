using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestEFCore.Models
{
    public class Response
    {
        public bool Success { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
    }
}
