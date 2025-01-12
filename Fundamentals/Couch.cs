using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace CouchNamespace
{
    class Couch
    {
        public string type;
        public string color;
        public int length;

        public bool condition;

        // ||| constructor (always a method in a class with the exact same name)
        public Couch(string argType, string argColor, int argLength)
        {
            type = argType;
            color = argColor;
            length = argLength;
        }

        // you can have multiple constructors for a class:
        public Couch(bool argCondition)
        {
            condition = argCondition;

        }

        // ||| object methods
        public bool changeCondition()
        {
            condition = !condition;
            return condition;
        }

    }
}