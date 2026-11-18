namespace Part1;

public class Solutions
{
    public Solutions()
    {
        
    }

    public static bool TryReplaceFirstEntry<T>(List<T> l1, List<T> l2, List<T> l3)
    {
        // Если l2 пустой или больше главного списка
        if (l2.Count == 0 || l2.Count > l1.Count)
        {
            return false;
        }

        int startIndex = FindFirstEntry(l1, l2);
        if (startIndex == -1)
        {
            return false;
        }
        
        l1.RemoveRange(startIndex, l2.Count);
        l1.InsertRange(startIndex, l3);

        return true;
    }

    private static int FindFirstEntry<T>(List<T> l1, List<T> l2)
    {
        int lastStart = l1.Count - l2.Count;

        for (int i = 0; i <= lastStart; i++)
        {
            bool matches = true;

            for (int j = 0; j < l2.Count; j++)
            {
                if (!l1[i + j].Equals(l2[j]))
                {
                    matches = false;
                    break;
                }
            }

            if (matches)
            {
                return i;
            }
        }

        return -1;
    }

    public static void SortAsc<T>(LinkedList<T> list)
    {
        if (list.Count < 2)
        {
            return;
        }

        Comparer<T> comparer = Comparer<T>.Default;

        for (int i = 0; i < list.Count - 1; i++)
        {
            bool swapped = false;
            LinkedListNode<T> curr = list.First;

            for (int j = 0; j < list.Count - i - 1; j++)
            {
                if (comparer.Compare(curr.Value, curr.Next.Value) > 0)
                {
                    T temp = curr.Value;
                    curr.Value = curr.Next.Value;
                    curr.Next.Value = temp;
                    swapped = true;
                }

                curr = curr.Next;
            }

            if (!swapped)
            {
                break;
            }
        }
    }

    public static void AnalyzeGameSets(HashSet<string> allGames, List<HashSet<string>> studentGames,
        out HashSet<string> allPlay,
        out HashSet<string> somePlay,
        out HashSet<string> nonePlay)
    {
        allPlay = new HashSet<string>(allGames);
        somePlay = new HashSet<string>();
        nonePlay = new HashSet<string>(allGames);

        foreach (HashSet<string> student in studentGames)
        {
            allPlay.IntersectWith(student);
            somePlay.UnionWith(student);
        }

        somePlay.IntersectWith(allGames);
        nonePlay.ExceptWith(somePlay);
    }
    
    public static char[] FindMissingDeafChars(string filePath)
    {
        HashSet<char> deaf = new HashSet<char> { 'п', 'ф', 'к', 'т', 'ш', 'с', 'х', 'ц', 'ч', 'щ' };
        HashSet<char> textLetters = new HashSet<char>();

        StreamReader reader = new StreamReader(filePath, System.Text.Encoding.UTF8);

        try
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                foreach (char c in line)
                {
                    char lower = char.ToLower(c);
                    if (char.IsLetter(lower))
                    {
                        textLetters.Add(lower);
                    }
                }
            }
        }
        finally
        {
            reader.Close();
        }

        deaf.ExceptWith(textLetters);

        char[] result = new char[deaf.Count];
        deaf.CopyTo(result);
        Array.Sort(result);
        
        return result;
    }
    
    public static void PrintWinners(string filePath)
    {
        string[] input = ReadParticipantsFromFile(filePath);
        if (input.Length == 0)
        {
            return;
        }

        Dictionary<int, List<string>> scoreToNames = GetScoreToNames(input);
        if (scoreToNames.Count == 0)
        {
            return;
        }

        int maxScore = GetMaxScore(scoreToNames);

        foreach (string winner in scoreToNames[maxScore])
        {
            Console.WriteLine(winner);
        }
    }

    private static string[] ReadParticipantsFromFile(string filePath)
    {
        List<string> lines = new List<string>();
        StreamReader reader = new StreamReader(filePath, System.Text.Encoding.UTF8);

        try
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }
        }
        finally
        {
            reader.Close();
        }

        return lines.ToArray();
    }

    private static Dictionary<int, List<string>> GetScoreToNames(string[] input)
    {
        int n = int.Parse(input[0]);
        Dictionary<int, List<string>> scoreToNames = new Dictionary<int, List<string>>();

        for (int i = 1; i <= n; i++)
        {
            string[] parts = input[i].Split(' ');
            string fullName = parts[0] + " " + parts[1];
            int totalScore = int.Parse(parts[2]) + int.Parse(parts[3]) + int.Parse(parts[4]);

            if (!scoreToNames.ContainsKey(totalScore))
            {
                scoreToNames.Add(totalScore, new List<string>());
            }

            scoreToNames[totalScore].Add(fullName);
        }

        return scoreToNames;
    }

    private static int GetMaxScore(Dictionary<int, List<string>> scoreToNames)
    {
        int maxScore = int.MinValue;
        
        foreach (int score in scoreToNames.Keys)
        {
            if (score > maxScore)
            {
                maxScore = score;
            }
        }

        return maxScore;
    }
}