using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DelegatesChallange
{
    internal class TaskProcessor<TTask, TResult> where TTask : ITask<TResult>
    {
        private TTask task;

        public TaskProcessor(TTask task)
        {
             this.task = task;
        }

        public TResult Execute()
        {
            return task.Perform();
        }
    }
}
