// See https://aka.ms/new-console-template for more information

namespace Name
{
    class Program
    {
        // NOTE: with c#, keep in mind when declaring properties and methods in classes, the use of "private" or "public" is essential to define the accessibility of those members. Meanwhile, "static" is an optional modifier that you include only if the member should belong to the class itself rather than an instance of the class.
        static void Main(string[] args)
        {
            // ||| variables
            string name = "Camo";
            int integer = 44;
            // NOTE: float is less precise, double is normal, decimal is super precise!
            double cuteness = 10.0;
            char character = 'e';
            bool isCool = true;

            // ||| working w. strings
            Console.WriteLine($"{name} is a cat and has a cute rating of {cuteness}!");
            name = "Beau";
            cuteness = 9.3;
            string sentence = $"{name} on the other hand has a cuteness of {cuteness}";
            Console.WriteLine(sentence);
            Console.WriteLine(sentence.Length);
            Console.WriteLine(sentence.ToLower());
            Console.WriteLine(sentence.Contains("Beau"));
            Console.WriteLine(sentence.IndexOf(character));
            Console.WriteLine(sentence.Substring(4, 13));

            // ||| user input
            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();
            Console.WriteLine($"Hello, {userName}");

            // ||| conversions
            string fifty = "50";
            Console.WriteLine(fifty + 5); // write 505
            Console.WriteLine(Convert.ToInt32(fifty) + 5); // 55 is correct!

            // ||| arrays
            int[] luckyNumbers = { 4, 66, 9, 111, 293833, -5 };
            luckyNumbers[2] = 69;
            Console.WriteLine(luckyNumbers[0]);
            Console.WriteLine(luckyNumbers.Last());
            Console.WriteLine(luckyNumbers.All(num => num > 0));
            string[] animals = new string[5]; // we can make an array of 5 elements, but not populate it just yet!

            // ||| calling methods and using conditionals
            Greeting("Alex", luckyNumbers);

            int hat = 3;
            if (hat != 3)
            {
                Console.WriteLine("Hat is not 3");
            }
            else
            {
                Console.WriteLine("Hat is indeed 3");
            }

            if (hat == 3 && fifty == "50")
            {
                Console.WriteLine(Cube(3)); // 27
            }

            Console.WriteLine(dayOfWeek(2));

            looping(12);

            guessingGame();

            Console.WriteLine(forLooping()); // 24

            // ||| 2d arrays
            int[,] numberGrid = {
                {9,8,7},
                {6,5,4},
                {3,2,1}
            };
            Console.WriteLine(numberGrid[1, 1]); // 5

            // ||| exceptions
            try
            {
                Console.Write("Enter a number: ");
                int num1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter another number: ");
                int num2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(num1 / num2);
            }
            // explicitly catch divide by zero errors
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            // explicitly catch format exception errors (ex. user tries to put in a string instead of a number)
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Finally will always run no matter if a catch was made or not!");
            }

            // ||| objects ("namespace.class" is used to define each instance)
            CouchNamespace.Couch couch1 = new CouchNamespace.Couch("leather", "teal", 177);
            // couch1.type = "leather";
            // couch1.color = "teal";
            // couch1.length = 177;
            Console.WriteLine(couch1);
            Console.WriteLine(couch1.length);

            CouchNamespace.Couch couch2 = new CouchNamespace.Couch(false);

            Console.WriteLine(couch2.condition);
            // using an object method
            couch2.changeCondition();
            Console.WriteLine(couch2.condition);

            // ||| getters and setters
            Movie.Movie movie1 = new Movie.Movie("Power of the Dog", 124, "R");
            Console.WriteLine(movie1.ToString()); // all valid values
            Movie.Movie movie2 = new Movie.Movie("Escape from Alcatraz", 144, "ASJ3");
            Console.WriteLine(movie2.ToString()); // by default, the rating should say "N/A" as the current value isn't valid by the setter definition

            // NOTE: below causes an error, because "rating" is inaccessible due to its private protection as defined in the class setter method in Movie.cs...
            // movie2.rating = "PG";

            // ...but, we can use "Rating" to set the value instead, as that assigns via the setter method properly:
            movie2.Rating = "PG";
            Console.WriteLine(movie2.ToString()); // see the rating property has correctly changed!

            // since the Movie constructor increases the static property movieCount, we should be able to see that there are two movies now created. We cannot see the static property via an instance of the object -- we can just use the class name itself to access, as its accessible to the entire class not just instances:
            Console.WriteLine(Movie.Movie.movieCount); // 2

            // the only way to see the static property via an object instance is from a created getter method:
            Console.WriteLine(movie2.getCount()); // now this can work: 2

            // using static methods of a class
            Movie.Movie.DeclareMovieStatement();

            // Netflix doesn't have a "toString" method, but it inherits one from Movie, so it can use it: 
            Netflix.Netflix net1 = new Netflix.Netflix("lotr", 200, "PG-13");
            Console.WriteLine(net1.ToString());





        }

        // ||| methods
        // return statement: void (ie. nothing)
        static void Greeting(string name, int[] numbers)
        {
            Console.WriteLine($"Hi {name} from Greeting method! {numbers.Count()}");
        }

        // return statement: void (ie. nothing)
        static int Cube(int number)
        {
            return Convert.ToInt32(Math.Pow(number, 3));
        }

        // ||| switch statements
        static string dayOfWeek(int dayNum)
        {
            string dayName;

            switch (dayNum)
            {
                case 0:
                    dayName = "Sunday";
                    break;
                case 1:
                    dayName = "Monday";
                    break;
                case 2:
                    dayName = "Tuesday";
                    break;
                case 3:
                    dayName = "Wednesday";
                    break;
                case 4:
                    dayName = "Thursday";
                    break;
                case 5:
                    dayName = "Friday";
                    break;
                case 6:
                    dayName = "Saturday";
                    break;
                default:
                    dayName = "Invalid day";
                    break;
            }
            return dayName;
        }

        // ||| while loop
        static void looping(int num)
        {
            int index = 1;
            while (index <= num)
            {
                Console.WriteLine(index);
                index++;
            }
            Console.WriteLine("done loop!");
        }

        // ||| do while loop
        static void guessingGame()
        {
            string guess;
            int count = 0;
            do
            {
                Console.Write("Enter guess word: ");
                guess = Console.ReadLine();
                count++;
            }
            while (guess != "water");

            Console.WriteLine($"Correct, the word was water! It took you {count} guesses.");

        }

        // ||| for loop
        static int forLooping()
        {
            dynamic num = null;
            int[] arr = { 4, 8, 24, 666, 2 };
            for (int i = 1; i <= arr.Length; i++)
            {
                if (i == 2)
                {
                    num = arr[i];
                }
            }
            return num;
        }

    }
}