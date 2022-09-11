using Newtonsoft.Json;
using UploadTags.Interface;
using UploadTags.Models;
using System.Text.Json;
using System.Text;

namespace UploadTags.Service.Creazilla
{
    
    
    public class UpdateTagsObj : IUpdateTags
    {
        public int Set(int nodeId, IEnumerable<int> TagsId)
        {
     

            return UpdateTags(nodeId, TagsId).Result;
        }
        public async Task<int> UpdateTags(int nodeId,IEnumerable<int> tagId)
        {
          
           
            var node = new NodeUpdate()
            {
                node = new Node()
                {
                    tag_ids = tagId
                }
            };
            string retJson = JsonConvert.SerializeObject(node);
            var content = new StringContent(retJson, Encoding.UTF8, "application/json");
            var obj = await _client
                .PutAsync($"https://test.com/{nodeId}", content);
            string json = await  obj.Content.ReadAsStringAsync();
            try
            {
                int id = JsonConvert.DeserializeObject<UpdateTagsDto>(json).id.Value;
                return id;
            }
            catch {
                throw
                     new Exception(json);
            }
           // return null;
        }
        HttpClient _client;
        Config _config;
        public UpdateTagsObj(HttpClient client, Config config)
        {
            _client = client;
            _config = config;
            _client.DefaultRequestHeaders.Add("UserAgent", "1234567");
        }
    }
}
