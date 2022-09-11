using Newtonsoft.Json;
using TagsGenerator.Model;
using UploadTags.Interface;
using UploadTags.Models;
using Microsoft.EntityFrameworkCore;

namespace UploadTags.Service.GetInforAndUpdateTags
{
    public class UpdateTags
    {
        public (int nodeId, List<string> tags) Convert(Info info)
        {
            var tagMachine = JsonConvert.DeserializeObject<TagsMachine.Model.TagMachine>(info.TagsMachineTags);
            if (tagMachine.Error is not null)
            {

                info.MessageException.Add(new ExceptionMessage()
                {
                    Message = tagMachine.Error?.Details ?? "Exception"
                });
            }
            var tagPhotoCli = JsonConvert.DeserializeObject<List<TagPhotoCliModel>>(info.TagsPhotoCli);
            tagPhotoCli = tagPhotoCli.Where(a => a.Probability == 1).ToList();
            List<string> tag = new List<string>();
            tag.AddRange(tagMachine.FoundTags);
            tag.AddRange(tagPhotoCli.Select(a => a.Tag));
            return (info.idFromCreazilla, tag.DistinctBy(a => a.ToLower()).ToList()); ;
        }
        public void UploadTagsToDb(Info? item)
        {
            try
            {
                _logger.LogInformation("UploadTagsToDb Start");
                var obj = Convert(item);
                    _uploadTags.StartAddTags(obj.nodeId, obj.tags);
                    item.UniqueIdBlock = "GoodUpload";
                _logger.LogInformation("UploadTagsToDb End");
            }
            catch (Exception ex)
            {
                item.UniqueIdBlock = "ErrorUpload";
                item.MessageException.Add(new ExceptionMessage() { Message = ex.Message });
            }
        }
        ILogger<UpdateTags> _logger;
        IUploadTagsService _uploadTags;
        public UpdateTags(
            ILogger<UpdateTags> logger, IUploadTagsService uploadTags)
        {
            _uploadTags = uploadTags;
            _logger = logger;
        }
    }
}
