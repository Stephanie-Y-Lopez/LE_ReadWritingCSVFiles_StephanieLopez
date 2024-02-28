namespace LE_ReadWritingCSVFiles_StephanieLopez
{
    internal class Program
    {
        //Stephanie Lopez
        static void Main(string[] args)
        {
            List<Student> dataList = new List<Student>();

            bool exit = false;

            while (!exit)
            {
                Console.Write("Choose an option: ");
                Console.WriteLine("");
                Console.WriteLine("1. Create");
                Console.WriteLine("2. Open");
                Console.WriteLine("3. Save");
                Console.WriteLine("4. Append");
                Console.WriteLine("5. Exit");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        CreateStudent(dataList);
                        break;
                    case "2":
                        OpenFile(dataList);
                        break;
                    case "3":
                        SaveToFile(dataList);
                        break;
                    case "4":
                        AppendToFile(dataList);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Choose again please.");
                        break;
                }
            }
        }

        static void CreateStudent(List<Student> data)
        {
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter last name: ");

            string lastName = Console.ReadLine();

            int grade;
            bool validGradeInput = false;

            do
            {
                Console.Write("Enter grade: ");
                string gradeInput = Console.ReadLine();
                validGradeInput = int.TryParse(gradeInput, out grade);

                if (!validGradeInput)
                {
                    Console.WriteLine("Enter a valid number for grade please.");
                }
            } while (!validGradeInput);

            data.Add(new Student(firstName, lastName, grade));
        }

        static void OpenFile(List<Student> data)
        {
            Console.Write("Enter file name to open: ");
            string fileName = Console.ReadLine();

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string firstName = parts[0];
                    string lastName = parts[1];
                    int grade = int.Parse(parts[2]);
                    data.Add(new Student(firstName, lastName, grade));
                }
            }
            Console.WriteLine("File opened successfully!");
        }

        static void SaveToFile(List<Student> data)
        {
            Console.Write("Enter file name to save: ");
            string fileName = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Student student in data)
                {
                    writer.WriteLine($"{student._firstname},{student._lastname},{student._grade}");
                }
            }
            Console.WriteLine("File saved successfully!");
        }

        static void AppendToFile(List<Student> data)
        {
            Console.Write("Enter file name to append: ");
            string fileName = Console.ReadLine();
            using (StreamWriter writer = File.AppendText(fileName))
            {
                foreach (var student in data)
                {
                    writer.WriteLine($"{student._firstname},{student._lastname},{student.Grade}");
                }
            }
            Console.WriteLine("Data appended to file successfully.");
        }

        //Questions:
        //1. What does.csv stand for? .csv stands for Comma-Separated Values

        //2. What package do we use to help import CSV files? We use the CsvHelper package.

        //3. What keyword do we use when reading and saving to files? using.

        //4. What's the different between FileMode.Append and FileMode.OpenOrCreate?
        //The difference is, FileMode.Append adds data to the end of an existing file. While FileMode.OpenOrCreate opens an existing file or creates a new file (if it doesn't exist).

        //5. It's wise to save your file locations in a ______ class so that all files can access the same file locations.
        //Configuration.

    }
}
