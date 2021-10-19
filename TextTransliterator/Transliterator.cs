using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextTransliterator
{
    class Transliterator
    {
        /// <summary>
        /// Те буквы, которые ставятся перед йотированными гласными.
        /// </summary>
        public static Alias BeforeIotated { get; } = new Alias(" ", "а", "о", "у", "ы", "э", "и", "е", "ю", "я", "ё", "ь", "ъ");
        /// <summary>
        /// Непосредственно те буквы и буквосочетания, которые являются йотированными.
        /// </summary>
        public static Alias Iotated { get; } = new Alias("Jo", "Je", "Ju", "Ja", "Ё", "Е", "Ю", "Я");
        /// <summary>
        /// Список соответствующих друг другу букв при транслитерации (отсортирован по длине сочетания).
        /// </summary>
        public static List<(string, string)> TranslitAnalogs { get; } = new List<(string, string)>()
        {
            ("Щ", "Shch"), ("щ", "shch"),
            ("Е", "Je"), ("е", "je"),
            ("Ё", "Jo"), ("ё", "jo"),
            ("Ж", "Zh"), ("ж", "zh"),
            ("Ч", "Ch"), ("ч", "ch"),
            ("Ш", "Sh"), ("ш", "sh"),
            ("Х", "Kh"), ("х", "kh"),
            ("Ю", "Ju"), ("ю", "ju"),
            ("Я", "Ja"), ("я", "ja"),
            ("А", "A"), ("а", "a"),
            ("Б", "B"), ("б", "b"),
            ("В", "V"), ("в", "v"),
            ("Г", "G"), ("г", "g"),
            ("Д", "D"), ("д", "d"),
            ("З", "Z"), ("з", "z"),
            ("И", "I"), ("и", "i"),
            ("Й", "J"), ("й", "j"),
            ("К", "K"), ("к", "k"),
            ("Л", "L"), ("л", "l"),
            ("М", "M"), ("м", "m"),
            ("Н", "N"), ("н", "n"),
            ("О", "O"), ("о", "o"),
            ("П", "P"), ("п", "p"),
            ("Р", "R"), ("р", "r"),
            ("С", "S"), ("с", "s"),
            ("Т", "T"), ("т", "t"),
            ("У", "U"), ("у", "u"),
            ("Ф", "F"), ("ф", "f"),
            ("Ц", "C"), ("ц", "c"),
            ("Э", "E"), ("э", "e"),
            ("Ы", "Y"), ("ы", "y"),
            ("Ь", ""), ("ь", ""),
            ("Ъ", ""), ("ъ", ""),
        };
        /// <summary>
        /// Список 
        /// </summary>
        public static List<(string, string)> LayoutAnalogs = new List<(string, string)>()
        {
            ("q", "й"), ("Q", "Й"),
            ("w", "ц"), ("W", "Ц"),
            ("e", "у"), ("E", "У"),
            ("r", "к"), ("R", "К"),
            ("t", "е"), ("T", "Е"),
            ("y", "н"), ("Y", "Н"),
            ("u", "г"), ("U", "Г"),
            ("i", "ш"), ("I", "Ш"),
            ("o", "щ"), ("O", "Щ"),
            ("p", "з"), ("P", "З"),
            ("[", "х"), ("{", "Х"),
            ("]", "ъ"), ("}", "Ъ"),
            ("a", "ф"), ("A", "Ф"),
            ("s", "ы"), ("S", "Ы"),
            ("d", "в"), ("D", "В"),
            ("f", "а"), ("F", "А"),
            ("g", "п"), ("G", "П"),
            ("h", "р"), ("H", "Р"),
            ("j", "о"), ("J", "О"),
            ("k", "л"), ("K", "Л"),
            ("l", "д"), ("L", "Д"),
            (";", "ж"), (":", "Ж"),
            ("'", "э"), ("\"", "Э"),
            ("z", "я"), ("Z", "Я"),
            ("x", "ч"), ("X", "Ч"),
            ("c", "с"), ("C", "С"),
            ("v", "м"), ("V", "М"),
            ("b", "и"), ("B", "И"),
            ("n", "т"), ("N", "Т"),
            ("m", "ь"), ("M", "Ь"),
            (",", "б"), ("<", "Б"),
            (".", "ю"), (">", "Ю"),
            ("/", "."), ("?", ","),
            ("`", "ё"), ("~", "Ё"),
            //("@", "\""),
            //("#", "№"),
            //("$", ";"),
            //("^", ":"),
            //("&", "?"),
        };
        /// <summary>
        /// Производит перевод текста с русского на английский-транслит.
        /// </summary>
        /// <param name="ru">Текст на русском языке</param>
        /// <returns>Текст в транслите, написанный латиницей.</returns>
        public static string RUTranslit(string ru)
        {
            string ret = "";
            for (int i = 0; i < ru.Length; i++)
            {
                char c = ru[i];
                var analog = TranslitAnalogs.FirstOrDefault(x => x.Item1 == c.ToString()).Item2;
                if (analog == null) ret += c;
                else
                {
                    if (Iotated.Check(c.ToString()) && (i > 1 && !BeforeIotated.Check(ru[i-1].ToString()) && char.IsLetter(ru[i-1])))
                    {
                        analog = analog.Trim('j', 'J');
                        if (char.IsUpper(c)) analog = analog.ToUpper();
                    }
                    ret += analog;
                }
            }
            return ret;
        }
        /// <summary>
        /// Переводит текст из английского транслита на русский.
        /// </summary>
        /// <param name="eng">Текст, написанный транслитом.</param>
        /// <returns>Текст на русском (возможно, не совсем будет соответствовать).</returns>
        public static string ENTranslit(string eng)
        {
            string ret = eng;
            foreach (var c in TranslitAnalogs)
            {
                if (c.Item2 != "") ret = ret.Replace(c.Item2, c.Item1);
            }
            ret = Regex.Replace(ret, @"[^аоуыэяёюиеъь ]э", x => x.Value.Replace('э', 'е'));
            ret = Regex.Replace(ret, @"[^АОУЫЭЯЁЮИЕЪЬ ]Э", x => x.Value.Replace('Э', 'Е'));
            return ret;
        }
        /// <summary>
        /// Переключает раскладку написанного текста с английской на русскую.
        /// </summary>
        public static string ReplaceLayoutToRU(string eng)
        {
            string ret = eng;
            foreach (var c in LayoutAnalogs)
            {
                ret = ret.Replace(c.Item1, c.Item2);
            }
            return ret;
        }
        /// <summary>
        /// Переключает раскладку написанного текста с русской на английскую.
        /// </summary>
        public static string ReplaceLayoutToEN(string ru)
        {
            string ret = "";
            foreach (char c in ru)
            {
                ret += LayoutAnalogs.FirstOrDefault(x => x.Item2 == c.ToString()).Item1 ?? c.ToString();
            }
            return ret;
        }
    }
}
