// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Text.RegularExpressions;

Console.WriteLine("Program 1");
Console.WriteLine("Data Type Information:\n");
            
Console.WriteLine($"sbyte: Size = {sizeof(sbyte)} bytes, Min = {sbyte.MinValue}, Max = {sbyte.MaxValue}");
Console.WriteLine($"byte: Size = {sizeof(byte)} bytes, Min = {byte.MinValue}, Max = {byte.MaxValue}");
Console.WriteLine($"short: Size = {sizeof(short)} bytes, Min = {short.MinValue}, Max = {short.MaxValue}");
Console.WriteLine($"ushort: Size = {sizeof(ushort)} bytes, Min = {ushort.MinValue}, Max = {ushort.MaxValue}");
Console.WriteLine($"int: Size = {sizeof(int)} bytes, Min = {int.MinValue}, Max = {int.MaxValue}");
Console.WriteLine($"uint: Size = {sizeof(uint)} bytes, Min = {uint.MinValue}, Max = {uint.MaxValue}");
Console.WriteLine($"long: Size = {sizeof(long)} bytes, Min = {long.MinValue}, Max = {long.MaxValue}");
Console.WriteLine($"ulong: Size = {sizeof(ulong)} bytes, Min = {ulong.MinValue}, Max = {ulong.MaxValue}");
Console.WriteLine($"float: Size = {sizeof(float)} bytes, Min = {float.MinValue}, Max = {float.MaxValue}");
Console.WriteLine($"double: Size = {sizeof(double)} bytes, Min = {double.MinValue}, Max = {double.MaxValue}");
Console.WriteLine($"decimal: Size = {sizeof(decimal)} bytes, Min = {decimal.MinValue}, Max = {decimal.MaxValue}");

Console.WriteLine("===============================================================");
Console.WriteLine("Program 2");
Console.WriteLine("Enter the Centuries");
if (int.TryParse(Console.ReadLine(), out int centuries))
{
    checked
    {
        long years = centuries * 100L;
        long days = years * 365L;
        long hours = days * 24L;
        long minutes=hours * 60L;
        long seconds=minutes * 60L;
        long milliseconds=seconds * 1000L;
        decimal microseconds=milliseconds * 1000M;
        decimal nanoseconds=microseconds * 1000M;
        Console.WriteLine($"{centuries} centuries = {years} years ={days} days = {hours} hours={minutes}minutes = {seconds} seconds ={milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");

    }
}
else
{
    Console.WriteLine("Invalid input. Try again.");
}

Console.WriteLine("===============================================================");
Console.WriteLine("Program 3 - 1Loops FizzBuzz");
int countsize = 100;
for (int i = 1; i <= countsize; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine($"Number{i} FizzBuzz");
    }
    else
    {
        if (i % 3 == 0)
        {
            Console.WriteLine($"Number{i} Buzz");
        }
        else if(i % 5 == 0)
        {
            Console.WriteLine($"Number{i} Fizz");
        }
    }
}

Console.WriteLine("===============================================================");
Console.WriteLine("Program 4 - 1Loops Random number guess");
int correctNumber = new Random().Next(3) + 1;
string s=Console.ReadLine();
if (int.TryParse(s, out int number))
{
    if (number >= 1 && number <= 3)
    {
        if (number == correctNumber)
        {
            Console.WriteLine($"Number{correctNumber} is correct");
        }
        else if (number < correctNumber)
        {
            Console.WriteLine($"Number{correctNumber} is low");
        }
        else if (number > correctNumber)
        {
            Console.WriteLine($"Number{correctNumber} is high");
        }
    }
    else
    {
        Console.WriteLine("outside range of numbers");
    }
}
else
{
    Console.WriteLine("Invalid input. Please enter number");
}

Console.WriteLine("===============================================================");
Console.WriteLine("Program5- 2.Triangle stars Program");
int input=int.Parse(Console.ReadLine());
for (int i = 1; i <=input; i++)
{
    for (int j = 1; j <= input-i; j++)
    {
        Console.Write(" ");
    }

    for (int k = 1; k <= (2 * i - 1); k++)
    {
        Console.Write("*");
    }

    Console.WriteLine();
}

Console.WriteLine("===============================================================");
Console.WriteLine("Program6- 3.Random number guess");
int correctNumber1 = new Random().Next(3) + 1;
string s1=Console.ReadLine();
if (int.TryParse(s, out int number1))
{
    if (number1 >= 1 && number1 <= 3)
    {
        if (number1 == correctNumber1)
        {
            Console.WriteLine($"Number{correctNumber1} is correct");
        }
        else if (number1 < correctNumber1)
        {
            Console.WriteLine($"Number{correctNumber1} is low");
        }
        else if (number1 > correctNumber1)
        {
            Console.WriteLine($"Number{correctNumber1} is high");
        }
    }
    else
    {
        Console.WriteLine("outside range of numbers");
    }
}
else
{
    Console.WriteLine("Invalid input. Please enter number");
}

Console.WriteLine("====================================");
Console.WriteLine("Program7- 4.Anniversary days Program");
int birthYear=int.Parse(Console.ReadLine());
int birthMonth=int.Parse(Console.ReadLine());
int birthDay=int.Parse(Console.ReadLine());
DateTime birthDate=new DateTime(birthYear,birthMonth,birthDay);
DateTime today=DateTime.Today;
TimeSpan age=today-birthDate;
long daysOld=age.Days;
Console.WriteLine($"Age: {age.Days} days");
long daysToNextAnniversary=10000-(daysOld%10000);
DateTime nextAnniversary=today.AddDays(daysToNextAnniversary);
Console.WriteLine($"Anniversary: {nextAnniversary.ToShortDateString()}.");

Console.WriteLine("==================================");
Console.WriteLine("Program8- 5.Greeting for the time of day");
int currentHour = DateTime.Now.Hour;

// Greeting based on time of day using only 'if' statements
if (currentHour >= 5 && currentHour < 12)
{
    Console.WriteLine("Good Morning");
}

if (currentHour >= 12 && currentHour < 17)
{
    Console.WriteLine("Good Afternoon");
}

if (currentHour >= 17 && currentHour < 21)
{
    Console.WriteLine("Good Evening");
}

if (currentHour >= 21 || currentHour < 5)
{
    Console.WriteLine("Good Night");
}



Console.WriteLine("==================================");
Console.WriteLine("Program9- 6four different increments");

for (int increment = 1; increment <= 4; increment++)
{
    Console.WriteLine($"Counting by {increment}s:");
    for (int i = 0; i <= 24; i += increment)
    {
        Console.Write(i + " ");
    }
    Console.WriteLine("\n");
}


Console.WriteLine("==============================");
Console.WriteLine("Program11- 1Create copy of array");
int[] array = {10,20,30,40,50,60,70,80,90};
int[] copy=new int[array.Length];
for (int i = 0; i < array.Length; i++)
{
    copy[i] = array[i];
}

Console.WriteLine("original Array:\n");
Console.WriteLine(string.Join(", ", array));
Console.WriteLine("copy Array:\n");
Console.WriteLine(string.Join(", ", copy));
int[] clonedArray = (int[])array.Clone();
Console.WriteLine("original Array:\n");
Console.WriteLine(string.Join(", ", clonedArray));


Console.WriteLine("=====================================");
Console.WriteLine("Program12- 2nd Todo");

List<string> todo = new List<string>();
int n;
do
{
    Console.WriteLine("Enter String include + to add items to list, - to remove item from the list -- to clear the list");
    string userInput = Console.ReadLine();
    if (userInput.ToLower().StartsWith("+"))
    {
        todo.Add(userInput.Substring(1).Trim());
    }
    else if (userInput.ToLower().StartsWith("-")&& !userInput.Equals("--"))
    {
        string itemToRemove = userInput.Substring(1).Trim();  // Remove "-" and trim spaces
        if (todo.Contains(itemToRemove))
        {
            todo.Remove(itemToRemove);
        }
        else
        {
            Console.WriteLine($"Item '{itemToRemove}' not found in the list.");
        }
    }
    else if(userInput.Equals("--"))
    {
        todo.Clear();
        Console.WriteLine("List cleared.");
    }
    Console.WriteLine("Current To-Do List:");
    foreach (var item in todo)
    {
        Console.WriteLine($"- {item}");
    }

    Console.WriteLine("Do you want to continue? press 1 to continue else press anyother");

} while (int.TryParse(Console.ReadLine(), out n) && n == 1);


Console.WriteLine("=====================================");
Console.WriteLine("Program13- 3rd Prime numbers");
Console.WriteLine("Enter starting rangenum and ending num to find the primes in range");
int startNum=int.Parse(Console.ReadLine());
int endNum=int.Parse(Console.ReadLine());
int[] primes=FindPrimes(startNum,endNum);
Console.WriteLine($"Prime between {startNum} and {endNum} :{string.Join(",",primes)}");
static int[] FindPrimes(int startNum, int endNum)
{
    List <int>primes=new List<int>();
    for (int num = Math.Max(2, startNum); num <= endNum; num++)
    {
        if (IsPrime(num))
        {
            primes.Add(num);
        }
    }
    return primes.ToArray();
}

static bool IsPrime(int num)
{
    if (num < 2) return false;
    for (int i = 2; i * i <= num; i++)
    {
        if (num % i == 0) return false;
    }
    return true;
}

Console.WriteLine("==========================================================");
Console.WriteLine("Program14- 4th Rotation of array");
Console.WriteLine("Enter array with spaces");
int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
Console.WriteLine("Enter number of rotations");
int k1=int.Parse(Console.ReadLine());
int n1 = a.Length;
int[] sum=new int[n1];
for (int r = 1; r <= k1; r++)
{
    int[] rotated=new int[n1];
    for (int i = 0; i < n1; i++)
    {
        rotated[(i+1)%n1] = a[i];
    }

    for (int i = 0; i < n1; i++)
    {
        sum[i] += rotated[i];    
    }
    a=rotated;
}

Console.WriteLine($"Final array after rotations {string.Join(" ",sum)}");


Console.WriteLine("=====================================================================");
Console.WriteLine("Program15- 5th sequence");
Console.WriteLine("Input array with spaces");
int[] array1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
int L = 0, R = 1;
int Count = 1;
List<int> result = new List<int>();
int MaxLength=int.MinValue;
int maxStartIndex = 0;
while (R < array1.Length)
{
    if (array1[L] == array1[R])
    {   
     
        Count++;
        R++;
    }
    else
    {
        if (Count > MaxLength)
        {
            MaxLength = Count;
            maxStartIndex = L;
        }
        L = R;
        R++;
        Count = 1;
    }
}

if (Count > MaxLength)
{
    MaxLength = Count;
    maxStartIndex = L;
}
int[] result1 = new int[MaxLength];
for (int i = 0; i < MaxLength; i++)
{
    result1[i] = array1[maxStartIndex+i];
    Console.Write(result1[i]+" ");
}

Console.WriteLine();
Console.WriteLine($"Max length is {MaxLength}");

Console.WriteLine("======================================");
Console.WriteLine("Program16- 7th most frequent number");
Console.WriteLine("Input array with spaces");
int[] array2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
Dictionary<int, int> dict = new Dictionary<int, int>();
foreach (int num in array2)
{
    if (dict.ContainsKey(num))
    {
        dict[num]++;
    }
    else
    {
        dict[num] = 1;
    }
}

int maxFreq = 0;
int mostFreq = array2[0];
foreach (var entry in dict)
{
    if (entry.Value > maxFreq)
    {
        maxFreq = entry.Value;
        mostFreq = entry.Key;
    }
}

Console.WriteLine($"Most Frequent number is {mostFreq}");


Console.WriteLine("=============================================== ");
Console.WriteLine("Program17- 1 Reverse String");
Console.WriteLine("Enter the string to reverse");
string sc=Console.ReadLine();
StringBuilder reversed=new StringBuilder();
for (int i = sc.Length-1; i>=0; i--)
{
    reversed.Append(sc[i]);
}
Console.WriteLine($"Reverse string is {reversed.ToString()}");

Console.WriteLine("=============================================== ");
Console.WriteLine("Program17- 2 Reverse String");
string strinput=Console.ReadLine();
string reversedstr=ReverseWords(strinput);
Console.WriteLine($"Reverse string is {reversedstr}");
static string ReverseWords(string sentence)
{
    string pattern = @"([A-Za-z0-9\+\-\*\/\^\#\$\%\&\(\)\[\]\{\}]+|[.,:;=\(\)'\\""/!?&\[\] ]+)";
    var matches = Regex.Matches(sentence, pattern);
    List<string> words = new List<string>();
    foreach (Match match in matches)
    {
        words.Add(match.Value);
    }
    List<string> reversedWords = new List<string>();
    foreach (var word in words)
    {
        if (IsWord(word))
        {
            reversedWords.Insert(0, word);
        }
        else
        {
            reversedWords.Add(word);
        }
    }
    
    StringBuilder result1=new StringBuilder();
    foreach (var part in reversedWords)
    {
        result1.Append(part);
    }
    return result1.ToString();
    
}

static bool IsWord(string part)
{
    return Regex.IsMatch(part, @"[A-Za-z0-9\+\-\*\/\^\#\$\%\&\(\)\[\]\{\}]+");
}



Console.WriteLine("========================================================");
Console.WriteLine("Program18- 3. Palindromes collection");
string text=Console.ReadLine();
string palindromes= ExtractPalindromes(text);
Console.WriteLine($"Palindromes: {palindromes}");
 static string ExtractPalindromes(string text)
{ 
    HashSet<string> palindromes = new HashSet<string>();
    string normalizedText = Regex.Replace(text, @"[^a-zA-Z0-9]", "").ToLower();

    for (int i = 0; i < normalizedText.Length; i++)
    {
        for (int j = i + 2; j <= normalizedText.Length; j++) 
        {
            string substring = normalizedText.Substring(i, j - i);
            if (IsPalindrome(substring))
            {
                palindromes.Add(substring);
            }
        }
    }

   
    List<string> sortedPalindromes = palindromes.ToList();
    sortedPalindromes.Sort(); 

    return string.Join(", ", sortedPalindromes);
}

 static bool IsPalindrome(string text)
{
    
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


 Console.WriteLine("====================================================");
 Console.WriteLine("Program19- 4. Parses an url");
Console.WriteLine("Enter the URL");
string url = Console.ReadLine();
var parsedUrl = ParseUrl(url);
Console.WriteLine($"Protocol: {parsedUrl.Protocol}");
Console.WriteLine($"Server: {parsedUrl.Server}");
Console.WriteLine($"Resource: {parsedUrl.Resource}");
static (string Protocol, string Server, string Resource) ParseUrl(string url)
{
    string protocol = "";
    string server = "";
    string resource = "";

 
    string pattern = @"^(?:(\w+)://)?([^/]+)(?:/(.*))?$";
    var match = Regex.Match(url, pattern);

    if (match.Success)
    {
      
        protocol = match.Groups[1].Value;
        server = match.Groups[2].Value;
        resource = match.Groups[3].Value;
    }

    return (protocol, server, resource);
}














