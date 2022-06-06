using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Core_Business.Entidades
{
	public class Cliente
	{
		[Key]
		public int idCliente { get; set; }
		public string? nombre { get; set; }
		public int dni { get; set; }
		public string? direccion { get; set; }



	}
}

