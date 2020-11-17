using DataService.DAL.CustomTypes;

namespace DataService.DAL.DMO
{
    public class Bookmarks
    {
        public int UserId { get; set; }
        public BookmarkType BookmarkType { get; set; }
        public string TypeId { get; set; }
        public virtual Users User { get; set; }
        public virtual Titles Title { get; set; }
    }
}