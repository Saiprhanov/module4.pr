using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module4prct
{
     struct Student
    {
        public string Name;
        public string GroupNumber;
        public int[] Grades;

        public double GetAverageGrade()
        {
            int sum = 0;
            foreach (int grade in Grades)
            {
                sum += grade;
            }
            return (double)sum/Grades.Length;
        }
    }
    class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }        
        public int Year { get; set; }

        public override string ToString()
        {
            return $"Автор: {Author}, Название: {Title},  Год издания: {Year}";
        }
    }

    class Library
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }

        public List<Book> SearchByAuthor(string author)
        {
            return books.Where(book => book.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Book> SearchByYear(int year)
        {
            return books.Where(book => book.Year == year).ToList();
        }

        public void SortByTitle()
        {
            books.Sort((book1, book2) => book1.Title.CompareTo(book2.Title));
        }

        public void SortByAuthor()
        {
            books.Sort((book1, book2) => book1.Author.CompareTo(book2.Author));
        }

        public void SortByYear()
        {
            books.Sort((book1, book2) => book1.Year.CompareTo(book2.Year));
        }

        public override string ToString()
        {
            string result = "Каталог книг в библиотеке:\n";
            foreach (var book in books)
            {
                result += book.ToString() + "\n";
            }
            return result;
        }
    }
    class Program
    {
        static void Exm01()
        {
            string[] Names = { "Нурхадис", "Нурдаулет", "Анеля", "Аскар", "Назира", "Даник", "Радиатор", "Кайпрат (который Нуртас)", "Лейла", "Жумабек" };
            Student[] students = new Student[10];
            Random random = new Random();

            // Инициализация студентов и их успеваемости с использованием казахских имен
            for (int i = 0; i < students.Length; i++)
            {
                students[i].Name = Names[i];
                students[i].GroupNumber = "1";
                students[i].Grades = new int[] { random.Next(2, 6), random.Next(4, 6), random.Next(4, 6), random.Next(4, 6), random.Next(4, 6) };
            }

            // Сортировка студентов по возрастанию среднего балла
            Array.Sort(students, (s1, s2) => s1.GetAverageGrade().CompareTo(s2.GetAverageGrade()));

            // Вывод фамилий и номеров групп студентов с оценками 4 или 5
            Console.WriteLine("Студенты с оценками 4 или 5:");
            foreach (var student in students)
            {
                bool hasHighGrades = true;
                foreach (var grade in student.Grades)
                {
                    if (grade < 4)
                    {
                        hasHighGrades = false;
                        break;
                    }
                }
                if (hasHighGrades)
                {
                    Console.WriteLine($"Фамилия: {student.Name}, Группа: {student.GroupNumber}");
                }
            }
        }
        static void Exm02()
        {
            Library library = new Library();

            // Добавление книг в библиотеку
            library.AddBook(new Book { Title = "Золотая Орда", Author = "Ильяс Есенберлин", Year = 1983 });
            library.AddBook(new Book { Title = "Ботагоз", Author = "Сабит Муканов", Year = 1957 });
            library.AddBook(new Book { Title = "Тернистый путь", Author = "Сакен Сейфулин", Year = 1964 });

            // Поиск книги по автору
            List<Book> booksByAuthor = library.SearchByAuthor("Ильяс Есенберлин");
            Console.WriteLine("Книги Ильяса Есенберлина:");
            foreach (var book in booksByAuthor)
            {
                Console.WriteLine(book);
            }

            // Сортировка книг по названию и вывод списка
            library.SortByTitle();
            Console.WriteLine("\nСортировка по названию:");
            Console.WriteLine(library);

            // Удаление книги из библиотеки
            Book bookToRemove = new Book { Title = "Ботагоз", Author = "Сабит Муканов", Year = 1957 };
            library.RemoveBook(bookToRemove);
            Console.WriteLine("Книга удалена. Обновленный список книг:");
            Console.WriteLine(library);
        }


        static void Main(string[] args)
        {
            Exm01();
            Exm02();
        }
    }
}
