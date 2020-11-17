using DataService.DAL.CustomTypes;

namespace DataService.BLL.DTO
{
    public class BookmarkForCreateDto
    {
        public int UserId { get; set; }
        public BookmarkType BookmarkType { get; set; }
        public string TypeId { get; set; }
    }
}
