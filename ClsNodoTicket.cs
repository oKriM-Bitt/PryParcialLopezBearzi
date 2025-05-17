using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuebloGrill
{
    class ClsNodoTicket
    {
            
        public int NumeroTicket { get; set; }
        public DateTime FechaHora { get; set; }
        public string Mesa { get; set; }
        public string MedioPago { get; set; }
        public decimal Total { get; set; }

        public ClsNodoTicket Siguiente { get; set; }
    }
}

