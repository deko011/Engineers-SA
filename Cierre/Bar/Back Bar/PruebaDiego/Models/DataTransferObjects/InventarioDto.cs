using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDiego.Models.DataTransferObjects
{
    public class InventarioDto
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string producto { get; set; }
        public string cantidad { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public DateTime fecha_salida { get; set; }
        public string sedes { get; set; }

    }
}
