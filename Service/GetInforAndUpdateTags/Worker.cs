using Newtonsoft.Json;
using TagsGenerator.Model;
using UploadTags.Interface;
using UploadTags.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace UploadTags.Service.GetInforAndUpdateTags
{
    public class Worker : IWorker
    {
    
        public void Start()
        {
            var result = _infoTags
                 .infos
                 .Where(a => a.isGood == true &&
                                a.UniqueIdBlock != null &&
                             a.TagsMachineTags != null &&
                             a.TagsPhotoCli != null &&
                             a.TagsMachineTags != "null" &&
                             a.TagsPhotoCli != "" &&
                             a.UniqueIdBlock != "GoodUpload" &&
                             a.UniqueIdBlock != "ErrorUpload").Take(20).Include(a => a.MessageException);
            if (!result.Any())
                throw new Exception();
            var tasks = new List<Task>();

            foreach (var item in result)
            {
                count++;
                _logger.LogInformation($"Count upload tags:{count} " +
                    $"Time:{_stopwatch.Elapsed.TotalSeconds}" +
                    $"speed per minute:{(count/_stopwatch.Elapsed.TotalSeconds)*60}");
                var task = Task.Run(() => {
                    using var scope = _scopeFactory.CreateScope();
                    var tagsUpdate = scope.ServiceProvider.GetService<UpdateTags>();
                    tagsUpdate.UploadTagsToDb(item);
                });
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray()) ;
            _infoTags.SaveChanges();
                
            
        }
        static int count;
        static Stopwatch _stopwatch;
        static Worker()
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        TagsDbContext _infoTags;
        ILogger<Worker> _logger;
        IServiceScopeFactory _scopeFactory;
        public Worker(
            TagsDbContext infoTags,
            ILogger<Worker> logger,
            IServiceScopeFactory  scopeFactory)
        {
            _infoTags = infoTags;
            _logger = logger;
            _scopeFactory = scopeFactory;
        }
    }
}
