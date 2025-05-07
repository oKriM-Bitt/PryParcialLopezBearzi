using System; // Necesario para DateTime
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PryPueblox
{
 public   class OrderHeaderInfo
    {
        public int NumeroMesa { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public int IdNumeroTicket { get; set; }
    }
}
