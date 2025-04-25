using System.Text.RegularExpressions;

namespace StringCalculator.App
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;

            var delimiters = new List<string> { ",", "\n" };

            if (numbers.StartsWith("//"))
            {
                var match = Regex.Match(numbers, @"^//(.+?)\n");
                if (match.Success)
                {
                    var customDelimiter = match.Groups[1].Value;
                    delimiters.Add(customDelimiter);
                    numbers = numbers.Substring(match.Length);
                }
            }

            var parsedNumbers = numbers
                .Split(delimiters.ToArray(), StringSplitOptions.None)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(int.Parse)
                .ToList();


            var negatives = parsedNumbers.Where(n => n < 0).ToList();
            if (negatives.Any())
                throw new ArgumentException("Negatives not allowed: " + string.Join(", ", negatives));

            return parsedNumbers.Sum();
        }
    }
}
