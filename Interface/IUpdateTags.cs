namespace UploadTags.Interface
{
    public interface IUpdateTags
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="TagsId"></param>
        /// <returns>id from creazilla</returns>
        public int Set(int nodeId, IEnumerable<int> TagsId);
    }
}
