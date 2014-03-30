using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace SoftwareAcademy
{
    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            return new Teacher(name);
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            return new LocalCourse(name, teacher, lab);
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            return new OffsiteCourse(name, teacher, town);
        }
    }

    public class Teacher : ITeacher
    {

        public string Name { get; set; }
        private List<ICourse> courses = new List<ICourse>();



        public Teacher(string name)
        {
            this.Name = name;
        }

        public List<ICourse> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        public void AddCourse(ICourse course)
        {
            this.Courses.Add(course);
        }

        public override string ToString()
        {
            string result = string.Empty;

            if (this.Courses.Count == 0)
            {
                result = string.Format("Teacher: Name={0}", this.Name);
            }
            else
            {
                result = string.Format("Teacher: Name={0}; Courses=[", this.Name);

                foreach (var course in this.Courses)
                {
                    result += string.Format("{0}, ", course.Name);
                }

                result = result.Remove(result.Length - 2, 2);

                result += "]";
            }

            return result;
        }
    }

    public class LocalCourse : ILocalCourse
    {
        private List<string> topics = new List<string>();

        public string Lab { get; set; }

        public string Name { get; set; }

        public ITeacher Teacher { get; set; }

        // Prop
        public List<string> Topics
        {
            get { return this.topics; }
            set { this.topics = value; }
        }

        // Constructor
        public LocalCourse(string name, ITeacher teacher, string lab)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.Lab = lab;
        }

        public void AddTopic(string topic)
        {
            this.Topics.Add(topic);
        }

        public override string ToString()
        {
            string result = string.Empty;

            result += this.GetType().Name + ": ";
            result += string.Format("Name={0}; ", this.Name);

            if (this.Teacher != null)
            {
                result += string.Format("Teacher={0}; ", this.Teacher.Name);
            }

            if (this.Topics.Count > 0)
            {
                result += "Topics=[";

                foreach (var topic in this.Topics)
                {
                    result += string.Format("{0}, ", topic);
                }

                result = result.Remove(result.Length - 2, 2);

                result += "]; ";
            }

            result += string.Format("Lab={0}", this.Lab);

            return result;
        }
    }

    public class OffsiteCourse : IOffsiteCourse
    {
        private List<string> topics = new List<string>();

        public string Town { get; set; }

        public string Name { get; set; }

        public ITeacher Teacher { get; set; }

        // Prop
        public List<string> Topics
        {
            get { return this.topics; }
            set { this.topics = value; }
        }

        // Constructor
        public OffsiteCourse(string name, ITeacher teacher, string town)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.Town = town;
        }


        public void AddTopic(string topic)
        {
            this.Topics.Add(topic);
        }

        public override string ToString()
        {
            string result = string.Empty;

            result += this.GetType().Name + ": ";
            result += string.Format("Name={0}; ", this.Name);

            if (this.Teacher != null)
            {
                result += string.Format("Teacher={0}; ", this.Teacher.Name);
            }

            if (this.Topics.Count > 0)
            {
                result += "Topics=[";

                foreach (var topic in this.Topics)
                {
                    result += string.Format("{0}, ", topic);
                }

                result = result.Remove(result.Length - 2, 2);

                result += "]; ";
            }

            result += string.Format("Town={0}", this.Town);

            return result;
        }
    }

    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using SoftwareAcademy;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
