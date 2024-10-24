using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankapp.bankapp.exception
{

	[Serializable]
	public class bankappException : Exception
	{
		public bankappException() { }
		public bankappException(string message) : base(message) { }
		public bankappException(string message, Exception inner) : base(message, inner) { }
		protected bankappException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
