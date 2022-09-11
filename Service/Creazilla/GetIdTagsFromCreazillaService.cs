using UploadTags.Interface;
using System.Net.Http;
using Newtonsoft.Json;
using UploadTags.Models;
using System.Text;

namespace UploadTags.Service.Creazilla
{

    public class GetIdTagsFromCreazillaService : ITagsId
    {
       
        public IEnumerable<int> Get(int nodeId)
        {

            string json = _client.GetAsync($"https://test.com/{nodeId}")?
                 .Result
                 ?.Content
                 ?.ReadAsStringAsync()
                 ?.Result;
            if (json is null)
                throw new Exception("Not received json from site,json equals is null");
            return JsonConvert.DeserializeObject<InfoTagsModel>(json)
                .tags.Select(a =>
                {
                    if (!a.id.HasValue)
                        throw new Exception("Site send not correct format id tags");
                    return a.id.Value;
                }); ;
            //return null;
        }
        HttpClient _client;
        public GetIdTagsFromCreazillaService(HttpClient client)
        {
            _client = client;
        }
    }

}
