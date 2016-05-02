﻿using System.ComponentModel.DataAnnotations;

namespace Testverktyg.Model {
    public class Answer {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public int CheckedOrRanked { get; set; }
        public Answer(string text, int checkedOrRanked) {
            Text = text;
            CheckedOrRanked = checkedOrRanked;
        }
    }
}