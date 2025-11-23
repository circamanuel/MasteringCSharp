using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using LinqToSQL.TurtorialDBDataSetTableAdapters;

namespace LinqToSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LinqToSqlDataClassesDataContext dataContext;
        public MainWindow()
        {
            InitializeComponent();

            string conectionString = ConfigurationManager.ConnectionStrings["LinqToSQL.Properties.Settings.TurtorialDBConnectionString"].ConnectionString;
            dataContext = new LinqToSqlDataClassesDataContext (conectionString);

            //InsertUniversities();
            //InsertStudent();
            //InsertLecture();
            //StudentLectureAssociation();
            //GetUniversityOfToni();
            //GetLectureOfTony();
            GetAllStudentsFromYale();
        }

        public void InsertUniversities()
        {
            dataContext.ExecuteCommand("delete from University");
            University yale = new University();
            yale.Name = "Yale";
            dataContext.Universities.InsertOnSubmit(yale);

            University geneve = new University();
            geneve.Name = "Geneve";
            dataContext.Universities.InsertOnSubmit (geneve);

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Universities;    

        }

        public void InsertStudent()
        {
            University yale = dataContext.Universities.First(un => un.Name.Equals("Yale"));
            University geneve = dataContext.Universities.First(un => un.Name.Equals("Geneve"));

            List<Student> students = new List<Student>();

            students.Add(new Student { Name = "Carl", Gender = "female", UniversityId = yale.Id });
            students.Add(new Student { Name = "Toni", Gender = "male", University = yale });
            students.Add(new Student { Name = "Leyla", Gender = "female", UniversityId = geneve.Id });
            students.Add(new Student { Name = "Jame", Gender = "female", University = geneve });

            dataContext.Students.InsertAllOnSubmit(students);

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Students;
        }

        public void InsertLecture()
        {
            List<Lecture> lectures = new List<Lecture>();

            lectures.Add(new Lecture { Name = "Math" });
            lectures.Add(new Lecture { Name = "Biology" });
            lectures.Add(new Lecture { Name = "Geography" });
            lectures.Add(new Lecture { Name = "Science" });

            dataContext.Lectures.InsertAllOnSubmit(lectures);
            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Lectures;
        }

        public void StudentLectureAssociation()
        {
            dataContext.ExecuteCommand("delete from StudentLecture");

            // getting indivudal lecture identification
            Lecture math = dataContext.Lectures.First( le => le.Name.Equals("Math"));
            Lecture bio = dataContext.Lectures.First( le => le.Name.Equals("Biology"));
            Lecture geo = dataContext.Lectures.First( le => le.Name.Equals("Geography"));
            Lecture sci = dataContext.Lectures.First( le => le.Name.Equals("Science"));

            // getting student identification 
            Student carl = dataContext.Students.First(stu => stu.Name.Equals("Carl"));
            Student toni = dataContext.Students.First(stu => stu.Name.Equals("Toni"));
            Student leyla = dataContext.Students.First(stu => stu.Name.Equals("Leyla"));
            Student jame = dataContext.Students.First(stu => stu.Name.Equals("Jame"));

            List<StudentLecture> studentLectures = new List<StudentLecture>();

            studentLectures.Add(new StudentLecture { StudentId = carl.Id, LectureId = math.Id });
            studentLectures.Add(new StudentLecture { StudentId = leyla.Id, LectureId = geo.Id });
            studentLectures.Add(new StudentLecture { StudentId = toni.Id, LectureId = sci.Id });
            studentLectures.Add(new StudentLecture { StudentId = jame.Id, LectureId = bio.Id });

            dataContext.StudentLectures.InsertAllOnSubmit(studentLectures);
            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.StudentLectures;
        }

        public void GetUniversityOfToni()
        {
            Student Toni = dataContext.Students.First(st => st.Name.Equals("Toni"));

            University TonisUniversity = Toni.University;

            List<University> universities = new List<University>();
            
            universities.Add(TonisUniversity);

            MainDataGrid.ItemsSource = universities;
        }

        public void GetLectureOfTony()
        {
            Student Toni = dataContext.Students.First(st => st.Name.Equals("Toni"));

            var tonisLectures = from sl in Toni.StudentLectures select sl.Lecture;

            MainDataGrid.ItemsSource = tonisLectures;
        }

        public void GetAllStudentsFromYale()
        {
            var yaleStudents = from student in dataContext.Students
                               where student.University.Name == "Yale"
                               select student;
            
            MainDataGrid.ItemsSource = yaleStudents;
        }
    }
}
