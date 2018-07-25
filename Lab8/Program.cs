using System;
using System.Text.RegularExpressions;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            const string INPUT_CHECK = @"\w\s+";
            // set a constant int to the number of students
            const int NUMBER_OF_STUDENTS = 20;
            // 2d array of students and their info
            string[,] students = {
                    { "Michael Cacciano", "Waterbury", "pizza" },
                    { "Bob Smith", "Scranton", "cheese" },
                    { "Barbara Smith", "Alpena", "chips" },
                    { "John Doe", "Grand Rapids", "candy" },
                    { "Jane Doe", "Naugatuck", "ice" },
                    { "Bill Rogers", "Detroit", "lasagna" },
                    { "Holly Barry", "Lansing", "dumplings" },
                    { "Alvin Chipmunk", "Prospect", "rice" },
                    { "Simon Chipmunk", "Torrington", "pasta" },
                    { "Leanne Graham", "Cheshire", "pizza" },
                    { "Ervin Howell", "LA", "pizza" },
                    { "Clementine Bauch", "New York", "pizza" },
                    { "Patricia Lebsack", "San Francisco", "donuts" },
                    { "Chelsey Dietrich", "Chicago", "pizza" },
                    { "Dennis Schulist", "Austin", "steak" },
                    { "Kurtis Weissnat", "Houston", "food" },
                    { "Nicholas Runolfsdottir V", "Boston", "donuts" },
                    { "Glenna Reichert", "Miami", "tequilla" },
                    { "Clementina DuBuque", "Philly", "cheese steak" },
                    { "Chuck", "Burbank", "yogurt" }
            };
            // flag to keep program running in while loop
            bool isRunning = true;
            while (isRunning)
            {
                try
                {
                    // greet user
                    int studentId = GetIdOfStudent();
                    // Loop over the rows of arrays in the parent array order to access their children index values
                    for (int i = 0; i < NUMBER_OF_STUDENTS; i++)
                    {
                        // variables for storing specific user information
                        var studentName = students[i, 0];
                        var hometown = students[i, 1];
                        var favFood = students[i, 2];
                        // compare user input to children array index
                        int studentIndex = i + 1;
                        if (studentId == studentIndex)
                        {
                            DisplayStudentInfo(studentIndex, studentName, hometown, favFood);
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a number between 0-9");
                }
                // if user does not want to look up another student end program else run program from start
                if (!RunAgain())
                {
                    Console.WriteLine("Thanks! o/");
                    isRunning = false;
                }
            }
        }
        // method to display the specified user info, if invalid query calls itself recursively
        private static void DisplayStudentInfo(int studentIndex, string studentName, string hometown, string favFood)
        {
            // if user input  matches display index position and username then ask what info they would like
            Console.WriteLine($"Student {studentIndex} is {studentName}. What would you like to know about {studentName}?\n(enter or \"hometown\" or \"favorite food\")");
            // store request response for info
            var infoRequested = Console.ReadLine();
            // if info requested matches data stored display corresponding response
            if (infoRequested == "hometown")
            {
                Console.WriteLine($"{studentName}'s hometown is {hometown}.");
            }
            else if (infoRequested == "favorite food")
            {
                Console.WriteLine($"{studentName}'s favorite food is {favFood}.");
            }
            else
            {
                Console.WriteLine("That data does not exist. Pleast try again.(enter 'hometown' or 'favorite food')");
                // if invalid input display error message and call this function recursively
                DisplayStudentInfo(studentIndex, studentName, hometown, favFood);
            }
        }
        // method to get the user id as well as validate is int, if invalid query calls itself recursively
        private static int GetIdOfStudent()
        {
            Console.Write("Welcome to our C# class. Which student would you like to learn more about? : ");
            string userInput = Console.ReadLine();
            // try parse to check if the user input is actually a number then check for the range
            if (int.TryParse(userInput, out int studentId) && studentId > 0 && studentId < 21)
            {
                return studentId;
            }
            else
            {
                Console.WriteLine("That student does not exist. Please try again. (Enter a number between 1 and 20)");
                return GetIdOfStudent();
            }

        }
        // method to ask the user if they would like to look up another student
        private static bool RunAgain()
        {
            Console.WriteLine("Would you like to look up another student? (y/n)");
            var yOrNo = Console.ReadLine().ToLower();
            if (yOrNo.StartsWith('y'))
            {
                return true;
            }
            else if (yOrNo.StartsWith('n'))
            {
                return false;
            }
            else
            {
                RunAgain();
                return false;
            }
        }
    }
}
