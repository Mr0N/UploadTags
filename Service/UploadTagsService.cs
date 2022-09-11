using UploadTags.Interface;
using UploadTags.Models;

namespace UploadTags.Service
{
    public class UploadTagsService : IUploadTagsService
    {
        public void StartAddTags(int nodeId, IEnumerable<string> infoTags)
        {
            HashSet<int> ls = new HashSet<int>();
            var idTagsFromSite = _providerInfoTags.Get(nodeId);
            
            foreach (var item in idTagsFromSite)
                ls.Add(item);
            if (ls.Contains(18593525))
                throw new Exception("Skip tags");
            _logger.LogInformation($"NODE:{nodeId} | {string.Join(',',infoTags) } => {string.Join(',',ls)}");
            var result = _tagAdds.AddRange(infoTags);
            foreach (var item in result)
                ls.Add(item);
            _updateTags.Set(nodeId, ls);
        }
        ITagsId _providerInfoTags;
        ITagAdds _tagAdds;
        IUpdateTags _updateTags;
        ILogger<UploadTagsService> _logger;
        public UploadTagsService(ITagsId providerIdTags,
                                    ITagAdds tagAdds,
                                    IUpdateTags updateTags,ILogger<UploadTagsService> logger)
        {
            _providerInfoTags = providerIdTags;
            _tagAdds = tagAdds;
            _updateTags = updateTags;
            _logger = logger;
        }
    }
}
