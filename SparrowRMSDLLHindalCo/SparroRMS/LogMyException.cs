using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowRMS
{
   public class LogMyException
    {
        public string Message
        {
            get;
            set;
        }
        /// <summary>
        /// This is use for Custom Exeption
        /// </summary>
        /// <param name="message"> Pass Call Message Name</param>
        public LogMyException(string message)
        {
            Message = message;
        }
    }
}
