using System.Collections.Generic;

namespace DataService.BLL.DTO
{
    public class CastDto
    {
        public string TitleId { get; set; }
        public int Ordering { get; set; }
        public string CastId { get; set; }
        public string Category { get; set; }
        public string? Job { get; set; }
        public string? CharName { get; set; }
        public string Url { get; set; }
        public Dictionary<string, string> TitleIdUrlDictionary; //Needs support somehow.
    }
}
