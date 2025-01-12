namespace Netflix
{
    // invoke inheritance
    class Netflix : Movie.Movie
    {

        public Netflix(string aTitle, int aMins, string aRating) : base(aTitle, aMins, aRating)
        {
        }
    }
}