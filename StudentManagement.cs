using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    class StudentManage
    {
        private List<Student> StudentList = null;

        public StudentManage()
        {
            StudentList = new List<Student>();
        }

        private int GenerateId()
        {
            int max = 1;
            if (StudentList != null && StudentList.Count > 0)
            {
                max = StudentList[0].Id;
                foreach (Student st in StudentList)
                {
                    if (max < st.Id)
                    {
                        max = st.Id;
                    }
                }
                max++;
            }
            return max;
        }

        public int StudentAmount()
        {
            int Count = 0;
            if (StudentList != null)
            {
                Count = StudentList.Count;
            }
            return Count;
        }

        //Import student info
        public void StudentImport()
        {
            Student st = new Student();
            st.Id = GenerateId();

            Console.Write("Import student name: ");
            st.Name = Convert.ToString(Console.ReadLine());
            if (st.Name.Length == 0)
            {
                Console.WriteLine("Illegal value");
                return;
            }


            Console.Write("Import student sex: ");
            st.Sex = Convert.ToString(Console.ReadLine());
            if (st.Sex != "Male" && st.Sex != "Female")
            {
                Console.WriteLine("Illegal value");
                return;
            }

            Console.Write("Import student age: ");
            st.Age = Convert.ToInt32(Console.ReadLine());
            if (st.Age < 18)
            {
                Console.WriteLine("Illegal value");
                return;
            }

            Console.Write("Import student math mark: ");
            st.Math = Convert.ToDouble(Console.ReadLine());
            if (st.Math < 0 && st.Math > 10)
            {
                Console.WriteLine("Illegal value");
                return;
            }

            Console.Write("Import student physic mark: ");
            st.Physic = Convert.ToDouble(Console.ReadLine());
            if (st.Physic < 0 && st.Physic > 10)
            {
                Console.WriteLine("Illegal value");
                return;
            }

            Console.Write("Import student chemistry mark: ");
            st.Chemistry = Convert.ToDouble(Console.ReadLine());
            if (st.Chemistry < 0 && st.Chemistry > 10)
            {
                Console.WriteLine("Illegal value");
                return;
            }

            AverageMark(st);
            StudenRank(st);
            StudentList.Add(st);
        }



        //Update student info
        public void StudentUpdate(int Id)
        {
            Student st = FindbyId(Id);

            if (st != null)
            {
                Console.Write("Update student name: ");
                string Name = Convert.ToString(Console.ReadLine());
                if (Name != null && Name.Length > 0)
                {
                    st.Name = Name;
                }

                Console.Write("Update student sex: ");
                string Sex = Convert.ToString(Console.ReadLine());
                if (Sex == "Male" || Sex == "Female")
                {
                    st.Name = Name;
                }
                else
                {
                    Console.WriteLine("Wrong sex!");
                }

                Console.Write("Update student age: ");
                int Age = Convert.ToInt32(Console.ReadLine());
                if (Age != null && Age > 0)
                {
                    st.Age = Age;
                }

                Console.Write("Update math mark: ");
                int Math = Convert.ToInt32(Console.ReadLine());
                if (Math != null && Math >= 0 && Math <= 10)
                {
                    st.Math = Math;
                }
                else
                {
                    Console.WriteLine("Mark not suitable!");
                }

                Console.Write("Update physic mark: ");
                int Physic = Convert.ToInt32(Console.ReadLine());
                if (Physic != null && Physic >= 0 && Physic <= 10)
                {
                    st.Physic = Physic;
                }
                else
                {
                    Console.WriteLine("Mark not suitable!");
                }

                Console.Write("Update chemistry mark: ");
                int chemistry = Convert.ToInt32(Console.ReadLine());
                if (chemistry != null && chemistry >= 0 && chemistry <= 10)
                {
                    st.Chemistry = chemistry;
                }
                else
                {
                    Console.WriteLine("Mark not suitable!");
                }

                AverageMark(st);
                StudenRank(st);

            }
            else
            {
                Console.WriteLine($"Student with Id {Id} not found !");
            }
        }

        //delete student
        public bool StudentDelete(int Id)
        {
            bool IsDeleted = false;
            Student st = FindbyId(Id);
            if (st != null)
            {
                IsDeleted = StudentList.Remove(st);
            }
            return IsDeleted;
        }


        //Sort student by name
        public void SortbyName()
        {
            StudentList.Sort(delegate (Student st1, Student st2)
            {
                return st1.Name.CompareTo(st2.Name);
            });
        }

        //Sort student by id
        public void SortbyId()
        {
            StudentList.Sort(delegate (Student st1, Student st2)
            {
                return st1.Id.CompareTo(st2.Id);
            });
        }

        //Sort student by average mark
        public void SortbyAverageMark()
        {
            StudentList.Sort(delegate (Student st1, Student st2)
            {
                return st1.AverageMark.CompareTo(st2.AverageMark);
            });
        }


        //Student average mark
        private void AverageMark(Student st)
        {
            double averageMark = (st.Math + st.Physic + st.Chemistry) / 3;
            st.AverageMark = Math.Round(averageMark, 2, MidpointRounding.AwayFromZero);
        }


        //Student rank
        private void StudenRank(Student st)
        {
            if (st.AverageMark >= 8)
            {
                st.Rank = "Gioi";
            }
            else if (st.AverageMark >= 6.5)
            {
                st.Rank = "Kha";
            }
            else if (st.AverageMark >= 5)
            {
                st.Rank = "Trung binh";
            }
            else
            {
                st.Rank = "Yeu";
            }
        }

        //Find student by id 
        public Student FindbyId(int Id)
        {
            Student result = null;
            if (StudentList != null && StudentList.Count > 0)
            {
                foreach (Student st in StudentList)
                {
                    if (st.Id == Id)
                    {
                        result = st;
                        break;
                    }
                }
            }
            return result;

        }

        //Find student by name
        public List<Student> FindbyName(string keyword)
        {
            List<Student> searchResult = new List<Student>();
            if (StudentList != null && StudentList.Count > 0)
            {
                foreach (Student st in StudentList)
                {
                    if (st.Name.ToUpper().Contains(keyword.ToUpper()))
                    {
                        searchResult.Add(st);
                    }
                }
            }
            return searchResult;
        }

        public void showStudent(List<Student> stList)
        {
            Console.WriteLine("{0, -5} {1, -20} {2, -5} {3, 5} {4, 5} {5, 5} {6, 5} {7, 10} {8, 10}",
                "Id", "Name", "Sex", "Age", "Math", "Physic", "Chemistry", "Average Mark", "Rank");

            if (stList != null && stList.Count > 0)
            {
                foreach (Student st in stList)
                {
                    Console.WriteLine("{0, -5} {1, -20} {2, -5} {3, 5} {4, 5} {5, 5} {6, 5} {7, 10} {8, 10}",
                        st.Id, st.Name, st.Sex, st.Age, st.Math, st.Physic, st.Chemistry, st.AverageMark, st.Rank);
                }
            }
            Console.WriteLine();
        }

        public List<Student> getStudentList()
        {
            return StudentList;
        }
    }
}
