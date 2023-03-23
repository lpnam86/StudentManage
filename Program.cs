using System;
using System.Collections.Generic;

namespace StudentManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManage studentManage = new StudentManage();

            while (true)
            {
                Console.WriteLine("\nSTUDENT MANAGEMENT CONSOLE APP");
                Console.WriteLine("*************************MENU**************************");
                Console.WriteLine("**  1. Input student.                                **");
                Console.WriteLine("**  2. Update student by Id.                         **");
                Console.WriteLine("**  3. Delete student by Id.                         **");
                Console.WriteLine("**  4. Search student by name.                       **");
                Console.WriteLine("**  5. Sort students by GPA.                         **");
                Console.WriteLine("**  6. Sort students by name.                        **");
                Console.WriteLine("**  7. Sort student by Id.                           **");
                Console.WriteLine("**  8. Show student list.                            **");
                Console.WriteLine("**  0. Exit.                                         **");
                Console.WriteLine("*******************************************************");
                Console.Write("Input: ");
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        Console.WriteLine("\n1. Input student.");
                        studentManage.StudentImport();
                        //Console.WriteLine("\nThem sinh vien thanh cong!");
                        break;
                    case 2:
                        if (studentManage.StudentAmount() > 0)
                        {
                            int Id;
                            Console.WriteLine("\n2. Update student info. ");
                            Console.Write("\nInput Id: ");
                            Id = Convert.ToInt32(Console.ReadLine());
                            studentManage.StudentUpdate(Id);
                        }
                        else
                        {
                            Console.WriteLine("\nStudent list clear!");
                        }
                        break;
                    case 3:
                        if (studentManage.StudentAmount() > 0)
                        {
                            int Id;
                            Console.WriteLine("\n3. Delete student.");
                            Console.Write("\nInput ID: ");
                            Id = Convert.ToInt32(Console.ReadLine());
                            if (studentManage.StudentDelete(Id));
                            {
                                Console.WriteLine("\nStudent with id = {0} is deleted.", Id);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nstudentManage.StudentAmount()!");
                        }
                        break;
                    case 4:
                        if (studentManage.StudentAmount() > 0)
                        {
                            Console.WriteLine("\n4. Search by name.");
                            Console.Write("\nInput name: ");
                            string name = Convert.ToString(Console.ReadLine());
                            List<Student> searchResult = studentManage.FindbyName(name);
                            studentManage.showStudent(searchResult);
                        }
                        else
                        {
                            Console.WriteLine("\nStudent list clear!");
                        }
                        break;
                    case 5:
                        if (studentManage.StudentAmount() > 0)
                        {
                            Console.WriteLine("\n5. Sort student by GPA.");
                            studentManage.SortbyAverageMark();
                            studentManage.showStudent(studentManage.getStudentList());
                        }
                        else
                        {
                            Console.WriteLine("\nStudent list clear!");
                        }
                        break;
                    case 6:
                        if (studentManage.StudentAmount() > 0)
                        {
                            Console.WriteLine("\n6. Sort student by name.");
                            studentManage.SortbyName();
                            studentManage.showStudent(studentManage.getStudentList());
                        }
                        else
                        {
                            Console.WriteLine("\nStudent list clear!");
                        }
                        break;
                    case 7:
                        if (studentManage.StudentAmount() > 0)
                        {
                            Console.WriteLine("\n7. Sort student by Id.");
                            studentManage.SortbyId();
                            studentManage.showStudent(studentManage.getStudentList());
                        }
                        else
                        {
                            Console.WriteLine("\nStudent list clear!");
                        }
                        break;
                    case 8:
                        if (studentManage.StudentAmount() > 0)
                        {
                            Console.WriteLine("\n8. Show student list.");
                            studentManage.showStudent(studentManage.getStudentList());
                        }
                        else
                        {
                            Console.WriteLine("\nStudent list clear!");
                        }
                        break;
                    case 0:
                        Console.WriteLine("\nApp exit!");
                        return;
                    default:
                        Console.WriteLine("\nFunction not available!");
                        break;
                }
            }
        }
    }
}