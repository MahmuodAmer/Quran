namespace Quran.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        public List<List<int>> FindRepeatedPatterns(List<int> numbers)
        {
            List<List<int>> patterns = new List<List<int>>();
            int length = numbers.Count;

            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    int patternLength = j - i;
                    if (j + patternLength <= length)
                    {
                        List<int> pattern = numbers.GetRange(j, patternLength);
                        if (Enumerable.SequenceEqual(numbers.GetRange(i, patternLength), pattern))
                        {
                            patterns.Add(pattern);
                        }
                    }
                }
            }

            return patterns;
        }

        [Test]
        public void Test1()
        {
            List<int> numbers = new List<int> { 194, 381, 514, 1352, 407, 828, 316, 383, 185, 458, 1116, 150, 850, 1244, 229, 69, 622, 112, 348, 1083, 8, 670, 190, 292, 410, 120, 259, 700, 8, 345, 282, 120, 132, 85, 595, 19, 343, 306, 825, 302, 132, 8, 45, 31, 35, 68, 99, 129, 156, 45, 17, 997, 395, 95, 178, 129, 81, 325, 286, 708, 260, 749, 256, 343, 226, 10, 59, 68, 102, 59, 37, 94, 101, 276, 176, 284, 482, 174, 26, 213, 171, 359, 17, 19, 17, 481, 17, 92, 234, 258, 70, 22, 25, 202, 486, 99, 48, 380, 577, 97, 18, 45, 363, 494, 893, 597, 1668, 108 };
            List<List<int>> patterns = FindRepeatedPatterns(numbers);

            foreach (List<int> pattern in patterns)
            {
               Assert.AreEqual("Found pattern: " + string.Join(", ", pattern),"");
            }
        }
    }
}