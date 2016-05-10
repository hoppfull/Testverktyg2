using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Testverktyg.Model;

namespace StudentApp.Controllers
{
    class QuestionTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SingleTemplate { get; set; }
        public DataTemplate MultiTemplate { get; set; }
        public DataTemplate RankedTemplate { get; set; }
        public DataTemplate OpenTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null) return null;
            FrameworkElement frameworkElement = container as FrameworkElement;
            if (frameworkElement != null)
            {
                var question = (Answer)item;
                //question.Question.QuestionType
                switch (question.Question.QuestionType)
                {
                    case QuestionType.Single:
                        return SingleTemplate;
                    case QuestionType.Multi:
                        return MultiTemplate;
                    case QuestionType.Ranked:
                        return RankedTemplate;
                    case QuestionType.Open:
                        return OpenTemplate;
                    default:
                        return null;
                }
            }
            else return null;
            
        }
    }
}
