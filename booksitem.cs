using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace booksapi.models
{
    public class booksitem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
