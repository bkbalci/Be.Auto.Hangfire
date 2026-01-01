namespace Sample.Test
{
    public class AppointmentSmsNotificationService(string url) : IAppointmentSmsNotificationService
    {
        public async Task SendSms(string delayTime)
        {
            var id = Guid.NewGuid();
            Console.WriteLine(id);
            var source = new CancellationTokenSource();
            await Task.Delay(5000, source.Token);
        }

        public async Task SendSms(string delayTime, bool start, int count)
        {
            var id = Guid.NewGuid();
            Console.WriteLine(id);
            var source = new CancellationTokenSource();
            await Task.Delay(5000, source.Token);
        }

        public async Task SendSms(TestClass test, string delayTime, DateTime next)
        {
            var id = Guid.NewGuid();
            Console.WriteLine(id);
            var source = new CancellationTokenSource();
            await Task.Delay(5000, source.Token);
        }

        public async Task SendSmsWithCancellation(string message, int delaySeconds, CancellationToken cancellationToken)
        {
            try
            {
                var jobId = Guid.NewGuid();
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Job {jobId} started - Message: {message}");

                for (var i = 0; i < delaySeconds; i++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Job {jobId} - Working... {i + 1}/{delaySeconds}");
                    await Task.Delay(1000, cancellationToken);
                }

                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Job {jobId} completed successfully!");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("OperationCanceledException");
                throw;
            }
        }
    }
}
