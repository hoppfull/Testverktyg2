﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace Testverktyg.Model {
    public class AnsweredQuestion {
        [Key]
        public int Id { get; set; }
        public Question Question { get; set; }
    }
}
