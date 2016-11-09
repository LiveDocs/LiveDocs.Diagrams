namespace LiveDocs.Diagrams.Graph.Executable.Services
{
    // Adapted from http://stackoverflow.com/a/34009268/248164
    internal class SetService
    {
        public T[][] GetCombinations<T>(T[][] sets)
        {
            var counters = new int[sets.Length];
            var count = 1;
            var count2 = 0;

            for (var i = 0; i < sets.Length; i++)
            {
                count *= sets[i].Length;
            }

            var combinations = new T[count][];
            do
            {
                combinations[count2++] = GetCombinationString(counters, sets);
            }
            while (Increment(counters, sets));

            return combinations;
        }

        private static T[] GetCombinationString<T>(int[] counters, T[][] sets)
        {
            var o = new T[counters.Length];

            for (var i = 0; i < counters.Length; i++)
            {
                o[i] = sets[i][counters[i]];
            }

            return o;
        }

        private static bool Increment<T>(int[] counters, T[][] sets)
        {
            for (var i = counters.Length - 1; i >= 0; i--)
            {
                if (counters[i] < sets[i].Length - 1)
                {
                    counters[i]++;
                    return true;
                }

                counters[i] = 0;
            }

            return false;
        }
    }
}