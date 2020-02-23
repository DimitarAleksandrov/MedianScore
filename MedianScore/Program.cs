namespace MedianScore
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter integers, representing all test and assignment scores.");
            Console.WriteLine("Integers must be between 0 and 1000000 and must be comma and/or space separated");
            Console.Write("scorse = ");

            var scoresStringArr = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            ChecksBeforeParse(scoresStringArr.Length);

            var scores = new List<int>();

            ParseInputScores(scoresStringArr, scores);

            var medians = new List<int>();

            MedianScores(scores, medians);

            Console.WriteLine($"medianScores(scores) = [{string.Join(", ", medians)}]");

        }


        private static int[] MedianScores(List<int> scores, List<int> medians)
        {

            var currentScores = new List<int>();

            for (int i = 0; i < scores.Count; i++)
            {
                currentScores.Add(scores[i]);

                AddMedianToMediansArray(currentScores, medians);
            }

            return medians.ToArray();
        }
        private static void AddMedianToMediansArray(List<int> currentScores, List<int> medians)
        {
            currentScores.Sort();
            var cout = currentScores.Count;
            if (cout == 1)
            {
                medians.Add(currentScores[cout - 1]);
            }
            else
            {
                if (cout % 2 == 1)
                {
                    var midIndex = (int)Math.Floor(cout / 2.0);
                    medians.Add(currentScores[midIndex]);
                }
                else
                {
                    var index = cout / 2;
                    var sum = currentScores[index] + currentScores[index - 1];
                    var average = (int)Math.Ceiling(sum / 2.0);
                    medians.Add(average);
                }
            }
        }
        private static void ParseInputScores(string[] scoresStringArr, List<int> scores)
        {
            foreach (var currentScoreString in scoresStringArr)
            {
                try
                {
                    var currentNumber = int.Parse(currentScoreString);

                    if (currentNumber < 0)
                    {
                        throw new ArgumentException($"number '{currentNumber}' must be positive!");
                    }

                    if (currentNumber > 1000000)
                    {
                        throw new ArgumentException($"number '{currentNumber}' must be less than 1000000!");
                    }

                    scores.Add(currentNumber);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{currentScoreString}'");
                    throw;
                }
            }
        }

        private static void ChecksBeforeParse(int length)
        {
            if (length <= 1)
            {
                throw new ArgumentException("Enter at least one value!");

            }
            if (length > 50000)
            {
                throw new ArgumentException("Count of all test and assignment scores should be less than 50000!");
            }
        }
    }
}
