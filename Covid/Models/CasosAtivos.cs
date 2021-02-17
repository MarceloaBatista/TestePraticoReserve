using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Covid.Models
{
    public class CasosAtivos
    {
        [DisplayName("País")]
        public string Pais { get; set; }

        [DisplayName("Total de Casos Ativos")]
        public int TotalCasosAtivos { get; set; }
    }
}
