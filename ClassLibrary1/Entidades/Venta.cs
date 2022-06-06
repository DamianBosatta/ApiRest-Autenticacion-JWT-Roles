using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Core_Business.Entidades
{
	public class Venta
	{
		[Key]
		public int idVentas { get; set; }
		public string? importe { get; set; }
		public int descuento { get; set; }
		public DateTime fecha { get; set; }

		[ForeignKey("Vehiculo")]
		public int idVehiculo { get; set; }
		public Vehiculo? vehiculo { get; set; }

		[ForeignKey("Cliente")]
		public int idCliente { get; set; }
		public Cliente? Cliente { get; set; }



	}
}
