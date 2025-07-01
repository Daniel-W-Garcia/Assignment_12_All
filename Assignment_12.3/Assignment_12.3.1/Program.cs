using System.Text;
/*

1. Listen (and ask questions),
2. Generate Examples (that cover all pertinent cases and corner cases),
3. Brute Force (pseudo),
4. Optimize,
5. Walk Through,
6. Test,
7. Implement (code),
8. Test Again

You are given a string s consisting of lowercase English letters. A duplicate removal consists of choosing two adjacent and equal letters and removing them.

We repeatedly make duplicate removals on s until we no longer can.

empty stringbuilder with right pointer
foreach(char in string)
    if (string is empty or sb.length-1 doesn't match current char)
        sb.add(char)
    else
        trim last char and compare again

*/

static string RemoveDuplicates(string inputString)
{
    StringBuilder stringBuilder = new StringBuilder();
        
    foreach (char c in inputString)
    {
        if (stringBuilder.Length == 0 || stringBuilder[stringBuilder.Length - 1] != c)
        {
            stringBuilder.Append(c);
        }
        else
        {
            stringBuilder.Length--;
        }
    }
        
    return stringBuilder.ToString();
}

string testString1 = "abbaca";
string testString2 = "azxxzy";
string testString3 = "daabbccg";


Console.WriteLine($"""
                   The string '{testString1}' after removing duplicates is:
                   '{RemoveDuplicates(testString1)}'
                   """);
Console.WriteLine($"""
                   The string '{testString2}' after removing duplicates is:
                   '{RemoveDuplicates(testString2)}'
                   """);
Console.WriteLine($"""
                   The string '{testString3}' after removing duplicates is:
                   '{RemoveDuplicates(testString3)}'
                   """);

