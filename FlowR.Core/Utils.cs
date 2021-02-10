using System.Collections.Generic;
using System.Linq;

namespace FlowR.Core
{
    /// <summary>
    ///     Static utility methods
    /// </summary>
    public static class Utils
    {

        /// <summary>
        ///     helper class to manipulate CSS
        /// </summary>
        public static class Css
        {
            /// <summary>
            ///     Return List from a given full string css
            /// </summary>
            /// <param name="css"></param>
            /// <returns></returns>
            public static List<string> GetListFromString(string css)
            {
                return css.Trim().Split(" ").ToList().Select(x => x.Trim()).Distinct().ToList();
            }

            /// <summary>
            ///     Return a merged string of distinct css classes
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            public static string MergeCss(string a, string b)
            {
                var main = GetListFromString(a);
                main.AddRange(GetListFromString(b));

                return GetStringFromList(main);
            }

            /// <summary>
            ///     Return a first css string purged from second css string
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            public static string RemoveCss(string a, string b)
            {
                var main = GetListFromString(a);
                var toRemove = GetListFromString(b);

                foreach (var str in toRemove)
                {
                    main.RemoveAll(s => s == str);
                }

                return GetStringFromList(main);
            }

            /// <summary>
            ///     Return string separated with speces from a list of css string
            /// </summary>
            /// <param name="cssList"></param>
            /// <returns></returns>
            public static string GetStringFromList(List<string> cssList)
            {
                return string.Join(" ", cssList.Distinct()).Trim();
            }
        }
    }
}