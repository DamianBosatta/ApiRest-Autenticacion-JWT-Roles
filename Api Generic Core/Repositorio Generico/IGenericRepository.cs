using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Generic_Core
{
	public interface IGenericRepository<T> where T : class
	{
		IEnumerable<T> GetAll();
		T GetById(int? id);
		void Insert(T entity);
		void Update(T entity);
		void Delete(int? entity);




	}
}
