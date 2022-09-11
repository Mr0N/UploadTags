
namespace UploadTags.Service
{
    public interface IUploadTagsService
    {
        void StartAddTags(int nodeId, IEnumerable<string> infoTags);
    }
}