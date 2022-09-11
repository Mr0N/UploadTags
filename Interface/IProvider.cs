using UploadTags.Models;

namespace UploadTags.Interface
{
    public interface IProvider<Info,InfoId>
    {
        public (InfoId,IEnumerable<Info>) Get();
        /// <summary>
        ///Якщо 1 то елементи є, якщо не то елементів немає
        /// </summary>
        /// <returns></returns>
        public bool MoveNext();
    }
}
