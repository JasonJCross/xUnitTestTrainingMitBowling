using BowlingStandard;
using System;
using System.Collections.Generic;

namespace BowlingCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var bowling = new Bowling();

                if (args.Length > 0 && int.TryParse(args[0], out int rounds))
                {
                    bowling.TotalFrames = rounds;
                    bowling.NewGame();
                }

                Console.WriteLine($"Bowling: Enter Frames below:");

                for (var i = 1; i <= bowling.TotalFrames; i++)
                {
                    Console.Write($"Frame {i} : ");
                    var line = Console.ReadLine();
                    var splitLine = line?.Split(' ', ',', '\t');
                    var intList = new List<int>();
                    if (splitLine != null)
                    {
                        foreach (var split in splitLine)
                        {
                            if (int.TryParse(split, out int lineInt))
                            {
                                intList.Add(lineInt);
                            }
                        }
                    }

                    bowling.RecordFrame(intList.ToArray());
                }

                Console.WriteLine($"Game Total: {bowling.Score}. Thanks for Playing!");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
