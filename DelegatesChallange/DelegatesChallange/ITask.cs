using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesChallange
{
    internal  interface ITask<T>
    {
        T Perform();
    }
}
