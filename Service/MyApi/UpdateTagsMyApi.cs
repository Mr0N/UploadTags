using ApiUpdateTags;
using UploadTags.Interface;

namespace UploadTags.Service.MyApi
{
    public class UpdateTagsMyApi : IUpdateTags
    {
        public int Set(int nodeId, IEnumerable<int> TagsId)
        {
            if (!TagsId.Any())
            {
                Console.WriteLine("Empty");
                return nodeId;
            }
           string text =  _client
                .PostAsJsonAsync<NodeInfoDto>($"http://localhost:5000/UpdateTags/set?nodeId={nodeId}", new NodeInfoDto() { Tags = TagsId.ToList() })
                .Result.Content.ReadAsStringAsync().Result;
            return nodeId;
        }
        HttpClient _client;
  
        public UpdateTagsMyApi(HttpClient client)
        {
            _client = client;
        
        }
    }
}
