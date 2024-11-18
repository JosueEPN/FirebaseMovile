using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Models
{
    public class Medicamento
    {
        public string Id { get; set; } // Se genera automáticamente
        public string Nombre { get; set; }
        public int Unidades { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public bool Estado { get; set; } // True: Disponible, False: No disponible
    }
}
