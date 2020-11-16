using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using EfDbFirstDemo.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace EfDbFirstDemo.ConsoleApp
{
    class Program
    {

        static DbContextOptions<ChinookContext> s_dBContextOptions;

        static void Main(string[] args)
        {
            //goes to bin/debug but we can access it 
            using var logStream = new StreamWriter("ef-logs.txt");
            //DBContextOptions is how we give the context its connection string to log in to the SQL server.
            // Tell it to use SQLServer (not MySQL), and any other EF side options
            var optionsBuilder = new DbContextOptionsBuilder<ChinookContext>();
            string connectString = ConnectionString._connectStr;
            
            optionsBuilder.UseSqlServer(connectString);
            //optionsBuilder.LogTo(x => Debug.WriteLine(x));

            //Can have multiple log to-- write serious stuff one place, lesss serious stuff elsewhere
            optionsBuilder.LogTo(logStream.Write, LogLevel.Information);
            
            s_dBContextOptions = optionsBuilder.Options;

           // Display5Tracks();
            Console.WriteLine("--------------");

            Console.WriteLine("-------Edit Track--------");
            //EditTrack();

            // Display5Tracks();

            //Console.WriteLine(" ");
            Console.WriteLine("-------Find Record--------");
            FindARecordByName("AASongAA");
           
            // This worked I think 
            Console.WriteLine("-------Insert Track--------");
            //InsertNewTrack();

            Console.WriteLine("-------Delete Track--------");

            Display5Tracks();
            Console.WriteLine("---------------");


            //edit One of those tracks
            //Display5Tracsks
            //Delete That Track
            //Display5

            //for bonus points, edit more than one table
            //  or do it based on user input rather than hardcoded data


        }


        static void FindARecordByName(string trackName) 
        {
            using var context = new ChinookContext(s_dBContextOptions);
            var track = context.Tracks.Find(1);
            Console.WriteLine($"Track Name = {trackName} - {track.TrackId} - {track.MediaTypeId}");

            //The right way to do a find.
            //var foundTrack = context.Tracks.Find(trackName)

            //wrong way 
            // context.Tracks.OrderBy(x => x.Name == trackName).First();

        }


        static void FindARecordById(int id) 
        {
            using var context = new ChinookContext(s_dBContextOptions);
            var track = context.Tracks.OrderBy(x => x.TrackId == id).First();
            Console.WriteLine($"Track Id = {id} - {track.TrackId} - {track.Name} - {track.MediaTypeId}");


        }


        static void EditTrack()
        {
            using var context = new ChinookContext(s_dBContextOptions);
            var track = context.Tracks.OrderBy(t => t.Name).First();

            
            Console.WriteLine($"First Track--> {track.Name} - {track.TrackId}");

            track.Milliseconds = (int)1111112222;

            context.Tracks.Update(track);// Update method will make the context track the object you pass if it isnt already

            // all the changes are applied as a transaction by default.
            context.SaveChanges();
            // Async has plenty of support in EF
            //context.SaveChangesAsync();

            //could do more changes here past savechanges then call saveChanges again.

        }

        static void InsertNewTrack()
        {
            using var context = new ChinookContext(s_dBContextOptions);

            var newTrack = new Track { TrackId = 151516, Name = "AASongAA" };
            context.Tracks.Add(newTrack);
            context.SaveChanges();

            
        }

        static void Display5Tracks()
        {
            Console.WriteLine("-------Display 5 Tracks----------");
            // first thing you need to connect to db is an instance of dbcontext
            using var context = new ChinookContext(s_dBContextOptions);
            
            IQueryable<Track> tracks = context.Tracks.OrderBy(t => t.Name).Take(5);

            //at this point, the query has not been sent and the results have not been downloaded.
            //  set up ahead of time what will be calculate(order by stuff is setting that up)
            //  LINQ uses deferred execution.
            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.TrackId} - {track.Name} - { track.Milliseconds} - { track.Genre} - {track.MediaType}");
            }
            Console.WriteLine("-------Display 5 Tracks----------");
           

        }

       
    }

}
