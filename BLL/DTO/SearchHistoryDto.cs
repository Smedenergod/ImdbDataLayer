using System;

namespace DataService.BLL.DTO
{
    public class SearchHistoryDto
    {
        public int UserId { get; set; }
        public int Ordering { get; set; }
        public DateTime SearchTime { get; set; }
        public string SearchString { get; set; }
    }
}
