/*

1. Listen (and ask questions),
2. Generate Examples (that cover all pertinent cases and corner cases),
3. Brute Force (pseudo),
4. Optimize,
5. Walk Through,
6. Test,
7. Implement (code),
8. Test Again

Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters from magazine and false otherwise.
Each letter in magazine can only be used once in ransomNote.

how am I getting the strings? do I need any user input? 

ransomNote as rn
magazine as m

basically checking if m contains rn as unique values.

rn = foot, m = football ----> true
rn = touche, m = touch ----> false
rn = ball, m = balance ---> false
rn = gift, m = fight ---> true

many ways to solve this. first thought is to is create a dictionary of m values then check if rn has matching values inside dictionary
need to account for double letters in an rn. sb might be the best way. can make sub string everytime we match a letter in rn.
is this an instance we can use dp or recursion?

Dictionary<char, int> magazineChars = new Dictionary<char, int>();

build dict of magazine chars
foreach(char in mag)
{
    if(magazineChars.ContainsKey(char)
    {
        magazineChars[char]++
    }
    else
    {
        magazineChars.Ad(char, 1)
    }
}

check if rn can fit inside magazine

foreach(char in rn)
    if (magazineChars.ContainsKey(character) && magazineChars[character] > 0) 
        {
            magazineChars[character]--;                                                                                                                                                                                                                       │
    } else 
    {                                                                                                                                                                                                                                              │
       return false;
    }
    return true
    
this does not consider sentence case. so need that specified in data in.

*/

static bool canConstruct(string ransomNote, string magazine) 
{
    ransomNote = ransomNote.ToLower();
    magazine = magazine.ToLower();
    Dictionary<char, int> magazineChars = new Dictionary<char, int>();
    foreach(var chr in magazine)
    {
        if(magazineChars.ContainsKey(chr))
        {
            magazineChars[chr]++;
        }
        else
        {
            magazineChars.Add(chr, 1);
        }
    }
    foreach(var letter in ransomNote)
    {
        if(magazineChars.ContainsKey(letter) && magazineChars[letter] > 0)
        {
            magazineChars[letter]--;
        }
        else
        {
            return false;
        }
    }
    return true;
}

string myRansom = "Give me your money";
string myMag = "I dont want to give you money. It's mine, not yours";

Console.WriteLine(canConstruct(myRansom, myMag)?"The note can be read":"The note cannot be read with the available magazine");


        
