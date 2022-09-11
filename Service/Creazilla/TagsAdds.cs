using api;
using api.Buffer;
using UploadTags.Interface;
using System.Collections.Concurrent;

namespace UploadTags.Service.Creazilla
{
    public class TagsAdds : ITagAdds
    {
        public int Add(string tag)
        {
            if (_dict.TryGetValue(tag, out var idTag))
            {
                return idTag;
            }
            var id = _buffer.CreateTagAsync(new List<string>() { tag }).Result.FirstOrDefault().id;
            _dict.TryAdd(tag, id);
            return id;
        }

        public IEnumerable<int> AddRange(IEnumerable<string> tags)
        {
            List<int> ls = new List<int>();
            foreach (var item in tags)
            {
                ls.Add(this.Add(item));
            }
            return ls;
        }
        Buffer_api _buffer;
        ConcurrentDictionary<string, int> _dict;
        public TagsAdds(Buffer_api buffer, ConcurrentDictionary<string, int> dict)
        {
            _buffer = buffer;
            _dict = dict;
        }
    }
}
