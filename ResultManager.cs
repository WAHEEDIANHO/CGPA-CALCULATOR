using System;
using System.Collections.Generic;

//===============================
//206454
//safiu waheed
//Computer Science
//===============================

namespace ResultManagementSystem
{
    class ResultManager
    {
        //member variable
        static private string name, address;
        static private int age, no_of_course;
        static List<string[]> courses = new List<string[]>();
        

        //Getting Student Detail
        static public void AcceptDetail()
        {
            Console.WriteLine("Please Enter ur name to get Started");
            name = Console.ReadLine();

            Console.WriteLine("How old are you");
            bool is_num_age = int.TryParse(Console.ReadLine(), out age);

            Console.WriteLine("Where did you stay");
            address = Console.ReadLine();
        }

        //Course Registration
        static public void CourseRegistration()
        {
            //getting the number of courses
            Console.WriteLine("How many courses did u register: ");
            no_of_course = int.Parse(Console.ReadLine());

            
            for (int i = 1; i <= no_of_course; i++)
            {
                //Creating an array for course, unit and score
                //[course_code, unit, score, letter_grade, point, Grade point]
                string[] courses_unit = new string[6];

                //asking user for his/her courses
                Console.WriteLine("Enter your {0} of {1} course(s)", i, no_of_course);
                courses_unit[0] = Console.ReadLine();

                //asking user for his or her course unit 
                Console.WriteLine("How many unit is {0}", courses_unit[0]);
                courses_unit[1] = Console.ReadLine();

                //Registration complete
                courses.Add(courses_unit);
            }
        }

        //score classifier and GPA calculation

        static public int GPACalculator(int unit, int point)
        {
            return unit * point;
        }
        static public void ScoreClassifier()
        {
            //classifying user score
            foreach (var item in courses)
            {
                string cur_course = item[0];

                //asking user for their score
                Console.WriteLine("What did you score in {0}", cur_course);
                int score = int.Parse(Console.ReadLine());

                //Classifiier
                void Classifier(int score, string lett_grade, string point)
                {
                    item[2] = score.ToString();
                    item[3] = lett_grade;
                    item[4] = point;
                    item[5] = GPACalculator(int.Parse(item[1]), int.Parse(item[4]))
                              .ToString();
                }

                switch (score)
                {
                    case var _ when (score < 45):
                        Classifier(score, "E", "0");
                        break;
                    case var _ when (score >= 45 && score < 50):
                        Classifier(score, "D", "1");
                        break;
                    case var _ when (score >= 50 && score < 60):
                        Classifier(score, "C", "2");
                        break;
                    case var _ when (score >= 60 && score < 70):
                        Classifier(score, "B", "3");
                        break;
                    case var _ when (score >= 70 && score <= 100):
                        Classifier(score, "A", "4");
                        break;
                    default:
                        Classifier(0, "", "");
                        break;
                }
            }
        }
        
        static public double[] CummGradePoint()
        {
           double total_weighted_point = 0, total_no_of_unit = 0;
            double cgpa;
            foreach (var course in courses)
            {
                total_no_of_unit += int.Parse(course[1]);
                total_weighted_point += int.Parse(course[5]);
            }
            cgpa = total_weighted_point / total_no_of_unit;
            double[] result_detail = {total_no_of_unit, total_weighted_point, cgpa};
            return result_detail;
        }
        static public string DegreeClass(double cgpa)
        {
            string class_of_degree = cgpa < 1.0 ? "Fail" :
                cgpa >= 1.00 && cgpa < 2.00 ? "Third Class" :
                cgpa >= 2.00 && cgpa < 3.00 ? "Second Class Lower" :
                cgpa >= 3.00 && cgpa < 3.5 ? "Second Class Upper" :
                cgpa >= 3.00 && cgpa <= 4.00 ? "First Class" : "No registration";
            return class_of_degree;
        }

        static void Main(string[] args)
        {
            AcceptDetail();
            CourseRegistration();
            ScoreClassifier();
            Console.WriteLine("Name: \t {0} \n Age: \t {1} \n Address: \t {2}", name, age, address);

            foreach (var item in courses)
            {
                foreach (var el in item)
                {
                    Console.Write(el + "\t" + "|" + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Total Unit Register: \t" + CummGradePoint()[0]);
            Console.WriteLine("Total weighted point: \t" + CummGradePoint()[1]);
            Console.WriteLine("Cummulative Grade Point Average: \t" + CummGradePoint()[2]);
            Console.WriteLine("Class of Degree: \t" + DegreeClass(CummGradePoint()[2]));

        }
    }
}
