using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Sources;

namespace DelegatesChallange
{
    internal class EmailTask : ITask<string>
    {
        public string Recipient { get; set; }
        public string Message { get; set; }

        public string Perform()
        {
            return  $"Email sent to {Recipient} with message {Message}";
        }
    }

}
