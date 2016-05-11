using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Model;

namespace StudentApp
{
    public class DisplayedTest
    {
        public DisplayedTest(TestForm tf)
        {
            this.Title = tf.TestDefinition.Title;
            this.Score = tf.Score;
            this.Grade = Testverktyg.Controllers.Controller.CalcGrade(tf).ToString();
            this.CompletionTime = tf.FinishedDate.HasValue && tf.StartDate.HasValue
                    ? tf.FinishedDate.Value.Minute - tf.StartDate.Value.Minute
                    : 0;
        }
        public string Title { get; set; }
        public int Score { get; set; }
        public string Grade { get; set; }
        public int CompletionTime { get; set; }
    }
}
