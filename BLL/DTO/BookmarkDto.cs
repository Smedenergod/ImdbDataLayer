using DataService.DAL.CustomTypes;

namespace DataService.BLL.DTO
{
    public class BookmarkDto
    {
        public int UserId { get; set; }
        public BookmarkType BookmarkType { get; set; }
        public string TypeId { get; set; }
    }
}
