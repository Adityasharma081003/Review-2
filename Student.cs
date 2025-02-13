using System;
using System.Collections.Generic;

class Student {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }

    public Student(int id, string name, int age, int marks) {
        Id = id;
        Name = name;
        Age = age;
        Marks = marks;
    }

    public override string ToString() {
        return "ID: "+Id+"\nName: " +Name+"\nAge: "+Age+"\nMarks: " +Marks;
    }
}

interface IStudentOperations {
    void AddStudent(Student student);
    void UpdateStudent(int id, string name, int age, int marks);
    void DeleteStudent(int id);
    void DisplayStudents();
}

class StudentManager : IStudentOperations {
    private List<Student> students = new List<Student>();

    public void AddStudent(Student student) {
        students.Add(student);
        Console.WriteLine("Student added successfully.");
    }

    public void UpdateStudent(int id, string name, int age, int marks) {
        Student student = students.Find(s => s.Id == id);
        if (student != null) {
            student.Name = name;
            student.Age = age;
            student.Marks = marks;
            Console.WriteLine("Student updated successfully.");
        } else {
            Console.WriteLine("Student not found.");
        }
    }

    public void DeleteStudent(int id) {
        Student student = students.Find(s => s.Id == id);
        if (student != null) {
            students.Remove(student);
            Console.WriteLine("Student deleted successfully.");
        } else {
            Console.WriteLine("Student not found.");
        }
    }

    public void DisplayStudents() {
        if (students.Count == 0) {
            Console.WriteLine("No students to display.");
        } else {
            foreach (Student student in students) {
                Console.WriteLine(student);
            }
        }
    }
}

class Program {
    static void Main(string[] args) {
        StudentManager manager = new StudentManager();
        while (true) {
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Update Student");
            Console.WriteLine("3. Delete Student");
            Console.WriteLine("4. Display Students");
            Console.WriteLine("5. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice) {
                case 1:
                    Console.WriteLine("Enter ID, Name, Age, Marks: ");
                    int id = int.Parse(Console.ReadLine());
                    string name = Console.ReadLine();
                    int age = int.Parse(Console.ReadLine());
                    int marks = int.Parse(Console.ReadLine());
                    manager.AddStudent(new Student(id, name, age, marks));
                    break;
                case 2:
                    Console.WriteLine("Enter ID to update: ");
                    id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new Name, Age, Marks: ");
                    name = Console.ReadLine();
                    age = int.Parse(Console.ReadLine());
                    marks = int.Parse(Console.ReadLine());
                    manager.UpdateStudent(id, name, age, marks);
                    break;
                case 3:
                    Console.WriteLine("Enter ID to delete: ");
                    id = int.Parse(Console.ReadLine());
                    manager.DeleteStudent(id);
                    break;
                case 4:
                    manager.DisplayStudents();
                    break;
                case 5:
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
