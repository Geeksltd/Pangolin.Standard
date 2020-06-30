using System;
using System.Linq;
using Geeks.Pangolin.Core.Helper;

namespace Geeks.Pangolin.Core.Drivers
{
    public class XPath
    {
        #region [Property]

        private readonly bool uppercaseTagNames;
        public const string and = " and ";
        public const string or = " or ";
        public const string union = " | ";

        #endregion

        #region [Constructor]

        public XPath(bool uppercaseTagNames = false)
        {
            this.uppercaseTagNames = uppercaseTagNames;
        }

        #endregion

        #region [Public Method]

        public string Format(string value, params object[] args) => String.Format(value, args.Select(a => Literal(a.ToString())).ToArray());

        public string Group(string expression) => "(" + expression + ")";

        public string And(string expression) => and + Group(expression);

        public string Literal(string value)
        {
            if (HasNoDoubleQuotes(value))
                return WrapInDoubleQuotes(value);

            if (HasNoSingleQuotes(value))
                return WrapInSingleQuote(value);

            return BuildConcatSeparatingSingleAndDoubleQuotes(value);
        }

        public string HasOneOfClasses(params string[] classNames) => Group(String.Join(" or ", classNames.Select(XPathNodeHasClass).ToArray()));

        public string XPathNodeHasClass(string className) => String.Format("contains(@class,' {0}') " +
                                 "or contains(@class,'{0}') " +
                                 "or contains(@class,'{0} ') " +
                                 "or contains(@class,' {0} ')", className);

        public string AttributeIsOneOfOrMissing(string attributeName, string[] values) => Group(AttributeIsOneOf(attributeName, values) + or + "not(@" + attributeName + ")");

        public string AttributeIsOneOf(string attributeName, string[] values) => Group(String.Join(" or ", values.Select(t => Format("@" + attributeName + " = {0}", t)).ToArray()));

        public string Attr(string name, string value, Options options) => Is("@" + name, value, options);

        public string TagNamedOneOf(params string[] fieldTagNames) => Group(string.Join(" or ", fieldTagNames.Select(t => Format("name() = {0}", CasedTagName(t))).ToArray()));

        public string CasedTagName(string tagName) => uppercaseTagNames ? tagName.ToUpper() : tagName;

        public string AttributesMatchLocator(string locator, Options options, params string[] attributes) => Group(string.Join(" or ", attributes.Select(a => Is(a, locator, options)).ToArray()));

        public string IsContainerLabeled(string locator, Options options) => Format("ancestor::label[" + IsTextShallow(locator, options) + "]", locator);

        public string IsForLabeled(string locator, Options options) => Format(" (@id = //label[" + IsText(locator, options) + "]/@for) ", locator);

        public string IsForControlLabeled(string locator, Options options) => Format(" (@controlid = //label[" + IsText(locator, options) + "]/@for) ", locator);

        public string IsContainerLegend(string locator, Options options) => Format("ancestor::legend[" + IsTextShallow(locator, options) + "]", locator);

        public string IsForLegend(string locator, Options options) => Format(" (@id = //legend[" + IsText(locator, options) + "]/@for) ", locator);

        public string IsForControlLegend(string locator, Options options) => Format(" (@controlid = //legend[" + IsText(locator, options) + "]/@for) ", locator);

        public string Is(string selector, string locator, Options options) => options.TextPrecisionExact
                ? Format("translate(" + selector + ", 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = {0} ", locator.ToLowerOrEmpty())
                : Format("contains(translate(" + selector + ", 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'),{0})", locator.ToLowerOrEmpty());

        public string IsText(string locator, Options options) => Is("normalize-space()", locator, options);

        public string IsTextShallow(string locator, Options options) => Is("normalize-space(text())", locator, options);

        public string Descendent(string tagName = "*") => ".//" + tagName;

        public string Child(string tagName = "*") => "./" + tagName;

        public string Where(string predicate) => "[" + predicate + "]";

        #endregion

        #region [Private Method]

        private string BuildConcatSeparatingSingleAndDoubleQuotes(string value) => String.Format("concat({0})", TrimEmptyParts(String.Join(", '\"', ", value.Split('\"').Select(WrapInDoubleQuotes).ToArray())));

        private string WrapInSingleQuote(string value) => String.Format("'{0}'", value);

        private string WrapInDoubleQuotes(string value) => String.Format("\"{0}\"", value);

        private string TrimEmptyParts(string concatArguments) => concatArguments.Replace(", \"\"", "").Replace("\"\", ", "");

        private bool HasNoSingleQuotes(string value) => !value.Contains("'");

        private bool HasNoDoubleQuotes(string value) => !value.Contains("\"");

        #endregion
    }
}
