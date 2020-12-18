using System;
using System.Collections.Generic;//If your going to use it once than you can 
using System.Linq;
//add it to the beginning of where your using it.

namespace LinkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();

            for(int i=0; i <10;i++)
            {
                players.Add(new Player(){
                    Fname = "Player-"+ i,
                    Lname = "" + (i -(i*2))
                });
            }

            foreach( var y in players)
            {
                Console.WriteLine($"Fname: {y.Fname} Lname: {y.Lname}");
            }

            var results = players.Where(x => x.Fname == "Player-4").FirstOrDefault();
            if(results != null)
            {
                Console.WriteLine($"The Players Fname is {results.Fname} and their last name is {results.Lname}");
            }
            else{
                throw new ArgumentException("The player wasn't found.");
            }
            
            // foreach(var z in results)
            // {
            //     Console.WriteLine(z);
            // }

            int count = players.Count;
            players.Remove(results);
            results = players.Where(x => x.Fname == "Player-4").FirstOrDefault();
            if(results != null)
            {
                Console.WriteLine($"The Players Fname is {results.Fname} and their last name is {results.Lname}");
            }
            else{
                throw new ArgumentException("The player wasn't found.");
            }


        }
    }
}
