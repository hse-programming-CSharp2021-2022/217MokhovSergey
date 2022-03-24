using System.Linq;

namespace Task_1
{
    class Program
    {
        static public string[] keywords =
        {
            "abstract", "as", "base", "bool", "break",
            "byte", "case", "catch", "char", "checked",
            "class", "const", "continue", "decimal", "default",
            "delegate", "do", "double", "else", "enum",
            "event", "explicit", "extern", "false", "finally",
            "fixed", "float", "for", "foreach", "goto",
            "if", "implicit", "in", "int", "interface",
            "internal", "is", "lock", "long", "namespace",
            "new", "null", "object", "operator", "out",
            "override", "params", "private", "protected", "public",
            "readonly", "ref", "return", "sbyte", "sealed",
            "short", "sizeof", "stackalloc", "static", "string",
            "struct", "switch", "this", "throw", "true",
            "try", "typeof", "uint", "ulong", "unchecked",
            "unsafe", "ushort", "using", "virtual", "void",
            "volatile", "while"
        };

        static void Main(string[] args)
        {
            var z1 = from g in keywords
                select g;
            var z1_2 = keywords.Select(g => g);
            var z2 = from g in keywords
                where g.Length == 3
                select g;
            var z2_2 = keywords.Where(g => g.Length == 3);
            var z3 = from g in keywords
                where g.Length == 3 && g.Contains('o')
                select g;
            var z3_2 = keywords.Where(g => g.Length == 3 && g.Contains('o'));
            var z4 = from g in keywords
                where g.Length == 3
                where g.Contains('o')
                select g;
            var z5 = from g in keywords
                from h in keywords
                where g.Length == 3 && g.Contains('o')
                where h.Length == 3 && h.Contains('o')
                select (g, h);
            var z5_2 = keywords.Where(g => g.Length == 3 && g.Contains('o')).Select(g => g[0]);
            //foreach ((string, string) words in z5)
            //    Console.WriteLine($"{words.Item1} + {words.Item2}");
            var z6 = from g in keywords
                orderby g.Length descending, g
                select g;
            var z6_2 = keywords.OrderBy(g => g.Length).ThenBy(g => g.Length);
            var z7 = from g in keywords
                group g by g.Length
                into newG
                select newG;
            //foreach (var word in z7)
            //{
            //    Console.WriteLine(word.Key);
            //    foreach (var w in word)
            //    {
            //        Console.WriteLine(w);
            //    }
            //}
            int[] mas = {1, 2, 3, 4, 5};
            var z8 = from g in mas
                where g % 2 == 0
                select g;
            //foreach (var el in z8)
            //    Console.WriteLine(el);
            var z9 = (from g in mas
                where g % 2 == 0
                select g).Sum();
            //Console.WriteLine("sum "+ z9);
            mas[0] = 10;
            //foreach (var el in z8)
            //    Console.WriteLine(el); <- выведет 10, 2, 4
            //Console.WriteLine("sum " + z9);


        }


    }
}






