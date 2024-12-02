using System.Collections.Generic;

public class NumberGenerator
{
    public IEnumerable<int> GenerateNumbers(int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            yield return i;
        }
    }
}

