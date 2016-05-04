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
            // TODO: you know what to do... (>_>) (<_<) ... I know...

            //Create Users
            var stud1 = new StudentAccount {Name = "Student1" , Email = "Student1", Password = "a", TestForms = new List<TestForm>() };
            var stud2 = new StudentAccount { Name = "Student2", Email = "Student2", Password = "a", TestForms = new List<TestForm>() };
            var stud3 = new StudentAccount { Name = "Student3", Email = "", Password = "a", TestForms = new List<TestForm>() };
            var admin1 = new AdminAccount { Name = "Admin1", Email = "Admin1", Password = "a", };
            var admin2 = new AdminAccount { Name = "Admin2", Email = "Admin2", Password = "a", };
            var admin3 = new AdminAccount { Name = "Admin3", Email = "Admin3", Password = "a", IsNotRemoved = false };
            var teacher1 = new TeacherAccount { Name = "Teacher1", Email = "Teacher1", Password = "a", TestDefinitions = new List<TestDefinition>() };
            var teacher2 = new TeacherAccount { Name = "Teacher2", Email = "Teacher2", Password = "a", TestDefinitions = new List<TestDefinition>() };
            var teacher3 = new TeacherAccount { Name = "Teacher3", Email = "Teacher3", Password = "a", TestDefinitions = new List<TestDefinition>(), IsNotRemoved = true };

            //Create Subject
            var sub1 = new Subject("Initial");
            var sub2 = new Subject("SystemUtvecklare");

            //Create TestDefinition
            var test1 = new TestDefinition {Title = "DatabasProv", Subject = sub1, Paragraph ="1",TestDefinitionState = TestDefinitionState.Created, Questions = new List<Question>()};
            var test2 = new TestDefinition { Title = "DatabasProv", Subject = sub1, Paragraph = "1",TestDefinitionState = TestDefinitionState.Sent, Questions = new List<Question>() };

            var test3 = new TestDefinition { Title = "DatabasProv", Subject = sub1, Paragraph = "1", TestDefinitionState = TestDefinitionState.Created, Questions = new List<Question>()};
            var test4 = new TestDefinition { Title = "DatabasProv", Subject = sub1, Paragraph = "1",TestDefinitionState = TestDefinitionState.Sent, Questions = new List<Question>() };
            var test5 = new TestDefinition { Title = "DatabasProv", Subject = sub1, Paragraph = "1", TestDefinitionState = TestDefinitionState.Created, Questions = new List<Question>() };
            var test6 = new TestDefinition { Title = "DatabasProv", Subject = sub1, Paragraph = "1", TestDefinitionState = TestDefinitionState.Created, Questions = new List<Question>() };

            //Create TestForms
            var testForms1 = new TestForm(30, new DateTime(2016, 08, 01), test1);
            var testForms2 = new TestForm(30, new DateTime(2016, 08, 01), test1);
            var testForms3 = new TestForm(30, new DateTime(2016, 08, 01), test2);
            var testForms4 = new TestForm(30, new DateTime(2016, 08, 01), test2);
            var testForms5 = new TestForm(30, new DateTime(2016, 08, 01), test3);
            var testForms6 = new TestForm(30, new DateTime(2016, 08, 01), test3);
            var testForms7 = new TestForm(30, new DateTime(2016, 08, 01), test4);
            var testForms8 = new TestForm(30, new DateTime(2016, 08, 01), test4);
            var testForms9 = new TestForm(30, new DateTime(2016, 08, 01), test5);
            var testForms10 = new TestForm(30, new DateTime(2016, 08, 01), test5);
            var testForms11 = new TestForm(30, new DateTime(2016, 08, 01), test6);
            var testForms12 = new TestForm(30, new DateTime(2016, 08, 01), test6);

            //Create Questions
            var question1 = new Question(QuestionType.Single, "1", 5);
            var question2 = new Question(QuestionType.Single, "2", 4);
            var question3 = new Question(QuestionType.Multi, "3", 3);
            var question4 = new Question(QuestionType.Multi, "4", 2);
            var question5 = new Question(QuestionType.Ranked, "5", 1);
            var question6 = new Question(QuestionType.Ranked, "6", 2);
            var question7 = new Question(QuestionType.Open, "7", 3);
            var question8 = new Question(QuestionType.Open, "8", 4);

            var question9 = new Question(QuestionType.Single, "9", 5);
            var question10 = new Question(QuestionType.Single, "10", 4);
            var question11 = new Question(QuestionType.Multi, "11", 3);
            var question12 = new Question(QuestionType.Multi, "12", 2);
            var question13 = new Question(QuestionType.Ranked, "13", 1);
            var question14 = new Question(QuestionType.Ranked, "14", 2);
            var question15 = new Question(QuestionType.Open, "15", 3);
            var question16 = new Question(QuestionType.Open, "16", 4);

            var question17 = new Question(QuestionType.Single, "17", 5);
            var question18 = new Question(QuestionType.Single, "18", 4);
            var question19 = new Question(QuestionType.Multi, "19", 3);
            var question20 = new Question(QuestionType.Multi, "20", 2);
            var question21 = new Question(QuestionType.Ranked, "21", 1);
            var question22 = new Question(QuestionType.Ranked, "22", 2);
            var question23 = new Question(QuestionType.Open, "23", 3);
            var question24 = new Question(QuestionType.Open, "24", 4);

            //Create Student Question and Answers

            var question25 = new Question(QuestionType.Single, "1", 5);
            var question26 = new Question(QuestionType.Single, "2", 4);
            var question27 = new Question(QuestionType.Multi, "3", 3);
            var question28 = new Question(QuestionType.Multi, "4", 2);
            var question29 = new Question(QuestionType.Ranked, "5", 1);
            var question30 = new Question(QuestionType.Ranked, "6", 2);
            var question31 = new Question(QuestionType.Open, "7", 3);
            var question32 = new Question(QuestionType.Open, "8", 4);

            var question33 = new Question(QuestionType.Single, "9", 5);
            var question34 = new Question(QuestionType.Single, "10", 4);
            var question35 = new Question(QuestionType.Multi, "11", 3);
            var question36 = new Question(QuestionType.Multi, "12", 2);
            var question37 = new Question(QuestionType.Ranked, "13", 1);
            var question38 = new Question(QuestionType.Ranked, "14", 2);
            var question39 = new Question(QuestionType.Open, "15", 3);
            var question40 = new Question(QuestionType.Open, "16", 4);

            var question41 = new Question(QuestionType.Single, "17", 5);
            var question42 = new Question(QuestionType.Single, "18", 4);
            var question43 = new Question(QuestionType.Multi, "19", 3);
            var question44 = new Question(QuestionType.Multi, "20", 2);
            var question45 = new Question(QuestionType.Ranked, "21", 1);
            var question46 = new Question(QuestionType.Ranked, "22", 2);
            var question47 = new Question(QuestionType.Open, "23", 3);
            var question48 = new Question(QuestionType.Open, "24", 4);


            question25.Answers.Add(new Answer("1",1));
            question25.Answers.Add(new Answer("2",0));
            question25.Answers.Add(new Answer("3",0));

            question26.Answers.Add(new Answer("1", 0));
            question26.Answers.Add(new Answer("2", 1));
            question26.Answers.Add(new Answer("3", 0));

            question27.Answers.Add(new Answer("1", 1));
            question27.Answers.Add(new Answer("2", 1));
            question27.Answers.Add(new Answer("3", 0));

            question28.Answers.Add(new Answer("1", 1));
            question28.Answers.Add(new Answer("2", 0));
            question28.Answers.Add(new Answer("3", 1));

            question29.Answers.Add(new Answer("1", 1));
            question29.Answers.Add(new Answer("2", 2));
            question29.Answers.Add(new Answer("3", 3));

            question30.Answers.Add(new Answer("1", 2));
            question30.Answers.Add(new Answer("2", 1));
            question30.Answers.Add(new Answer("3", 3));

            question33.Answers.Add(new Answer("1", 0));
            question33.Answers.Add(new Answer("2", 0));
            question33.Answers.Add(new Answer("3", 1));

            question34.Answers.Add(new Answer("1", 1));
            question34.Answers.Add(new Answer("2", 0));
            question34.Answers.Add(new Answer("3", 0));

            question35.Answers.Add(new Answer("1", 1));
            question35.Answers.Add(new Answer("2", 0));
            question35.Answers.Add(new Answer("3", 1));

            question36.Answers.Add(new Answer("1", 1));
            question36.Answers.Add(new Answer("2", 1));
            question36.Answers.Add(new Answer("3", 0));

            question37.Answers.Add(new Answer("1", 1));
            question37.Answers.Add(new Answer("2", 3));
            question37.Answers.Add(new Answer("3", 2));

            question38.Answers.Add(new Answer("1", 3));
            question38.Answers.Add(new Answer("2", 2));
            question38.Answers.Add(new Answer("3", 1));

            question41.Answers.Add(new Answer("1", 0));
            question41.Answers.Add(new Answer("3", 1));
            question41.Answers.Add(new Answer("3", 0));

            question42.Answers.Add(new Answer("1", 0));
            question42.Answers.Add(new Answer("3", 0));
            question42.Answers.Add(new Answer("3", 1));

            question43.Answers.Add(new Answer("1", 1));
            question43.Answers.Add(new Answer("2", 0));
            question43.Answers.Add(new Answer("3", 1));

            question44.Answers.Add(new Answer("1", 1));
            question44.Answers.Add(new Answer("2", 1));
            question44.Answers.Add(new Answer("3", 0));

            question45.Answers.Add(new Answer("1", 1));
            question45.Answers.Add(new Answer("2", 2));
            question45.Answers.Add(new Answer("3", 3));

            question46.Answers.Add(new Answer("1", 2));
            question46.Answers.Add(new Answer("2", 3));
            question46.Answers.Add(new Answer("3", 1));

            //Add questions to Test Definitions

            test1.Questions.Add(question1);
            test1.Questions.Add(question3);
            test1.Questions.Add(question5);
            test1.Questions.Add(question7);

            test2.Questions.Add(question2);
            test2.Questions.Add(question4);
            test2.Questions.Add(question6);
            test2.Questions.Add(question8);

            test3.Questions.Add(question9);
            test3.Questions.Add(question11);
            test3.Questions.Add(question13);
            test3.Questions.Add(question15);

            test4.Questions.Add(question10);
            test4.Questions.Add(question12);
            test4.Questions.Add(question14);
            test4.Questions.Add(question16);

            test5.Questions.Add(question17);
            test5.Questions.Add(question19);
            test5.Questions.Add(question21);
            test5.Questions.Add(question23);

            test6.Questions.Add(question18);
            test6.Questions.Add(question20);
            test6.Questions.Add(question22);
            test6.Questions.Add(question24);


            //Create AnswerQuestions
            var ansque1 = new AnsweredQuestion(question25);
            var ansque2 = new AnsweredQuestion(question26);
            var ansque3 = new AnsweredQuestion(question27);
            var ansque4 = new AnsweredQuestion(question28);
            var ansque5 = new AnsweredQuestion(question29);
            var ansque6 = new AnsweredQuestion(question30);
            var ansque7 = new AnsweredQuestion(question31);
            var ansque8 = new AnsweredQuestion(question32);
            var ansque9 = new AnsweredQuestion(question33);
            var ansque10 = new AnsweredQuestion(question34);
            var ansque11 = new AnsweredQuestion(question35);
            var ansque12 = new AnsweredQuestion(question36);
            var ansque13 = new AnsweredQuestion(question37);
            var ansque14 = new AnsweredQuestion(question38);
            var ansque15 = new AnsweredQuestion(question39);
            var ansque16 = new AnsweredQuestion(question40);
            var ansque17 = new AnsweredQuestion(question41);
            var ansque18 = new AnsweredQuestion(question42);
            var ansque19 = new AnsweredQuestion(question43);
            var ansque20 = new AnsweredQuestion(question44);
            var ansque21 = new AnsweredQuestion(question45);
            var ansque22 = new AnsweredQuestion(question46);
            var ansque23 = new AnsweredQuestion(question47);
            var ansque24 = new AnsweredQuestion(question48);

            testForms1.AnsweredQuestions.Add(ansque1);
            testForms1.AnsweredQuestions.Add(ansque3);
            testForms1.AnsweredQuestions.Add(ansque5);
            testForms1.AnsweredQuestions.Add(ansque7);

            testForms2.AnsweredQuestions.Add(ansque1);
            testForms2.AnsweredQuestions.Add(ansque3);
            testForms2.AnsweredQuestions.Add(ansque5);
            testForms2.AnsweredQuestions.Add(ansque7);

            testForms3.AnsweredQuestions.Add(ansque2);
            testForms3.AnsweredQuestions.Add(ansque4);
            testForms3.AnsweredQuestions.Add(ansque6);
            testForms3.AnsweredQuestions.Add(ansque8);

            testForms4.AnsweredQuestions.Add(ansque2);
            testForms4.AnsweredQuestions.Add(ansque4);
            testForms4.AnsweredQuestions.Add(ansque6);
            testForms4.AnsweredQuestions.Add(ansque8);

            testForms5.AnsweredQuestions.Add(ansque9);
            testForms5.AnsweredQuestions.Add(ansque11);
            testForms5.AnsweredQuestions.Add(ansque13);
            testForms5.AnsweredQuestions.Add(ansque15);

            testForms6.AnsweredQuestions.Add(ansque9);
            testForms6.AnsweredQuestions.Add(ansque11);
            testForms6.AnsweredQuestions.Add(ansque13);
            testForms6.AnsweredQuestions.Add(ansque15);

            testForms7.AnsweredQuestions.Add(ansque10);
            testForms7.AnsweredQuestions.Add(ansque12);
            testForms7.AnsweredQuestions.Add(ansque14);
            testForms7.AnsweredQuestions.Add(ansque16);

            testForms8.AnsweredQuestions.Add(ansque10);
            testForms8.AnsweredQuestions.Add(ansque12);
            testForms8.AnsweredQuestions.Add(ansque14);
            testForms8.AnsweredQuestions.Add(ansque16);

            testForms9.AnsweredQuestions.Add(ansque17);
            testForms9.AnsweredQuestions.Add(ansque19);
            testForms9.AnsweredQuestions.Add(ansque21);
            testForms9.AnsweredQuestions.Add(ansque23);

            testForms10.AnsweredQuestions.Add(ansque17);
            testForms10.AnsweredQuestions.Add(ansque19);
            testForms10.AnsweredQuestions.Add(ansque21);
            testForms10.AnsweredQuestions.Add(ansque23);

            testForms11.AnsweredQuestions.Add(ansque18);
            testForms11.AnsweredQuestions.Add(ansque20);
            testForms11.AnsweredQuestions.Add(ansque22);
            testForms11.AnsweredQuestions.Add(ansque24);

            testForms12.AnsweredQuestions.Add(ansque18);
            testForms12.AnsweredQuestions.Add(ansque20);
            testForms12.AnsweredQuestions.Add(ansque22);
            testForms12.AnsweredQuestions.Add(ansque24);


            //Add Answers to Questions

            //Single
            question1.Answers.Add(new Answer("1",1));
            question1.Answers.Add(new Answer("1",0));
            question1.Answers.Add(new Answer("1",0));

            question2.Answers.Add(new Answer("1", 0));
            question2.Answers.Add(new Answer("1", 1));
            question2.Answers.Add(new Answer("1", 0));

            question9.Answers.Add(new Answer("1", 0));
            question9.Answers.Add(new Answer("1", 0));
            question9.Answers.Add(new Answer("1", 1));

            question10.Answers.Add(new Answer("1", 1));
            question10.Answers.Add(new Answer("1", 0));
            question10.Answers.Add(new Answer("1", 0));

            question17.Answers.Add(new Answer("1", 0));
            question17.Answers.Add(new Answer("1", 1));
            question17.Answers.Add(new Answer("1", 0));

            question18.Answers.Add(new Answer("1", 0));
            question18.Answers.Add(new Answer("1", 0));
            question18.Answers.Add(new Answer("1", 1));

            //Multi
            question3.Answers.Add(new Answer("1",1));
            question3.Answers.Add(new Answer("2",0));
            question3.Answers.Add(new Answer("3",1));


            question4.Answers.Add(new Answer("1", 1));
            question4.Answers.Add(new Answer("1", 0));
            question4.Answers.Add(new Answer("1", 1));

            question11.Answers.Add(new Answer("1", 1));
            question11.Answers.Add(new Answer("1", 0));
            question11.Answers.Add(new Answer("1", 1));

            question12.Answers.Add(new Answer("1", 1));
            question12.Answers.Add(new Answer("1", 0));
            question12.Answers.Add(new Answer("1", 1));

            question19.Answers.Add(new Answer("1", 1));
            question19.Answers.Add(new Answer("1", 0));
            question19.Answers.Add(new Answer("1", 1));

            question20.Answers.Add(new Answer("1", 1));
            question20.Answers.Add(new Answer("1", 0));
            question20.Answers.Add(new Answer("1", 1));

            //Ranked
            question5.Answers.Add(new Answer("3",1));
            question5.Answers.Add(new Answer("2",2));
            question5.Answers.Add(new Answer("1",3));

            question6.Answers.Add(new Answer("3", 1));
            question6.Answers.Add(new Answer("2", 2));
            question6.Answers.Add(new Answer("1", 3));

            question13.Answers.Add(new Answer("3", 1));
            question13.Answers.Add(new Answer("2", 2));
            question13.Answers.Add(new Answer("1", 3));

            question14.Answers.Add(new Answer("3", 1));
            question14.Answers.Add(new Answer("2", 2));
            question14.Answers.Add(new Answer("1", 3));

            question21.Answers.Add(new Answer("3", 1));
            question21.Answers.Add(new Answer("2", 2));
            question21.Answers.Add(new Answer("1", 3));

            question22.Answers.Add(new Answer("3", 1));
            question22.Answers.Add(new Answer("2", 2));
            question22.Answers.Add(new Answer("1", 3));

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
                db.TeacherAccounts.Add(teacher1);
                db.TeacherAccounts.Add(teacher2);
                db.TeacherAccounts.Add(teacher3);
                db.AdminAccounts.Add(admin1);
                db.AdminAccounts.Add(admin2);

                //Add AnswerQuestions


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
