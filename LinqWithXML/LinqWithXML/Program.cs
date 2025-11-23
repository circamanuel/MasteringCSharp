using System.Xml.Linq;

namespace LinqWithXML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string studentsXML =
                @"<Students>
                    <Student>
                        <Name>Simone</Name>
                        <Surname>Starace</Surname>
                        <Age>25</Age>
                        <Gender>M</Gender>
                        <University>Parthenope</University>
                  </Student>
                    <Student>
                        <Name>Cristina</Name>
                        <Surname>Biosef</Surname>
                        <Age>44</Age>
                        <Gender>F</Gender>
                        <University>Cambridge</University>
                  </Student>
                    <Student>
                        <Name>Mario</Name>
                        <Surname>Red</Surname>
                        <Age>30</Age>
                        <Gender>M</Gender>
                        <University>Parthenope</University>
                  </Student>
                    <Student>
                        <Name>Marcel</Name>
                        <Surname>cel</Surname>
                        <Age>20</Age>
                        <Gender>M</Gender>
                        <University>Genf</University>
                  </Student>
                </Students>";

            XDocument studentsXdoc = new XDocument();
            studentsXdoc = XDocument.Parse(studentsXML);

            var students = from student in studentsXdoc.Descendants("Student")
                           select new
                           {
                               Name = student.Element("Name").Value,
                               Surname = student.Element("Surname").Value,
                               Age = student.Element("Age").Value,
                               Gender = student.Element("Gender").Value,
                               University = student.Element("University").Value,
                           };

            foreach(var student in students)
            {
               Console.WriteLine("Student: {0} ({1}), of Age {2}, {3}  goes to the {4} University!", student.Name, student.Surname,
                   student.Age, student.Gender, student.University);
            }

            var sortedStudents = from student in students
                                 orderby student.Age
                                 select student;

            foreach(var student in sortedStudents)
            {
                Console.WriteLine("Student: {0} of Age {1} goes to the {2} University!", student.Name, student.Age, student.University);
            }
        }
    }
}
