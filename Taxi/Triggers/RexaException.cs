using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Triggers

{
    [Serializable]
    class RexaException : Exception
    {
        public RexaException() { }

        // TODO log errors
        public RexaException(string Message) : base(Message) { }
    }
}
