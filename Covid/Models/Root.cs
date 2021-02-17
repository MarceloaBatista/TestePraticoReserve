using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid.Models
{
    public class Root
    {
      public string ID { get; set; }
      public string Message { get; set; }
      public GlobalModel Global { get; set; }
      public List<CountryModel> Countries { get; set; }
      public DateTime Date { get; set; }
    }
}
