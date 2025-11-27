using System.Reflection.Metadata.Ecma335;

namespace DelegatesChallange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emailTask = new EmailTask()
            {
                Message = "Hello, this as a test email.",
                Recipient = "example.com"
            };

            var reportTask = new ReportTask()
            {
                ReportName = "Annual Report"
            };

            var emailProcessor = new TaskProcessor<EmailTask, string>(emailTask);
            var reportProcessor = new TaskProcessor<ReportTask, string>(reportTask);

            Console.WriteLine(emailProcessor.Execute());
            Console.WriteLine(reportProcessor.Execute());

        }
    }

}
