namespace Task6
{
    class Student
    {
        public Student(int studentId, string name, int age)
        {
            StudentId = studentId;
            Name = name;
            Age = age;
            Courses = new List<Course>();
        }

        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course> Courses { get; set; }

        public bool Enroll(Course course)
        {
            if (Courses.Contains(course))
            {
                return false; // Already enrolled
            }
            Courses.Add(course);
            return true;
        }
        public string PrintDetails()
        {
            string courselist = "";
            if (Courses.Count > 0)
            {
                for (int i = 0; i < Courses.Count; i++)
                {
                    courselist += Courses[i].Title;
                    if (i < Courses.Count - 1)
                    {
                        courselist += ", ";
                    }
                }
            }
            else
            {
                courselist = "No courses enrolled";
            }

            return $"Student ID: {StudentId}, Name: {Name}, Age: {Age}, Courses: [{courselist}]";
        }

    }
    class Course
    {
        public Course(int courseId, string title, Instructor instructor)
        {
            CourseId = courseId;
            Title = title;
            Instructor = instructor;
        }

        public int CourseId { get; set; }
        public string Title { get; set; }
        public Instructor Instructor { get; set; }

        public string PrintDetails()
        {
            return $"Course ID: {CourseId}, Title: {Title}, Instructor: {Instructor.Name}";
        }
    }
    class Instructor
    {
        public Instructor(int instructorId, string name, string specialization)
        {
            InstructorId = instructorId;
            Name = name;
            Specialization = specialization;
        }

        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }

        public string PrintDetails()
        {
            return $"Instructor ID: {InstructorId}, Name: {Name}, Specialization: {Specialization}";
        }

    }
    class SchoolStudentManager
    {
        public SchoolStudentManager()
        {
            students = new List<Student>();
            Courses = new List<Course>();
            Instructors = new List<Instructor>();
        }


        public List<Student> students { get; set; }
        public List<Course> Courses { get; set; }
        public List<Instructor> Instructors { get; set; }

        public bool AddStudent(Student student)
        {
            students.Add(student);
            return true;

        }
        public bool AddCourse(Course course)
        {
            Courses.Add(course);
            return true;
        }
        public bool AddInstructor(Instructor instructor)
        {
            Instructors.Add(instructor);
            return true;
        }
        public Student FindStudent(int Id)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].StudentId == Id)
                {
                    return students[i];
                }
            }
            return null;

        }
        public Course FindCourse(int Id)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == Id)
                {
                    return Courses[i];
                }
            }
            return null;
        }
        public Instructor FindInstructor(int Id)
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InstructorId == Id)
                {
                    return Instructors[i];
                }
            }
            return null;
        }
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);
            if (student != null && course != null)
            {
                student.Enroll(course);
                return true;
            }
            return false;
        }
        public bool IsEnrollStudentInCourse(int studentId, int courseId) //Bonus
        {
            Student student = FindStudent(studentId);
            if (student != null)
            {
                for (int i = 0; i < student.Courses.Count; i++)
                {
                    if (student.Courses[i].CourseId == courseId)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public string GetInstructorNameByCourseTitle(string title) //Bonus
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    return Courses[i].Instructor.Name;
                }
            }
            return "Course not found!";
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SchoolStudentManager manager = new SchoolStudentManager();
            int choice;
            do
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Instructor");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Show All Students");
                Console.WriteLine("6. Show All Courses");
                Console.WriteLine("7. Show All Instructors");
                Console.WriteLine("8. Find the student by id or name");
                Console.WriteLine("9. Fine the course by id or name");
                Console.WriteLine("10. Exit");

                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {

                    case 1:
                        Console.Write("Enter Student ID: ");
                        int sid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string sname = Console.ReadLine();
                        Console.Write("Enter Age: ");
                        int sage = Convert.ToInt32(Console.ReadLine());
                        manager.AddStudent(new Student(sid, sname, sage));
                        Console.WriteLine("Student added!");
                        break;
                    case 2:
                        Console.Write("Enter Instructor ID: ");
                        int iid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string iname = Console.ReadLine();
                        Console.Write("Enter Specialization: ");
                        string spec = Console.ReadLine();
                        manager.AddInstructor(new Instructor(iid, iname, spec));
                        Console.WriteLine("Instructor added!");
                        break;

                    case 3:
                        Console.Write("Enter Course ID: ");
                        int cid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Title: ");
                        string ctitle = Console.ReadLine();
                        Console.Write("Enter Instructor ID: ");
                        int insId = Convert.ToInt32(Console.ReadLine());
                        var inst = manager.FindInstructor(insId);
                        if (inst != null)
                        {
                            manager.AddCourse(new Course(cid, ctitle, inst));
                            Console.WriteLine("Course added!");
                        }
                        else
                        {
                            Console.WriteLine("Instructor not found!");
                        }
                        break;


                    case 4:
                        Console.Write("Enter Student ID: ");
                        int esid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Course ID: ");
                        int ecid = Convert.ToInt32(Console.ReadLine());
                        if (manager.EnrollStudentInCourse(esid, ecid))
                            Console.WriteLine("Enrolled successfully!");
                        else
                            Console.WriteLine("Enrollment failed!");
                        break;

                    case 5:
                        for (int i = 0; i < manager.students.Count; i++)
                            Console.WriteLine(manager.students[i].PrintDetails());
                        break;

                    case 6:
                        for (int i = 0; i < manager.Courses.Count; i++)
                            Console.WriteLine(manager.Courses[i].PrintDetails());
                        break;


                    case 7:
                        for (int i = 0; i < manager.Instructors.Count; i++)
                            Console.WriteLine(manager.Instructors[i].PrintDetails());
                        break;
                    case 8:
                        Console.Write("Enter Student ID: ");
                        int fsid = Convert.ToInt32(Console.ReadLine());
                        var student = manager.FindStudent(fsid);
                        if (student != null)
                        {
                            Console.WriteLine(student.PrintDetails());
                        }
                        else
                        {
                            Console.WriteLine("Student not found!");
                        }


                        break;
                    case 9:
                        Console.Write("Enter Course ID: ");
                        int fcid = Convert.ToInt32(Console.ReadLine());
                        var course = manager.FindCourse(fcid);
                        if (course != null)
                        {
                            Console.WriteLine(course.PrintDetails());
                        }
                        else
                        {
                            Console.WriteLine("Course not found!");
                        }
                        break;

                    case 11:     // BONUS

                        Console.Write("Enter Student ID: ");
                        int stId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Course ID: ");
                        int coId = Convert.ToInt32(Console.ReadLine());
                        bool enrolled = manager.IsEnrollStudentInCourse(stId, coId);
                        if (enrolled)
                        {
                            Console.WriteLine("Yes, student is enrolled.");
                        }
                        else
                        {
                            Console.WriteLine("No, student is not enrolled.");
                        }
                        break;
                    case 12: // BONUS
                        Console.Write("Enter Course Title: ");
                        string title = Console.ReadLine();
                        string instrName = manager.GetInstructorNameByCourseTitle(title);
                        Console.WriteLine(instrName);
                        break;


                }

            } while (choice != 10);


        }
    }


}