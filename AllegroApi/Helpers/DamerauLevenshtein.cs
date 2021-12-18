using System;

namespace AllegroApi.Helpers
{
    public static class DamerauLevenshtein
    {
        public static int DamerauLevenshteinDistanceTo(this string @string, string targetString)
        {
            return DamerauLevenshteinDistance(@string, targetString);
        }

        public static int DamerauLevenshteinDistance(string string1, string string2)
        {
            if (string.IsNullOrEmpty(string1))
            {
                if (!string.IsNullOrEmpty(string2))
                    return string2.Length;

                return 0;
            }

            if (string.IsNullOrEmpty(string2))
            {
                if (!string.IsNullOrEmpty(string1))
                    return string1.Length;

                return 0;
            }

            var length1 = string1.Length;
            var length2 = string2.Length;

            var d = new int[length1 + 1, length2 + 1];

            int cost, del, ins, sub;

            for (var i = 0; i <= d.GetUpperBound(0); i++)
                d[i, 0] = i;

            for (var i = 0; i <= d.GetUpperBound(1); i++)
                d[0, i] = i;

            for (var i = 1; i <= d.GetUpperBound(0); i++)
            {
                for (var j = 1; j <= d.GetUpperBound(1); j++)
                {
                    if (string1[i - 1] == string2[j - 1])
                        cost = 0;
                    else
                        cost = 1;

                    del = d[i - 1, j] + 1;
                    ins = d[i, j - 1] + 1;
                    sub = d[i - 1, j - 1] + cost;

                    d[i, j] = Math.Min(del, Math.Min(ins, sub));

                    if (i > 1 && j > 1 && string1[i - 1] == string2[j - 2] && string1[i - 2] == string2[j - 1])
                        d[i, j] = Math.Min(d[i, j], d[i - 2, j - 2] + cost);
                }
            }

            return d[d.GetUpperBound(0), d.GetUpperBound(1)];
        }
    }
}