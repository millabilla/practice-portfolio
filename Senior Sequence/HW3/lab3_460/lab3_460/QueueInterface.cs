using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_460
{
    interface IQueueInterface<T> {
        T Push(T element);
        
        //needs to throw an exception
        T Pop();

        //needs to throw an exception

        T Peek();

        bool IsEmpty();
    }
}
