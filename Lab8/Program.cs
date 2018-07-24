using System; 

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
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
                    { "Theodore Chipmunk", "Cheshire", "pizza" }
            };
            // flag to keep program running in while loop
            bool isRunning = true;
            while (isRunning)
            {
                try
                {
                    // greet user
                    Console.Write("Welcome to our C# class. Which student would you like to learn more about? : ");
                    // store input to use for finding student info
                    var userInput = int.Parse(Console.ReadLine());
                    // Loop over the rows of arrays in the parent array order to access their children index values
                    for (int i = 0; i < NUMBER_OF_STUDENTS; i++)
                    {
                        // variables for storing specific user information
                        var studentName = students[i, 0];
                        var hometown = students[i, 1];
                        var favFood = students[i, 2];
                        // compare user input to children array index
                        i += 1;
                        if (userInput == i)
                        {
                            // if user input  matches display index position and username then ask what info they would like
                            Console.WriteLine($"Student {i} is {studentName}. What would you like to know about {studentName}?\n(enter or \"hometown\" or \"favorite food\")");
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
                            // if user makes and a request for info no in the system
                            else
                            {
                                Console.WriteLine("Sorry but there is no info for that inquiry");
                            }
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Sorry but you must input an integer from 1-10");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Sorry but there are only 10 students currently in the database");
                }
                // if user does not want to look up another student end program else run program from start
                if (!RunAgain())
                {
                    Console.WriteLine("Thanks! o/");
                    isRunning = false;
                }
            }
            
        }
        // method to ask the user if they would like to look up another student
        private static bool RunAgain()
        {
            Console.WriteLine("Would you like to look up another student?");
            var yOrNo = Console.ReadLine();
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
