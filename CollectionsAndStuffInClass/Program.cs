using System;
using System.Collections.Generic;

namespace CollectionsAndStuffInClass
{
    class Program
    {
        static void Main(string[] args)
        {
            //All of these built-in methods mutate the original collection
            // so they change the original list
            List<string> example = new List<string>(); //list of [type] string
            //List<T> is a generic type - a type that requires me to tell it what stuff it uses
            // `string` is a type parameter used to tell the List how to work
            var e14Names = new List<string>();

            //add a single item
            //works like push, appends to the end of the list
            e14Names.Add("Santa");
            e14Names.Add("Santa2");
            e14Names.Add("Bobby");
            e14Names.Add("Linda");

            //add item into a certain spot
            e14Names.Insert(1, "Gene");


            //collection intializer
            var teacherNames = new List<string> { "Nathan", "Jameka", "Dylan" };

            //add one collection to another
            e14Names.AddRange(teacherNames);

            //remove Santa (this uses new term: reference equality)
            //both point to the same plac ein meemory -- both reference the same thing
            e14Names.Remove("Santa");

            //remove by index
            e14Names.RemoveAt(0);

            //remove by expression remove any names that match this boolean expression
            //function will be called on at a time based on codition t/f starts with "S"
            //predicate of string and action of string (means returns void)
            e14Names.RemoveAll(name => name.StartsWith("S"));

            //normal c# foreach loop
            foreach (var name in e14Names)
            {
                Console.WriteLine($"{name} is in e14, ya'll!");
            }

            //list specific loop, takes in an Action<T> (like a fat arrow function in js)
            //usually .ForEach() is only on List<T> and not other collection types
            //this won't let you step thru foreach so use F9
            e14Names.ForEach(name => Console.WriteLine($"{name} is in e14, too!"));

            var firstStudent = e14Names[0]; //shallow copy?

            //Dictionary<TKey, TValue> -- Open Generic (no one told them how to behave)
            //Arity (`2 ) check out Nathan's pushed up code
            //like a physical dictionary... kinda
            //keys have to be unique

            //need things to be looked up quickly, but ok if it takes longer (than List)
            //dictionary is keyed by strings and also has strings as the values
            var dictionary = new Dictionary<string, string>(); //closed generic

            //adding things requires a key and a value
            dictionary.Add("Penultimate", "2nd to last");
            dictionary.Add("Jib", "Sticks out of rollercoasters");
            dictionary.Add("Arbitrary", "someone who doesn't like Arbi");

            //get one thing based on its key
            var definition = dictionary["Arbitrary"];

            //this wont' work: dictionaries require each key to be unique
            //dictionary.Add("Penultimate", "Mr. Mate Penulti");

            //try methods return a boolean indicating success or failure,
            // but... kind of expensive just to find out if the key exists
            if(!dictionary.TryAdd("Penultimate", "Mr. Mate Penulti"))
            {
                Console.WriteLine("stuff");
            }

            if (dictionary.ContainsKey("Penultimate"))
            {
                dictionary["Penultimate"] = "Thing said too many times";
            }

            var allTheWords = dictionary.Keys;

            //foreach (var item in dictionary)
            //{
            //    Console.WriteLine($"{item.Key}'s definition is {item.Value}");
            //}

            //C# destructuring (kinda like js) to turn each item into descrete var
            foreach (var (word, def) in dictionary)
            {
                    Console.WriteLine($"{word}'s definition is {def}");
            }

            var complicatedDictionary = new Dictionary<string, List<string>>();

            //review nathan's code when he pushes up

            //HashSet<T>
            //Like a list in that they store a valule at an index, and
            //Like a dictionary in that the value has to be unique
            //Completely different in that it eliminates non-unique stuff without errors
            //pretty slow at adding data, but
            //super-fast at getting data out, specifically comparing data
            //only for storing ONE copy of a thing, "enforces uniqueness

            var jamekasName = "Jameka";

            jamekasName.GetHashCode();

            var uniqueNames = new HashSet<string>();
            uniqueNames.Add("Jameka");
            uniqueNames.Add("Jameka");
            uniqueNames.Add("Jameka");
            uniqueNames.Add("Jameka");
            uniqueNames.Add("Jameka");
            uniqueNames.Add("Dylan");
            uniqueNames.Add("Dylan");

            uniqueNames.Remove("Dylan");

            foreach (var name in uniqueNames)
            {
                Console.WriteLine($"{name} is very unique!");
            }

            //Queue<T>
            //FIFO "First in, first out"
            //Queues are a FIFO-based collection

            var queueLine = new Queue<int>();
            queueLine.Enqueue(3);
            queueLine.Enqueue(1);
            queueLine.Enqueue(5);
            queueLine.Enqueue(87);
            queueLine.Enqueue(2);
            queueLine.Enqueue(0);
            queueLine.Enqueue(-1);

            while (queueLine.Count > 0)
            {
                //each time method will remove
                Console.WriteLine($"dequeuing {queueLine.Dequeue()}");
            }

            //######## Anything IEnumerable can use Linq
            //hashset more abotu perf benefits but stacks and queques are more about enforcing certain behavior
            
            //Stack<T>
            //LIFO "Last in, last out"
            //Stacks are a LIFO-based collection
            //things done in order, with bias towards recency

            var stack = new Stack<int>();

            stack.Push(2);
            stack.Push(6);
            stack.Push(5);
            stack.Push(4);
            stack.Push(1765);
            stack.Push(21767);
            stack.Push(22);

            //stack.Pop same as dequeue-ing just in the opposite order

            while (stack.Count > 0)
            {
                Console.WriteLine($"poppin' not poopin' {stack.Pop()}");
            }

            //tomorrow we're goign to talk abotu LINQ
        }
    }
}
