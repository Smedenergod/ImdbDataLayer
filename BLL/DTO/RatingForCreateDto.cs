﻿
namespace DataService.BLL.DTO
{
    public class RatingForCreateDto
    {
        public int UserId { get; set; }
        public string TitleId { get; set; }
        public float Score { get; set; }
    }
}
