using Microsoft.Extensions.Hosting;
using UploadTags.Interface;
using UploadTags.Service;

namespace UploadTags
{
    public class Startup : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                _worker.Start();
            }
            return Task.CompletedTask;
        }
        IWorker _worker;
        public Startup(IWorker worker)
        {
            _worker = worker;
        }
    }
}
