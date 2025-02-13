using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        string result = CapitalizeFirstLast(input);
        Console.WriteLine(result);
    }

    static string CapitalizeFirstLast(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        char[] charArray = input.ToCharArray();
        if (charArray.Length > 0)
            charArray[0] = charArray[0] >= 'a' && charArray[0] <= 'z' ? (char)(charArray[0] - 'a' + 'A') : charArray[0];
        if (charArray.Length > 1)
            charArray[charArray.Length - 1] = charArray[charArray.Length - 1] >= 'a' && charArray[charArray.Length - 1] <= 'z' ? (char)(charArray[charArray.Length - 1] - 'a' + 'A') : charArray[charArray.Length - 1];

        return new string(charArray);
    }
}
