﻿namespace IMDBDataService.DMO
{
    public class FlaggedComment
    {
        public int CommentId { get; set; }
        public virtual Comments Comment { get; set; }
        public int FlaggingUser { get; set; }
        public virtual Users User { get; set; }
    }
}
