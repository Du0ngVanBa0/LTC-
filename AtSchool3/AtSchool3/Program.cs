using System;
using System.Collections.Generic;
using System.Linq;

namespace AtSchool3
{
    class Department
    {
        public string code { get; set; }
        public string name { get; set; }

        public Department(string code, string name)
        {
            this.code = code;
            this.name = name;
        }
    }
    class Student
    {
        public string code { get; set; }
        public string name { get; set; }
        public double avgPoint { get; set; }
        public Department department { get; set; }

        public Student(string code, string name, double avgPoint, Department department)
        {
            this.code = code;
            this.name = name;
            this.avgPoint = avgPoint;
            this.department = department;
        }
        public override string ToString()
        {
            return $"Code: {code}, name: {name}, avg Point: {avgPoint}";
        }
        public string getFUllInfo()
        {
            return $"Code: {code}, name: {name}, avg Point: {avgPoint}, Department: code({department.code}), name({department.name})";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Department> departmentList = new List<Department> { 
                new Department("d001","Cong Nghe So"),
                new Department("d002","Dien - dien tu"),
                new Department("d003","Xay Dung"),
                new Department("d004","Co Khi"),
                new Department("d005","CN Hoa Hoc")
            };
            List<Student> studentList = new List<Student> {
                new Student("s001","Duong Van Bao", 9.5,departmentList[0]),
                new Student("s002", "Duong Van Hao", 8.5,departmentList[2]),
                new Student("s003", "Duong Van Hong", 5.5,departmentList[0]),
                new Student("s004", "Duong Van Khoan", 6.5,departmentList[1]),
                new Student("s005", "Duong Van Khoa", 9.2,departmentList[3]),
                new Student("s006", "Duong Van Hao", 9.1,departmentList[3]),
                new Student("s007", "Duong Van Hang", 8.5,departmentList[3]),
                new Student("s008", "Duong Van Trung", 7.3,departmentList[4])
            };
            var groupedStudents = studentList.GroupBy(student => student.department);

            foreach (var group in groupedStudents)
            {
                Console.WriteLine($"\n---Department: {group.Key.name}");
                foreach (var student in group.OrderBy(s => s.name))
                {
                    Console.WriteLine($"-{student.code} - {student.name}");
                }
            }

        var pointRqStudent = studentList.Where(st => st.avgPoint > 7 || st.avgPoint < 4);
            Console.WriteLine("\n---List Student have avg point > 7 or < 4:");
            if (pointRqStudent.ToList().Count == 0) 
                Console.WriteLine("No one have avg point > 7 or < 4");
            foreach(var st in pointRqStudent)
            {
                Console.WriteLine(st);
            }

            var nameChkStudent = studentList.Where(st => st.name.Contains("Khoa"));
            bool haveKhoaStudent = nameChkStudent.ToList().Count >= 1;
            Console.WriteLine( haveKhoaStudent ?"\n---List have student with name contain 'Khoa'!" : "---List dont have any student with name contain 'Khoa'!");
            foreach (var st in nameChkStudent) { Console.WriteLine(st); };

            Console.WriteLine("\n---List Student have Department:");
            foreach (var st in studentList)
            {
                Console.WriteLine(st.getFUllInfo());
            }

            var descStudent = (from st in studentList orderby st.avgPoint descending select st).First();
            Console.WriteLine("\n---Best Student:");
            Console.WriteLine(descStudent);
        }
    }
}
