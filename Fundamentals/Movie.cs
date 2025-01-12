namespace Movie
{
    class Movie
    {
        // NOTE: static properties (or methods) belong to the class itself -- meaning any instance of the class has access to it! A static method or property cannot directly access non-static (instance) members because it doesn’t have an instance to work with.
        public static int movieCount;
        public string title;
        public int mins;
        // NOTE: public means that any piece of code is able to use the data/method of the class (even code outside the class), but private limits the access to the defined scope of the class (ie. the below string rating is only accessible to this file -- it will not be accessible in Program.cs! ).
        private string rating;
        public Movie(string aTitle, int aMins, string aRating)
        {
            title = aTitle;
            mins = aMins;
            Rating = aRating; // we want to make sure to call the method used for setter!! The whole point of using setter would not work as expected if we assigned: rating = aRating!

            movieCount++; // increase static property
        }

        // dealing with private class variables often wants to include explicit ways of getting and setting it to limit access
        public string Rating
        {
            get { return rating; }
            set
            {
                // you can limit the values that can be set for certain object properties, and often include some sort of default, too.
                // NOTE: the "value" keyword is automatically given as a default parameter by C# when dealing with an object setter method, as it represents what is passed in during instantiation. 
                if (value == "G" || value == "PG" || value == "PG-13" || value == "R")
                {
                    rating = value;
                }
                else
                {
                    rating = "N/A";
                }
            }
        }

        // NOTE: every object has a built-in ToString() method. But when its called it only prints out the "namespace.class" of the object, which is hardly useful. Unless you know data will be serialized with JSON or data by an object will never be exposed, it is considered good practice to override the ToString method with ojewcts becuase it allows for an easy way to inspect and thus debug object instances:
        public override string ToString()
        {
            return $"title: {title}, mins: {mins}, Rating: {Rating}";
        }

        public int getCount()
        {
            return movieCount;
        }

        // ||| static methods are avialbe to the class and not instances
        public static void DeclareMovieStatement()
        {
            Console.WriteLine("Movie class");
        }
    }
}