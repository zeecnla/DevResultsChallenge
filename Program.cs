using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


/**
Explaintion I understood it was some sor tof combination/permutations problem. You find
the possible combinations for first name then after it gets all of them it moves on to the second name
and so on and so on.
**/
namespace dev_results
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>{"Herb","Shane","Brent","Diego","Nathan"};
            var result = Calculate(list, 3);

            foreach (var subList in result)
            {
                foreach (var item in subList)
                {
                    Console.Write(item+" ");
                }
                Console.WriteLine();
            }
        }
        static IEnumerable<IEnumerable<string>>  Calculate(IEnumerable<string> input, int count)
        {
            int i = 0;
            foreach(var item in input)
            {
                if(count == 1)
                    yield return new List<string>  { item };
                else
                {

                    foreach(var result in Calculate(input.Skip(i + 1), count - 1))
                        yield return new List<string> { item }.Concat(result);
                }

                i++;
            }
        }

    }
}

/**
Result:

Herb Shane Brent
Herb Shane Diego
Herb Shane Nathan
Herb Brent Diego
Herb Brent Nathan
Herb Diego Nathan
Shane Brent Diego
Shane Brent Nathan
Shane Diego Nathan
Brent Diego Nathan
**/
