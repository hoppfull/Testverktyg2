using System;
using System.Collections.Generic;
using Testverktyg.Context;
using Testverktyg.Model;
using System.Data.Entity;

namespace Testverktyg
{
    public static class MockData
    {
        private static void DeleteAndRecreate()
        {
            using (var db = new TestverktygContext())
            {
                db.Database.Delete();
                db.Database.CreateIfNotExists();
            }
        }

        private static void Seed()
        {
            //Create Users
            var stud1 = new StudentAccount { Name = "Student1", Email = "Student1", Password = "a", TestForms = new List<TestForm>() };
            var stud2 = new StudentAccount { Name = "Student2", Email = "Student2", Password = "a", TestForms = new List<TestForm>() };
            var stud3 = new StudentAccount { Name = "Student3", Email = "", Password = "a", TestForms = new List<TestForm>() };
            var admin1 = new AdminAccount { Name = "Admin1", Email = "Admin1", Password = "a", };
            var admin2 = new AdminAccount { Name = "Admin2", Email = "Admin2", Password = "a", };
            var admin3 = new AdminAccount { Name = "Admin3", Email = "Admin3", Password = "a", IsNotRemoved = false };
            var teacher1 = new TeacherAccount { Name = "Teacher1", Email = "Teacher1", Password = "a", TestDefinitions = new List<TestDefinition>() };
            var teacher2 = new TeacherAccount { Name = "Teacher2", Email = "Teacher2", Password = "a", TestDefinitions = new List<TestDefinition>() };
            var teacher3 = new TeacherAccount { Name = "Teacher3", Email = "Teacher3", Password = "a", TestDefinitions = new List<TestDefinition>(), IsNotRemoved = true };

            //Create Subject
            var sub1 = new Subject { Name = "Initial" };
            var sub2 = new Subject { Name = "SystemUtveckling" };
            var sub3 = new Subject { Name = "Naturvetenskap" };
            var sub4 = new Subject { Name = "Litteratur" };

            //Create TestDefinition
            var test1 = new TestDefinition { Title = "DatabasProv", Subject = sub2, Paragraph = "1", TestDefinitionState = TestDefinitionState.Created, Questions = new List<Question>() };
            var test2 = new TestDefinition { Title = "MatteprovProv", Subject = sub3, Paragraph = "1", TestDefinitionState = TestDefinitionState.Sent, Questions = new List<Question>() };
            var test3 = new TestDefinition { Title = "FysikProv", Subject = sub3, Paragraph = "1", TestDefinitionState = TestDefinitionState.Created, Questions = new List<Question>() };
            var test4 = new TestDefinition { Title = "SvenskaProv", Subject = sub4, Paragraph = "1", TestDefinitionState = TestDefinitionState.Sent, Questions = new List<Question>() };
            var test5 = new TestDefinition { Title = "ProgrammeringsProv", Subject = sub2, Paragraph = "1", TestDefinitionState = TestDefinitionState.Created, Questions = new List<Question>() };
            var test6 = new TestDefinition { Title = "TestProv", Subject = sub1, Paragraph = "1", TestDefinitionState = TestDefinitionState.Created, Questions = new List<Question>() };

            //Create TestForms

            var testForms1 = new TestForm { TimeLimit = 1, FinalDate = new DateTime(2016, 10, 01), TestDefinition = test1 };
            var testForms2 = new TestForm { TimeLimit = 30, FinalDate = new DateTime(2016, 08, 01), TestDefinition = test1 };
            var testForms3 = new TestForm { TimeLimit = 30, FinalDate = new DateTime(2016, 08, 01), TestDefinition = test2 };
            var testForms4 = new TestForm { TimeLimit = 30, FinalDate = new DateTime(2016, 08, 01), TestDefinition = test2 };
            var testForms5 = new TestForm { TimeLimit = 30, FinalDate = new DateTime(2016, 08, 01), TestDefinition = test3 };
            var testForms6 = new TestForm { TimeLimit = 30, FinalDate = new DateTime(2016, 08, 01), TestDefinition = test3 };
            var testForms7 = new TestForm { TimeLimit = 30, FinalDate = new DateTime(2016, 08, 01), TestDefinition = test4 };
            var testForms8 = new TestForm { TimeLimit = 30, FinalDate = new DateTime(2016, 08, 01), TestDefinition = test4 };
            var testForms9 = new TestForm { TimeLimit = 30, FinalDate = new DateTime(2016, 08, 01), TestDefinition = test5 };
            var testForms10 = new TestForm { TimeLimit = 30, FinalDate = new DateTime(2016, 08, 01), TestDefinition = test5 };
            var testForms11 = new TestForm { TimeLimit = 30, FinalDate = new DateTime(2016, 08, 01), TestDefinition = test6 };
            var testForms12 = new TestForm { TimeLimit = 30, FinalDate = new DateTime(2016, 08, 01), TestDefinition = test6 };

            //Create Questions
            var question1 = new Question { QuestionType = QuestionType.Single, Text = "Adele?", Score = 5, Answers = new List<Answer>(), TestDefinition = test1};
            var question2 = new Question { QuestionType = QuestionType.Single, Text = "MY TEAM?", Score = 4, Answers = new List<Answer>(), TestDefinition = test2 };
            var question3 = new Question { QuestionType = QuestionType.Multi, Text = "1", Score = 3, Answers = new List<Answer>(), TestDefinition = test1 };
            var question4 = new Question { QuestionType = QuestionType.Multi, Text = "1", Score = 2, Answers = new List<Answer>(), TestDefinition = test2 };
            var question7 = new Question { QuestionType = QuestionType.Open, Text = "i am OPEN LIKE A BOOK xDdpppppp", Score = 3, Answers = new List<Answer>(), TestDefinition = test1 };
            var question8 = new Question { QuestionType = QuestionType.Open, Text = "1", Score = 4, Answers = new List<Answer>(), TestDefinition = test2 };

            var question9 = new Question { QuestionType = QuestionType.Single, Text = "Katt?", Score = 5, Answers = new List<Answer>(), TestDefinition = test3 };
            var question10 = new Question { QuestionType = QuestionType.Single, Text = "Hello?", Score = 4, Answers = new List<Answer>(), TestDefinition = test4 };
            var question11 = new Question { QuestionType = QuestionType.Multi, Text = "1", Score = 3, Answers = new List<Answer>(), TestDefinition = test3 };
            var question12 = new Question { QuestionType = QuestionType.Multi, Text = "1", Score = 2, Answers = new List<Answer>(), TestDefinition = test4 };
            var question15 = new Question { QuestionType = QuestionType.Open, Text = "1", Score = 3, Answers = new List<Answer>(), TestDefinition = test3 };
            var question16 = new Question { QuestionType = QuestionType.Open, Text = "1", Score = 4, Answers = new List<Answer>(), TestDefinition = test4 };

            var question17 = new Question { QuestionType = QuestionType.Single, Text = "Jag är en fråga", Score = 5, Answers = new List<Answer>(), TestDefinition = test5 };
            var question18 = new Question { QuestionType = QuestionType.Single, Text = "??", Score = 4, Answers = new List<Answer>(), TestDefinition = test6 };
            var question19 = new Question { QuestionType = QuestionType.Multi, Text = "1", Score = 3, Answers = new List<Answer>(), TestDefinition = test5};
            var question20 = new Question { QuestionType = QuestionType.Multi, Text = "1", Score = 2, Answers = new List<Answer>(), TestDefinition = test6 };
            var question23 = new Question { QuestionType = QuestionType.Open, Text = "1", Score = 3, Answers = new List<Answer>(), TestDefinition = test5 };
            var question24 = new Question { QuestionType = QuestionType.Open, Text = "1", Score = 4, Answers = new List<Answer>(), TestDefinition = test6 };

            //Create Student Question and Answers

           
            //Single
            question1.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 1 });
            question1.Answers.Add(new Answer { Text = "2", CheckedOrRanked = 0 });
            question1.Answers.Add(new Answer { Text = "3", CheckedOrRanked = 0 });

            question2.Answers.Add(new Answer { Text = "4", CheckedOrRanked = 0 });
            question2.Answers.Add(new Answer { Text = "5", CheckedOrRanked = 1 });
            question2.Answers.Add(new Answer { Text = "6", CheckedOrRanked = 0 });

            question9.Answers.Add(new Answer { Text = "7", CheckedOrRanked = 0 });
            question9.Answers.Add(new Answer { Text = "8", CheckedOrRanked = 0 });
            question9.Answers.Add(new Answer { Text = "9", CheckedOrRanked = 1 });

            question10.Answers.Add(new Answer { Text = "10", CheckedOrRanked = 1 });
            question10.Answers.Add(new Answer { Text = "11", CheckedOrRanked = 0 });
            question10.Answers.Add(new Answer { Text = "12", CheckedOrRanked = 0 });

            question17.Answers.Add(new Answer { Text = "13", CheckedOrRanked = 0 });
            question17.Answers.Add(new Answer { Text = "14", CheckedOrRanked = 1 });
            question17.Answers.Add(new Answer { Text = "15", CheckedOrRanked = 0 });

            question18.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 0 });
            question18.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 0 });
            question18.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 1 });

            //Multi
            question3.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 1 });
            question3.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 1 });
            question3.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 0 });

            question4.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 1 });
            question4.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 0 });
            question4.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 1 });

            question11.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 0 });
            question11.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 1 });
            question11.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 1 });

            question12.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 1 });
            question12.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 0 });
            question12.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 1 });

            question19.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 1 });
            question19.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 1 });
            question19.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 0 });

            question20.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 0 });
            question20.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 1 });
            question20.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 1 });

            //Ranked

            question4.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 1 });
            question4.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 2 });
            question4.Answers.Add(new Answer { Text = "1", CheckedOrRanked = 3 });

           

            //Single
           

            
            question7.Answers.Add(new Answer { Text = "hej", CheckedOrRanked = 1 });
            question8.Answers.Add(new Answer { Text = "hejsan", CheckedOrRanked = 1 });
            question15.Answers.Add(new Answer { Text = "hej", CheckedOrRanked = 1 });
            question16.Answers.Add(new Answer { Text = "hej", CheckedOrRanked = 1 });
            question23.Answers.Add(new Answer { Text = "hej", CheckedOrRanked = 1 });
            question24.Answers.Add(new Answer { Text = "hej", CheckedOrRanked = 1 });
           
            //Add questions to Test Definitions

            test1.Questions.Add(question1);
            test1.Questions.Add(question3);
            test1.Questions.Add(question7);

            test2.Questions.Add(question2);
            test2.Questions.Add(question4);
            test2.Questions.Add(question8);

            test3.Questions.Add(question9);
            test3.Questions.Add(question11);
            test3.Questions.Add(question15);

            test4.Questions.Add(question10);
            test4.Questions.Add(question12);
            test4.Questions.Add(question16);

            test5.Questions.Add(question17);
            test5.Questions.Add(question19);
            test5.Questions.Add(question23);

            test6.Questions.Add(question18);
            test6.Questions.Add(question20);
            test6.Questions.Add(question24);
            
            //Add Answers to Questions


            //Add Tests to Users
            teacher1.TestDefinitions.Add(test1);
            teacher1.TestDefinitions.Add(test2);
            teacher3.TestDefinitions.Add(test6);
            teacher2.TestDefinitions.Add(test3);
            teacher2.TestDefinitions.Add(test4);
            teacher3.TestDefinitions.Add(test5);

            stud1.TestForms.Add(testForms1);
            stud2.TestForms.Add(testForms2);
            stud1.TestForms.Add(testForms3);
            stud2.TestForms.Add(testForms4);
            stud1.TestForms.Add(testForms5);
            stud2.TestForms.Add(testForms6);
            stud1.TestForms.Add(testForms7);
            stud2.TestForms.Add(testForms8);
            stud1.TestForms.Add(testForms9);
            stud2.TestForms.Add(testForms10);
            stud3.TestForms.Add(testForms11);
            stud3.TestForms.Add(testForms12);

            var list = new List<TestDefinition> { test1, test2, test3, test4, test5, test6 };
            int local = 0;

            foreach (var test in list)
            {

            foreach (var question in test.Questions)
            {
                local += question.Score;
            }
                test.MaxScore = local;
                local = 0;
            }

            //Add to Database
            using (var db = new TestverktygContext())
            {



                //Add TestDefinitions
                db.TestDefinitions.Add(test1);
                db.TestDefinitions.Add(test2);
                db.TestDefinitions.Add(test3);
                db.TestDefinitions.Add(test4);
                db.TestDefinitions.Add(test5);
                db.TestDefinitions.Add(test6);


                //Add TestForms
                db.TestForms.Add(testForms1);
                db.TestForms.Add(testForms2);
                db.TestForms.Add(testForms3);
                db.TestForms.Add(testForms4);
                db.TestForms.Add(testForms5);
                db.TestForms.Add(testForms6);
                db.TestForms.Add(testForms7);
                db.TestForms.Add(testForms8);
                db.TestForms.Add(testForms9);
                db.TestForms.Add(testForms10);
                db.TestForms.Add(testForms11);
                db.TestForms.Add(testForms12);
                
                //Add Users
                db.StudentAccounts.Add(stud1);
                db.StudentAccounts.Add(stud2);
                db.StudentAccounts.Add(stud3);
                db.TeacherAccounts.Add(teacher1);
                db.TeacherAccounts.Add(teacher2);
                db.TeacherAccounts.Add(teacher3);
                db.AdminAccounts.Add(admin1);
                db.AdminAccounts.Add(admin2);
                db.AdminAccounts.Add(admin3);
                db.SaveChanges();
            }
        }

        public static void Reset()
        {
            DeleteAndRecreate();
            Seed();
        }
    }
}
