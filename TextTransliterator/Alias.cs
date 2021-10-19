using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTransliterator
{
    /// <summary>
    /// Класс, описывающий возможные сокращения для указанных данных.
    /// </summary>
    public class Alias
    {
        /// <summary>
        /// Массив со значениями сокращений, за которые отвечает этот экземпляр.
        /// </summary>
        public readonly string[] Aliases;
        /// <summary>
        /// Создаёт новый список допустимых сокращений для указанного типа.
        /// </summary>
        /// <param name="acceptableAliases">Те сокразения, на которые надо реагировать. </param>
        public Alias(params string[] acceptableAliases)
        {
            Aliases = acceptableAliases;
        }
        /// <summary>
        /// Проверяет, является ли строка одним из указанных сокращений.
        /// </summary>
        public bool Check(string test, bool ignoreCase = true)
        {
            if (ignoreCase) return Aliases.Any(x => x.ToLower() == test.ToLower());
            else return Aliases.Any(x => x == test);
        }
        /// <inheritdoc/>
        public override string ToString()
        {
            string ret = "";
            Aliases.ToList().ForEach(x => ret += x + " , ");
            return ret[..^3];
        }
    }
}
