using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using System.Threading.Tasks;

namespace lab3_460
{
    public class QueueUnderflowException : SystemException {

        public QueueUnderflowException(string message)
            :base(message)
        { }
    }
}
