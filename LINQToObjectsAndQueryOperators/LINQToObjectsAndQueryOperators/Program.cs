using System.ComponentModel;

namespace LINQToObjectsAndQueryOperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UniversityManager um = new UniversityManager();
            um.MaleStudents();
            um.FemaleStudents();
            um.SortedStudentsByAge();
            um.AllStudentFromBeijingTech();
            um.StudentAndUniversityNameCollection();

            int[] someInts = { 40, 24, 4, 1 };
            IEnumerable<int> sortedInts = from i in someInts orderby i select i;
            IEnumerable<int> reversedInts =  sortedInts.Reverse();

            foreach(int i in reversedInts)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Select Uni: 1. Yale, 2. Beijing tech");
            string input = Console.ReadLine();

            try
            {
                int inputAsInt = Convert.ToInt32(input);
                um.selcetedUniStudents(inputAsInt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());   
            }
        }
    }

    class UniversityManager
    {
        public List<University> universities;
        public List<Student> students;

        public UniversityManager()
        {
            // Initialize the lists
            universities = new List<University>();
            students = new List<Student>();

            // Add some Universities
            universities.Add(new University { Id = 1, Name = "Yale" });
            universities.Add(new University { Id = 2, Name = "Beijing Tech" });

            // Add Students
            students.Add(new Student { Id = 1, Gender = "Male", Age = 22, Name = "Kevin", UniversityId = 2 });
            students.Add(new Student { Id = 2, Gender = "Female", Age = 32, Name = "Celin", UniversityId = 2 });
            students.Add(new Student { Id = 3, Gender = "Male", Age = 18, Name = "Jan", UniversityId = 2 });
            students.Add(new Student { Id = 4, Gender = "Female", Age = 43, Name = "Lena", UniversityId = 1 });
            students.Add(new Student { Id = 5, Gender = "Male", Age = 24, Name = "Ruben", UniversityId = 1 });
        }

        public void MaleStudents()
        {
            IEnumerable<Student> maleStudents = from student in students where student.Gender == "Male" select student;

            foreach (Student student in maleStudents)
            {
                student.Print();
            }
        }


        public void FemaleStudents()
        {
            IEnumerable<Student> femaleStudent = from student in students where student.Gender == "Female" select student;    

            foreach(Student female in femaleStudent)
            {
                female.Print();
            }
        }

        public void SortedStudentsByAge()
        {
            var sortedStudents = from student in students orderby student.Age select student;

            Console.WriteLine("Students sorted by Age");

            foreach (Student student in sortedStudents)
            {
                student.Print(); 
            }
        }

        public void AllStudentFromBeijingTech()
        {
            IEnumerable<Student> bjtStudents = from Student student in students
                                               join uni in universities on student.UniversityId equals uni.Id
                                               where uni.Name == "Beijing Tech"
                                               select student;

            Console.WriteLine("Student from Beijing Tech");
            foreach (Student student in bjtStudents)
            {
                student.Print(); 
            }
        }

        public void selcetedUniStudents(int uniId)
        {
            IEnumerable<Student> selectedStudents = from Student student in students
                                                    join uni in universities on student.UniversityId equals uni.Id
                                                    where uni.Id == uniId
                                                    select student;

            Console.WriteLine($"Students whit uni id {uniId}");

           foreach(Student studdent in selectedStudents)
            {
                studdent.Print(); 
            }
        }
    public void StudentAndUniversityNameCollection()
        {
            var newCollection = from student in students
                                join university in universities on student.UniversityId equals university.Id
                                orderby student.Name
                                select new { StudentName = student.Name, UniversityName = university.Name };

            Console.WriteLine("New Collection: ");

            foreach(var col in newCollection)
            {
                Console.WriteLine("Student {0} from University {1}", col.StudentName, col.UniversityName);
            }
        }
    }

    class University
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Print()
        {
            Console.WriteLine("Univerity {0} with id {1}", Name, Id);
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        // Foreign Key
        public int UniversityId { get; set; }

        public void Print()
        {
            Console.WriteLine("Student {0} with Id {1}, Gender {2} " +
                "and Age {3} from University with the Id {4}", Name, Id, Gender, Age, UniversityId);
        }
    }

}
