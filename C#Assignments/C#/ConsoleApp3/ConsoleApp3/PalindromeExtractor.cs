namespace ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class PalindromeExtractor
{
    public static string ExtractPalindromes(string text)
    {
        // Use a HashSet to store unique palindromes (handles duplicates).
        HashSet<string> palindromes = new HashSet<string>();

        // Normalize the text (remove non-alphanumeric and lowercase).
        string normalizedText = Regex.Replace(text, @"[^a-zA-Z0-9]", "").ToLower();

        for (int i = 0; i < normalizedText.Length; i++)
        {
            for (int j = i + 2; j <= normalizedText.Length; j++) // Palindromes must be at least 2 chars
            {
                string substring = normalizedText.Substring(i, j - i);
                if (IsPalindrome(substring))
                {
                    palindromes.Add(substring);
                }
            }
        }

        // Sort the palindromes and join them into a comma-separated string.
        List<string> sortedPalindromes = palindromes.ToList();
        sortedPalindromes.Sort(); // In-place sorting

        return string.Join(", ", sortedPalindromes);
    }

    private static bool IsPalindrome(string text)
    {
        // Efficient palindrome check
        int minIndex = 0;
        int maxIndex = text.Length - 1;
        while (minIndex < maxIndex)
        {
            if (text[minIndex] != text[maxIndex])
            {
                return false;
            }

            minIndex++;
            maxIndex--;
        }

        return true;
    }
}