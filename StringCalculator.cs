namespace StringCalculatorTest;

public class StringCalculator
{
    public int Add(string numbers)
    { 
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }
        
        if (numbers.StartsWith("//"))
        {
            numbers = numbers.Substring(5);
        }
        
        var tokens = numbers.Split(',','\n');
        var negatives = new List<int>();
        
        int sum = 0;
        foreach (var token in tokens)
        {
            var parsedToken = int.Parse(token);
            if (parsedToken < 0)
            {
                negatives.Add(parsedToken);
            }

            if (parsedToken < 1000)
            {
                sum += parsedToken;
            }
        }

        if (negatives.Any())
        {
            throw new Exception($"Negatives are not allowed: {string.Join(",", negatives)}");
        }
        
        return sum;
    }
}