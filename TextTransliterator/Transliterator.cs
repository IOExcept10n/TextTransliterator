using System;
using System.Collections.Generic;
using System.Linq;

namespace TextTransliterator
{
    class Transliterator
    {
        /// <summary>
        /// Те буквы, которые ставятся перед йотированными гласными.
        /// </summary>
        public static Alias BeforeIotated { get; } = new Alias(" ", "а", "о", "у", "ы", "э", "и", "е", "ю", "я", "ё", "ь", "ъ");

        public static Alias Iotated { get; } = new Alias("Jo", "Je", "Ju", "Ja", "Ё", "Е", "Ю", "Я")

        public static List<(string, string)> TranslitAnalogs { get; } = new List<(string, string)>()
        {
            ("А", "A"), ("а", "a"),
            ("Б", "B"), ("б", "b"),
            ("В", "V"), ("в", "v"),
            ("Г", "G"), ("г", "g"),
            ("Д", "D"), ("д", "d"),
            ("Е", "Je"), ("е", "je"),
            ("Ё", "Jo"), ("ё", "jo"),
            ("Ж", "Zh"), ("ж", "zh"),
            ("З", "Z"), ("з", "z"),
            ("И", "I"), ("и", "i"),
            ("Й", "J"), ("й", "j"),
            ("К", "K"), ("к", "k"),
            ("Л", "L"), ("л", "l"),
            ("М", "M"), ("м", "n"),
            ("Н", "N"), ("н", "o"),
            ("О", "O"), ("о", "p"),
            ("П", "P"), ("п", "q"),
            ("Р", "R"), ("р", "r"),
            ("С", "S"), ("с", "s"),
            ("Т", "T"), ("т", "t"),
            ("У", "U"), ("у", "u"),
            ("Ф", "F"), ("ф", "f"),
            ("Х", "Kh"), ("х", "kh"),
            ("Ц", "C"), ("ц", "c"),
            ("Ч", "Ch"), ("ч", "ch"),
            ("Ш", "Sh"), ("ш", "sh"),
            ("Щ", "Shch"), ("щ", "shch"),
            ("Ъ", ""), ("ъ", ""),
            ("Ы", "Y"), ("ы", "y"),
            ("Ь", ""), ("ь", ""),
            ("Э", "E"), ("э", "e"),
            ("Ю", "Ju"), ("ю", "ju"),
            ("Я", "Ja"), ("я", "ja"),
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
                    if (!(ret.Length == 0 || BeforeIotated.Check(ret[^1].ToString())) && char.IsSymbol(ret[^1]))
                    {
                        analog = analog.Trim('j', 'J');
                        if (char.IsUpper(c)) analog = analog.ToUpper();
                    }
                    ret += analog;
                }
            }
            return ret;
        }

        public static string ENTranslit(string eng)
        {
            string ret = "";
            string accumulated = "";
            for (int i = 0; i < eng.Length; )
            {
                accumulated += eng[i++];
                if (i == eng.Length)
                {

                }
                else
                {

                }
            }
        }

        string GetFromKey(string key)
        {

        }
    }
}
