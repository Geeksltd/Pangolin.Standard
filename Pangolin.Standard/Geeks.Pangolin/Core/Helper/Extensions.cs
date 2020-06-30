using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using Geeks.Pangolin.Core.Exception;
using Geeks.Pangolin.Core.Helper.Targets;

namespace Geeks.Pangolin.Core.Helper
{
    public static class Extensions
    {
        #region [Property]

        public static string EscapeForJs(this string str) => str.Replace("'", "\\'").Replace("\r", "\\r").Replace("\n", "\\n");
        private static readonly Regex SchemaPattern = new Regex("^[a-zA-Z]+://", RegexOptions.Compiled);
        private static Regex ClearComments = new Regex(@"(?<whitespace>^(\s+)|([ ]+)\r?$)|(?<quote>""[^""]*"")|(?<comment>\s*//[^\r\n]*)", RegexOptions.Multiline | RegexOptions.Compiled);

        public delegate bool TryParseProvider(string text, Type type, out object result);
        public static List<TryParseProvider> TryParseProviders = new List<TryParseProvider>();
        
        #endregion

        #region [Constructor]

        #endregion

        #region [Public Method]

        public static void RepeatUntilTrue(this Func<bool> func, TimeSpan timeout)
        {
            var wait = (long)timeout.TotalMilliseconds;
            var start = Stopwatch.StartNew();
            while (true)
            {
                if (start.ElapsedMilliseconds > wait)
                    throw new TimeoutException("Timeout after " + timeout);

                if (func.Invoke())
                    break;

                System.Threading.Thread.Sleep(10);
            }
        }

        public static void RepeatUntilTrueNoException(this Func<bool> func, TimeSpan timeout)
        {
            var wait = (long)timeout.TotalMilliseconds;
            var start = Stopwatch.StartNew();
            while (true)
            {
                if (start.ElapsedMilliseconds > wait)
                    break;

                if (func.Invoke())
                    break;

                System.Threading.Thread.Sleep(10);
            }
        }

        public static void RepeatUntilCount(this Func<bool> func, int count)
        {
            var repeat = 1;
            while (true)
            {
                if (repeat > count)
                    throw new CountExceededException("Counter Exceeded " + count);

                if (func.Invoke())
                    break;

                System.Threading.Thread.Sleep(10);
                repeat++;
            }
        }

        public static void RepeatUntilCountNoException(this Func<bool> func, int count)
        {
            var repeat = 1;
            while (true)
            {
                if (repeat > count)
                    break;

                if (func.Invoke())
                    break;

                System.Threading.Thread.Sleep(10);
                repeat++;
            }
        }

        public static string RemoveQuote(this string str) => str.TrimStart("\"").TrimEnd("\"");

        public static string GetAllMessages(this System.Exception exception) => String.Join(Environment.NewLine, exception.FromHierarchy(ex => ex.InnerException).ToList().Select(e => e.Message));

        public static bool IsWrappedIn(this string str, string wrapper)
        {
            if (wrapper.IsEmpty())
                throw new ArgumentException(nameof(wrapper), "Wrapper cannot be empty or null");

            if (wrapper.Length == 1)
                return str.StartsWith(wrapper) && str.EndsWith(wrapper);

            if (wrapper.Length == 2)
                return str.StartsWith(wrapper[0].ToString()) && str.EndsWith(wrapper[1].ToString());

            throw new ArgumentException(nameof(wrapper), "Wrapper length can only be 1 or 2");
        }

        public static string RemoveWrapper(this string str, string wrapper)
        {
            if (wrapper.IsEmpty())
                throw new ArgumentException(nameof(wrapper), "Wrapper cannot be empty or null");

            if (wrapper.Length == 1)
                return str.TrimStart(wrapper).TrimEnd(wrapper);

            if (wrapper.Length == 2)
                return str.TrimStart(wrapper[0]).TrimEnd(wrapper[1]);

            throw new ArgumentException(nameof(wrapper), "Wrapper length can only be 1 or 2");
        }

        public static IEnumerable<T> AllWithMin<T, TKey>(this IEnumerable<T> list, Func<T, TKey> keySelector)
            where T : class
            where TKey : IComparable
        {
            var min = list.Min(keySelector);
            return list.Where(x => min.Equals(keySelector(x)));
        }

        public static IEnumerable<T> AllWithMax<T, TKey>(this IEnumerable<T> list, Func<T, TKey> keySelector)
            where T : class
            where TKey : IComparable
        {
            var max = list.Max(keySelector);
            return list.Where(x => max.Equals(keySelector(x)));
        }

        public static IWebElement GetParent(this IWebElement element) => element.FindElement(By.XPath(".."));

        public static string EscapeForXPath(this string value)
        {
            if (value.Lacks("\""))
                return "\"" + value + "\"";
            if (value.Lacks("'"))
                return "'" + value + "'";

            var sb = new StringBuilder();
            sb.Append("concat(");
            var substrings = value.Split('\"');
            for (var i = 0; i < substrings.Length; i++)
            {
                var needComma = (i > 0);
                if (substrings[i] != "")
                {
                    if (i > 0)
                        sb.Append(", ");
                    sb.Append("\"");
                    sb.Append(substrings[i]);
                    sb.Append("\"");
                    needComma = true;
                }

                if (i < substrings.Length - 1)
                {
                    if (needComma)
                        sb.Append(", ");
                    sb.Append("'\"'");
                }

            }

            sb.Append(")");
            return sb.ToString();
        }

        public static bool Lacks(this string @this, string phrase, bool caseSensitive = false)
        {
            if (@this.IsEmpty()) return phrase.HasValue();

            return !@this.Contains(phrase, caseSensitive);
        }

        public static bool Contains(this string @this, string subString, bool caseSensitive)
        {
            if (@this is null && subString is null)
                return true;

            if (@this is null) return false;

            if (subString.IsEmpty()) return true;

            if (caseSensitive)
                return @this.Contains(subString);
            else
                return @this.ToUpper().Contains(subString?.ToUpper());
        }

        public static bool HasValue(this string text) => !string.IsNullOrEmpty(text);

        public static bool HasSize(this IWebElement element)
        {
            var tag = element.TagName;
            if (tag.IsAnyOf(
                    "i", // bootstrap icons
                    "option", // it's OK for an <option> to be invisible inside a dropdown
                    "div") // also wrapping divs may collapse because of css float
            )
            {
                return true;
            }

            var size = element.Size;
            return size.Width != 0 || size.Height != 0;
        }

        public static bool IsAnyOf(this string @this, params string[] items) => items.Contains(@this);
        
        public static bool IsAnyOf(this string @this, IEnumerable<string> items)
          => IsAnyOf(@this, items.ToArray());

        public static bool IsAnyOf(this char @this, params char[] characters) => characters.Contains(@this);

        public static string EverythingAfter(this string str, char value)
        {
            if (str.IsEmpty())
                return str;

            var index = str.LastIndexOf(value);
            if (index < 0) return str;
            return str.Substring(index + 1);
        }

        public static string TrimInputTypePrefixes(this string str)
        {
            str = str
                .TrimStart("txt")
                .TrimStart("btn")
                .TrimStart("chk")
                .TrimStart("lst");
            return (MasterDetialInputPattern.IsMatch(str)) ? str.EverythingAfter('.') : str;
        }

        public static string TrimStart(this string @this, string textToTrim)
        {
            @this = @this.OrEmpty();

            if (textToTrim.IsEmpty() || @this.IsEmpty()) return @this;

            if (@this.StartsWith(textToTrim)) return @this.Substring(textToTrim.Length).TrimStart(textToTrim);
            else return @this;
        }

        public static SearchType ToSearchType(this Geeks.Pangolin.That that, Casing casing)
        {
            switch (that)
            {
                case Geeks.Pangolin.That.Equals:
                    switch (casing)
                    {
                        case Casing.Ignore:
                            return SearchType.EqualityIgnore;
                        case Casing.Exact:
                            return SearchType.EqualityExact;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(casing), casing, null);
                    }
                case Geeks.Pangolin.That.Wildcard:
                    return SearchType.Wildcard;
                case Geeks.Pangolin.That.Contains:
                    switch (casing)
                    {
                        case Casing.Ignore:
                            return SearchType.ContainsIgnore;
                        case Casing.Exact:
                            return SearchType.ContainsExact;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(casing), casing, null);
                    }
                default:
                    throw new System.Exception("match not found");
            }
        }

        public static That ToThat(this Geeks.Pangolin.What what)
        {
            switch (what)
            {
                case What.Equals:
                    return That.Equals;
                case What.Contains:
                    return That.Contains;
                case What.Wildcard:
                    return That.Wildcard;
                default:
                    throw new ArgumentOutOfRangeException(nameof(what), what, null);
            }
        }

        public static Limiter ToLimiterType(this Geeks.Pangolin.The the)
        {
            switch (the)
            {
                case The.Top:
                    return Limiter.Topmost;
                case The.Bottom:
                    return Limiter.Lowest;
                case The.Right:
                    return Limiter.Rightmost;
                case The.Left:
                    return Limiter.Leftmost;
                default:
                    throw new ArgumentOutOfRangeException(nameof(the), the, null);
            }
        }

        public static string StripComments(this string code) => ClearComments.Replace(code, me => me.Value.StartsWith("\"") ? me.Value : "");

        public static string ApplyTextTransform(this string str, string transform)
        {
            if (str.IsEmpty())
                return str;

            switch (transform)
            {
                case "uppercase": return str.ToUpper();
                case "lowercase": return str.ToLower();
                case "capitalize": return char.ToUpper(str[0]) + str.Substring(1);
                default: return str;
            }
        }

        public static bool In<T>(this T val, params T[] values) where T : struct => values.Contains(val);

        public static bool HasSchema(this string str) => SchemaPattern.IsMatch(str);

        public static string GetWellFormedUrl(this string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                var newUrl = url;
                if (!newUrl.HasSchema())
                    newUrl = "http://" + newUrl;

                if (Uri.IsWellFormedUriString(newUrl, UriKind.Absolute))
                    newUrl = newUrl.TrimEnd("/");

                url = newUrl;
            }
            return url;
        }

        public static System.IO.DirectoryInfo AsDirectory(this string @this)
        {
            if (@this.IsEmpty()) return null;
            return new System.IO.DirectoryInfo(@this);
        }

        public static bool IsEmpty(this string text) => string.IsNullOrEmpty(text);

        public static DirectoryInfo EnsureExists(this DirectoryInfo @this)
        {
            if (!@this.Exists())
                System.IO.Directory.CreateDirectory(@this.FullName);

            return @this;
        }

        public static bool Exists(this DirectoryInfo @this)
        {
            if (@this == null) return false;
            return System.IO.Directory.Exists(@this.FullName);
        }

        public static FileInfo GetFile(this DirectoryInfo folder, string fileName) => folder.PathCombine(fileName).AsFile();


        public static string PathCombine(this DirectoryInfo parent, string subdirectoryName)
        {
            var parts = new[] { parent.FullName }.Concat(subdirectoryName.OrEmpty().Split('\\', '/')).Trim().ToArray();
            return Path.Combine(parts);
        }
        public static FileInfo AsFile(this string @this)
        {
            if (@this.IsEmpty()) return null;
            return new FileInfo(@this);
        }
        public static IEnumerable<string> Trim(this IEnumerable<string> @this)
        {
            if (@this == null) return Enumerable.Empty<string>();

            return @this.Except(v => string.IsNullOrWhiteSpace(v)).Select(v => v.Trim()).Where(v => v.HasValue()).ToArray();
        }
        public static IEnumerable<T> Except<T>(this IEnumerable<T> list, Func<T, bool> criteria) => list.Where(i => !criteria(i));

        public static IEnumerable<T> Concat<T>(this IEnumerable<T> @this, params IEnumerable<T>[] otherLists)
        {
            var result = @this;

            foreach (var other in otherLists) result = Enumerable.Concat(result, other);

            return result;
        }
        public static string TrimEnd(this string @this, string unnecessaryText) => TrimEnd(@this, unnecessaryText, caseSensitive: true);

        public static string TrimEnd(this string @this, string unnecessaryText, bool caseSensitive)
        {
            if (unnecessaryText.IsEmpty() || @this.IsEmpty())
                return @this.OrEmpty();

            else if (@this.EndsWith(unnecessaryText, caseSensitive ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase))
                return @this.TrimEnd(unnecessaryText.Length);

            else
                return @this;
        }

        public static string TrimEnd(this string @this, int numberOfCharacters)
        {
            if (numberOfCharacters < 0)
                throw new ArgumentException("numberOfCharacters must be greater than 0.");

            if (numberOfCharacters == 0) return @this;

            if (@this.IsEmpty() || @this.Length <= numberOfCharacters)
                return string.Empty;

            return @this.Substring(0, @this.Length - numberOfCharacters);
        }

        public static string OrEmpty(this string @this) => @this ?? string.Empty;

        public static TimeSpan Seconds(this int number) => TimeSpan.FromSeconds(number);

        public static string[] ToLines(this string @this)
        {
            if (@this is null) return new string[0];

            return @this.Split('\n').Select(l => l.Trim('\r')).ToArray();
        }
        
        public static string ToFullMessage(this System.Exception ex)
        {
            return ToFullMessage(ex, additionalMessage: null, includeStackTrace: false, includeData: false);
        }

        public static string ToFullMessage(this System.Exception @this, string additionalMessage, bool includeStackTrace, bool includeData)
        {
            var err = @this ?? throw new NullReferenceException("This exception object is null");

            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLineIf(additionalMessage);

            while (err != null)
            {
                if (err is TargetInvocationException || err is AggregateException)
                {
                    err = err.InnerException;
                    continue;
                }

                resultBuilder.AppendLine(err.Message);

                if (includeData && err.Data != null && err.Data.Count > 0)
                {
                    resultBuilder.AppendLine("\r\nException Data:\r\n{");
                    foreach (var i in err.Data)
                        resultBuilder.AppendLine(ToLogText(i).WithPrefix("    "));
                    resultBuilder.AppendLine("}");
                }

                if (err is ReflectionTypeLoadException)
                {
                    foreach (var loaderEx in (err as ReflectionTypeLoadException).LoaderExceptions)
                        resultBuilder.AppendLine("Type load exception: " + loaderEx.ToFullMessage());
                }

                err = err.InnerException;
                if (err != null)
                {
                    resultBuilder.AppendLine();
                    if (includeStackTrace)
                        resultBuilder.AppendLine("###############################################");
                    resultBuilder.Append("Base issue: ");
                }
            }

            var stack = @this.GetUsefulStack().TrimOrEmpty();
            if (includeStackTrace && stack.HasValue())
            {
                var stackLines = stack.ToLines();
                stackLines = stackLines.Except(l => l.Trim().StartsWith("at System.Data.")).ToArray();
                resultBuilder.AppendLine(stackLines.ToString("\r\n\r\n").WithPrefix("\r\n--------------------------------------\r\nSTACK TRACE:\r\n\r\n"));
            }

            return resultBuilder.ToString();
        }
        public static string TrimOrEmpty(this string @this) => @this.TrimOrNull().OrEmpty();
        public static string ToString<T>(this IEnumerable<T> @this, string separator)
         => ToString(@this, separator, separator);
        public static string ToString<T>(this IEnumerable<T> @this, string separator, string lastSeparator)
        {
            if (@this is null) return null;
            var result = new StringBuilder();

            var items = @this.Cast<object>().ToArray();

            for (var i = 0; i < items.Length; i++)
            {
                var item = items[i];

                if (item == null) result.Append("{NULL}");
                else result.Append(item.ToString());

                if (i < items.Length - 2)
                    result.Append(separator);

                if (i == items.Length - 2)
                    result.Append(lastSeparator);
            }

            return result.ToString();
        }
        public static string TrimOrNull(this string @this) => @this?.Trim();

        public static string GetUsefulStack(this System.Exception @this)
        {
            if (@this.InnerException == null) return @this.StackTrace;
            if (@this is TargetInvocationException || @this is AggregateException)
                return @this.InnerException.GetUsefulStack();
            return @this.StackTrace;
        }
        public static string WithPrefix(this string @this, string prefix)
        {
            if (@this.IsEmpty()) return string.Empty;
            else return prefix + @this;
        }

        public static string ToLogText(object item)
        {
            try
            {
                if (item is DictionaryEntry d) return d.Key + ": " + d.Value;
                return item.ToString();
            }
            catch
            {
                // No logging is needed
                return "?";
            }
        }

        public static void AppendLineIf(this StringBuilder builder, string text)
        {
            if (text.HasValue()) builder.AppendLine(text);
        }
        public static TValue TryGet<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key)
        {
            if (@this is null) return default(TValue);
            if (@this.TryGetValue(key, out var result)) return result;

            return default(TValue);
        }

        public static string OnlyWhen(this string @this, bool condition)
        {
            if (condition) return @this;
            else return string.Empty;
        }


        public static bool None<T>(this IEnumerable<T> @this) => !@this.HasAny();
        public static bool HasAny<TSource>(this IEnumerable<TSource> @this)
          => @this != null && @this.Any();
        public static bool IsSingle<T>(this IEnumerable<T> @this) => IsSingle<T>(@this, x => true);
        public static bool IsSingle<T>(this IEnumerable<T> @this, Func<T, bool> criteria)
        {
            var visitedAny = false;

            foreach (var item in @this.Where(criteria))
            {
                if (visitedAny) return false;
                visitedAny = true;
            }

            return visitedAny;
        }

        public static T WithMax<T, TKey>(this IEnumerable<T> @this, Func<T, TKey> keySelector)
        {
            if (@this.None()) return default(T);
            return @this.Aggregate((a, b) => Comparer.Default.Compare(keySelector(a), keySelector(b)) > 0 ? a : b);
        }

        public static T WithMin<T, TKey>(this IEnumerable<T> @this, Func<T, TKey> keySelector)
        {
            if (@this.None()) return default(T);
            return @this.Aggregate((a, b) => Comparer.Default.Compare(keySelector(a), keySelector(b)) < 0 ? a : b);
        }

        public static bool HasMany<T>(this IEnumerable<T> @this)
        {
            using (var en = @this.GetEnumerator())
                return en.MoveNext() && en.MoveNext();
        }

        public static T? TryParseAs<T>(this string text) where T : struct
        {
            if (text.IsEmpty()) return default(T?);

            // Check common types first, for performance:
            if (TryParseToCommonTypes<T>(text, out var result))
                return result;

            foreach (var parser in TryParseProviders)
                if (parser(text, typeof(T), out var result2))
                    return (T)result2;

            try { return (T)Convert.ChangeType(text, typeof(T)); }
            catch
            {
                // No logging is needed
                return null;
            }
        }

        static bool TryParseToCommonTypes<T>(this string text, out T? result) where T : struct
        {
            result = null;

            if (typeof(T) == typeof(int))
            {
                if (int.TryParse(text, out var tempResult)) result = (T)(object)tempResult;

                return true;
            }

            if (typeof(T) == typeof(double))
            {
                if (double.TryParse(text, out var tempResult)) result = (T)(object)tempResult;

                return true;
            }

            if (typeof(T) == typeof(decimal))
            {
                if (decimal.TryParse(text, out var tempResult)) result = (T)(object)tempResult;

                return true;
            }

            if (typeof(T) == typeof(bool))
            {
                if (bool.TryParse(text, out var tempResult)) result = (T)(object)tempResult;

                return true;
            }

            if (typeof(T) == typeof(DateTime))
            {
                if (DateTime.TryParse(text, out var tempResult)) result = (T)(object)tempResult;

                return true;
            }

            if (typeof(T) == typeof(TimeSpan))
            {
                if (TimeSpan.TryParse(text, out var tempResult)) result = (T)(object)tempResult;

                return true;
            }

            if (typeof(T) == typeof(Guid))
            {
                if (Guid.TryParse(text, out var tempResult)) result = (T)(object)tempResult;

                return true;
            }

            if (typeof(T).IsEnum)
            {
                if (Enum.TryParse<T>(text, ignoreCase: true, result: out var tempResult)) result = (T)(object)tempResult;

                return true;
            }


            return false;
        }

        public static string Or(this string @this, string defaultValue)
        {
            if (@this.IsEmpty()) return defaultValue;
            else return @this;
        }

        public static string ToLowerOrEmpty(this string @this) => @this.OrEmpty().ToLower();

        public static string ToUpperOrEmpty(this string @this) => @this.OrEmpty().ToUpper();

       
        public static bool IsSingle<T>(this IEnumerable<T> list, out T first) where T : class
        {
            first = null;

            foreach (var item in list)
                if (first == null) first = item;
                else return false;

            return first != null;
        }

        public static bool StartsWithAny(this string @this, params string[] listOfBeginnings)
        {
            foreach (var option in listOfBeginnings)
                if (@this.StartsWith(option)) return true;

            return false;
        }

        public static bool Exists(this FileInfo @this)
        {
            if (@this == null) return false;
            return File.Exists(@this.FullName);
        }

        public static IEnumerable<T> ExceptNull<T>(this IEnumerable<T> @this) where T : class => @this.Where(i => i != null);

        public static IEnumerable<T> Except<T>(this IEnumerable<T> @this, T item) => @this.Except(new T[] { item });
        public static IEnumerable<T> Except<T>(this IEnumerable<T> list, params T[] items)
        {
            if (items == null) return list;

            return list.Where(x => !items.Contains(x));
        }

        public static bool ContainsAny<T>(this IEnumerable<T> @this, params T[] items) => @this.Intersects(items);
        public static bool Intersects<T>(this IEnumerable<T> @this, params T[] items) => @this.Intersects((IEnumerable<T>)items);
        public static bool Intersects<T>(this IEnumerable<T> @this, IEnumerable<T> otherList)
        {
            var countList = (@this as ICollection)?.Count;
            var countOther = (otherList as ICollection)?.Count;
            if (countList == null || countOther == null || countOther < countList)
            {
                foreach (var item in otherList)
                    if (@this.Contains(item)) return true;
            }
            else
            {
                foreach (var item in @this)
                    if (otherList.Contains(item)) return true;
            }
            return false;
        }
        public static IEnumerable<T> Union<T>(this IEnumerable<T> @this, params T[] otherItems) => @this.Union((IEnumerable<T>)otherItems);
        public static IEnumerable<T> Union<T>(this IEnumerable<T> @this, params IEnumerable<T>[] otherLists)
        {
            var result = @this;

            foreach (var other in otherLists)
                result = Enumerable.Union(result, other);

            return result;
        }
        public static void Remove<T>(this IList<T> @this, IEnumerable<T> itemsToRemove)
        {
            if (itemsToRemove != null)
            {
                foreach (var item in itemsToRemove)
                    if (@this.Contains(item)) @this.Remove(item);
            }
        }
        #endregion

        #region [Private Method]

        private static IEnumerable<TSource> FromHierarchy<TSource>(this TSource source, Func<TSource, TSource> nextItem, Func<TSource, bool> canContinue)
        {
            for (var current = source; canContinue(current); current = nextItem(current))
                yield return current;
        }

        private static IEnumerable<TSource> FromHierarchy<TSource>(this TSource source, Func<TSource, TSource> nextItem)
            where TSource : class => FromHierarchy(source, nextItem, s => s != null);

        private static readonly Regex MasterDetialInputPattern = new Regex("[A-Fa-f0-9]{8}(?:-[A-Fa-f0-9]{4}){3}-[A-Fa-f0-9]{12}\\.", RegexOptions.Compiled);

        private static FileInfo[] GetFiles(this DirectoryInfo dirInfo, string searchPattern, SearchOption searchOption = SearchOption.AllDirectories, List<string> excludeFolders = null)
        {
            var searchPatterns = searchPattern.Split('|');
            var files = new List<FileInfo>();
            foreach (var sp in searchPatterns)
                files.AddRange(dirInfo.GetFiles(sp, searchOption));

            if (excludeFolders != null && excludeFolders.Any())
                files = files.Where(c => !excludeFolders.Any(d => c.FullName.StartsWith(d))).ToList();

            return files.ToArray();
        }

        #endregion
    }
}
