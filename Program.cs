using System;

class MainClass
{
    public static string StringChallenge(string str)
    {
        str = string.Concat(str.Where(c => !char.IsWhiteSpace(c)));
        if (str == Reverse(str))
            return "true";
        return "false";
    }

    public static string Reverse(string str)
    {
        string reversedString = string.Empty;
        for (int i = str.Length - 1; i >= 0; i--)
        {
            reversedString += str[i];
        }
        return reversedString;
    }

    public static string SearchingChallenge(string str)
    {
        int total = 0;
        int openParenthesis = 0;
        int openBrackets = 0;
        bool error = false;

        for (int i = 0; i < str.Length; i++)
        {
            switch (str[i])
            {
                case '(':
                    openParenthesis++;
                    break;
                case ')':
                    if (openParenthesis == 0)
                        error = true;

                    openParenthesis--;
                    total++;
                    break;
                case '[':
                    openBrackets++;
                    break;
                case ']':
                    if (openBrackets == 0)
                        error = true;

                    openBrackets--;
                    total++;
                    break;
            }

            if (error)
                break;
        }

        if (error || openParenthesis > 0 || openBrackets > 0)
            return "0";

        return "1 " + total;
    }

    public static string ArrayChallenge1(string[] strArr)
    { 
        string result = "not possible";
        string sequence = strArr[0];
        string[] dictionary = strArr[1].Split(",");

        for (int i = 0; i < sequence.Length - 1; i++)
        {
            string firstWord = sequence.Substring(0, i + 1);
            string secondWord = sequence.Substring(i + 1);

            if (Array.Exists(dictionary, e => e == firstWord) && Array.Exists(dictionary, e => e == secondWord))
            {
                result = firstWord + "," + secondWord;
                break;
            }
        }

        return result;
    }

    public static string ArrayChallenge2(string[] strArr)
    {
        int currentGallons = 0;
        string result = "impossible";
        int startingPoint = 0;

        for (int i = 1; i < strArr.Length; i++)
        {
            string[] split = strArr[i].Split(":");
            int gallons = int.Parse(split[0]);
            int neededGallons = int.Parse(split[1]);

            if (gallons >= neededGallons && startingPoint == 0)
            {
                startingPoint = i;
                currentGallons = 0;
            }

            if (startingPoint == 0)
                continue;

            if (currentGallons <= 0 && neededGallons > gallons)
            {
                startingPoint = 0;
                continue;
            }
            currentGallons += gallons - neededGallons;
        }

        if (startingPoint == 0)
            return result;

        for (int i = 1; i <= startingPoint; i++)
        {
            string[] split = strArr[i].Split(":");
            int gallons = int.Parse(split[0]);
            int neededGallons = int.Parse(split[1]);

            currentGallons += gallons - neededGallons;

            if (i == startingPoint)
            {
                result = startingPoint.ToString();
                break;
            }

            if (currentGallons < 0)
                break;
        }

        return result;
    }

    static void Main()
    {
        Console.WriteLine(ArrayChallenge2(new string[] { "4", "1:1", "2:2", "1:2", "0:1" }));
        Console.WriteLine(ArrayChallenge2(new string[] { "4", "3:1", "2:2", "1:2", "0:1" }));
        Console.WriteLine(ArrayChallenge2(new string[] { "5", "3:3", "1:2", "2:2", "3:2", "4:3" }));
        Console.WriteLine(ArrayChallenge2(new string[] { "5", "0:1", "2:1", "3:2", "4:6", "4:3" }));
        Console.WriteLine(ArrayChallenge2(new string[] { "6", "3:2", "2:2", "10:6", "0:4", "1:1", "30:10" }));
    }
}