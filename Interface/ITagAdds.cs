namespace UploadTags.Interface
{
    public interface ITagAdds
    {
        public int Add(string tag);
        public IEnumerable<int> AddRange(IEnumerable<string> tags);
    }
}
