using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Core_Business.Entidades
{
	public class Vehiculo
	{
		[Key]
		public int idVehiculo { get; set; }
		public string? marca { get; set; }
		public string? modelo { get; set; }
		public float precio { get; set; }
		public DateTime fechaBaja { get; set; }






	}
}
