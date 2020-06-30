using System.Linq;
using Geeks.Pangolin.Core.Helper;

namespace Geeks.Pangolin.Core.Drivers
{
    public class Html : XPath
    {
        #region [Property]

        private static readonly string[] InputButtonTypes = new[] { "button", "submit", "image", "reset" };
        private static readonly string[] FieldTagNames = new[] { "input", "select", "textarea" };
        private static readonly string[] FieldInputTypes = new[] { "text", "password", "radio", "checkbox", "file", "email", "tel", "url", "number", "datetime", "datetime-local", "date", "month", "week", "time", "color", "search" };
        private static readonly string[] FieldInputTypeWithHidden = FieldInputTypes.Union(new[] { "hidden" }).ToArray();
        private static readonly string[] FindByNameTypes = FieldInputTypes.Except(new[] { "radio" }).ToArray();
        private static readonly string[] FindByValueTypes = new[] { "checkbox", "radio", "submit" };
        private static readonly string[] SectionTags = { "section", "div", "li" };
        private static readonly string[] RowTagName = { "tr" };
        private static readonly string[] TableTagName = { "table" };
        private static readonly string[] ColumnTagName = { "td" };
        private static readonly string[] ColumnHeaderTagName = { "th" };
        private static readonly string[] BodyTagName = { "body" };
        private static readonly string[] LabelTagName = { "label", "strong" };
        private static readonly string[] SelectTagName = { "select" };
        private static readonly string[] HeaderTags = { "h1", "h2", "h3", "h4", "h5", "h6" };
        private static readonly string[] FieldOrLinkOrButtonTypes = InputButtonTypes.Union(new[] { "a" }).Union(FieldTagNames).ToArray();
        private static readonly string[] LinkTypes = new[] { "a" };


        private static Html instance = null;
        public static Html Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Html();
                };
                return instance;
            }
        }

        #endregion

        #region [Constructor]

        private Html(bool uppercaseTagNames = false) : base(uppercaseTagNames)
        {
        }

        #endregion

        #region [Public Method]

        public string Id(string locator, Options options) => Descendent() +
                Where(HasId(locator) + or + HasControlId(locator));

        public string All(string locator, Options options) => (string.IsNullOrEmpty(locator)) ? Descendent() : Descendent() +
                       Where(
                           IsForLabeled(locator, options) +
                           or + IsForControlLabeled(locator, options) +
                           or + IsText(locator, options) +
                           or + IsContainerLabeled(locator, options) +
                           or + HasIdOrControlIdOrPlaceholder(locator, options) +
                           or + HasId(locator) +
                           or + HasControlId(locator) +
                           or + HasName(locator) +
                           or + HasAlt(locator, options) +
                           or + HasValue(locator));

        public string HasTitle(string title, Options options) => Attr("title", title, options);

        public string HasHref(string href, Options options) => Attr("href", href, options);

        public string HasAlt(string alt, Options options) => Attr("alt", alt, options);

        public string Button(string locator, Options options) => (string.IsNullOrEmpty(locator)) ? Descendent() +
                    Where(
                        Group(
                            IsInputButton() +
                            or + TagNamedOneOf("button") +
                            or + HasOneOfClasses("button", "btn") +
                            or + Attr("role", "button", Options.Exact))) :
                Descendent() +
                Where(
                    Group(
                        IsInputButton() +
                        or + TagNamedOneOf("button") +
                        or + HasOneOfClasses("button", "btn") +
                        or + Attr("role", "button", Options.Exact)) +
                    And(
                        AttributesMatchLocator(locator, Options.Exact, "@id", "@name") +
                        or + AttributesMatchLocator(locator.Trim(), options, "@value", "@alt", "normalize-space()")));

        public string Link(string locator, Options options) => (string.IsNullOrEmpty(locator)) ?
                    Descendent() +
                    Where(
                        TagNamedOneOf(LinkTypes)) :
            Descendent() +
                   Where(
                       TagNamedOneOf(LinkTypes) +
                       And(
                           IsText(locator, options) +
                           or + HasTitle(locator, options) +
                           or + Attr("name", locator, Options.Exact) +
                           or + HasHref(locator, options)

                       ));

        public string Field(string locator, Options options) => (string.IsNullOrEmpty(locator)) ?
                    Descendent() +
                    Where(
                        TagNamedOneOf(FieldTagNames)): 
            Descendent() +
                Where(
                    TagNamedOneOf(FieldTagNames) +
                    And(
                        IsForLabeled(locator, options) +
                        or + IsForLabeled(locator + ":", options) +
                        or + IsForLabeled(locator + "*", options) +
                        or + IsForLabeled("*" + locator, options) +
                        or + IsForControlLabeled(locator, options) +
                        or + IsForControlLabeled(locator + ":", options) +
                        or + IsForControlLabeled(locator + "*", options) +
                        or + IsForControlLabeled("*" + locator, options) +
                        or + IsContainerLabeled(locator, options) +
                        or + IsContainerLabeled(locator + ":", options) +
                        or + IsContainerLabeled(locator + "*", options) +
                        or + IsContainerLabeled("*" + locator, options) +

                        or + IsForLegend(locator, options) +
                        or + IsForLegend(locator + ":", options) +
                        or + IsForLegend(locator + "*", options) +
                        or + IsForLegend("*" + locator, options) +
                        or + IsForControlLegend(locator, options) +
                        or + IsForControlLegend(locator + ":", options) +
                        or + IsForControlLegend(locator + "*", options) +
                        or + IsForControlLegend("*" + locator, options) +
                        or + IsContainerLegend(locator, options) +
                        or + IsContainerLegend(locator + ":", options) +
                        or + IsContainerLegend(locator + "*", options) +
                        or + IsContainerLegend("*" + locator, options) +

                        or + HasIdOrControlIdOrPlaceholder(locator, options) +
                        or + HasName(locator) +
                        or + HasValue(locator)))

                + union +

                Descendent("div") +
                Where(
                    HasOneOfClasses("radio-list") +
                    And(
                        IsForLabeled(locator, options) +
                        or + IsForLabeled(locator + ":", options) +
                        or + IsForLabeled(locator + "*", options) +
                        or + IsForLabeled("*" + locator, options) +
                        or + IsForControlLabeled(locator, options) +
                        or + IsForControlLabeled(locator + ":", options) +
                        or + IsForControlLabeled(locator + "*", options) +
                        or + IsForControlLabeled("*" + locator, options) +
                        or + IsContainerLabeled(locator, options) +
                        or + IsContainerLabeled(locator + ":", options) +
                        or + IsContainerLabeled(locator + "*", options) +
                        or + IsContainerLabeled("*" + locator, options) +

                        or + IsForLegend(locator, options) +
                        or + IsForLegend(locator + ":", options) +
                        or + IsForLegend(locator + "*", options) +
                        or + IsForLegend("*" + locator, options) +
                        or + IsForControlLegend(locator, options) +
                        or + IsForControlLegend(locator + ":", options) +
                        or + IsForControlLegend(locator + "*", options) +
                        or + IsForControlLegend("*" + locator, options) +
                        or + IsContainerLegend(locator, options) +
                        or + IsContainerLegend(locator + ":", options) +
                        or + IsContainerLegend(locator + "*", options) +
                        or + IsContainerLegend("*" + locator, options) +

                        or + HasName(locator)
                        )
                    )

                + union +

                Descendent("th") +
                Where(
                    IsForLabeled(locator, options) +
                    or + IsForLabeled(locator + ":", options) +
                    or + IsForLabeled(locator + "*", options) +
                    or + IsForLabeled("*" + locator, options) +
                    or + IsForControlLabeled(locator, options) +
                    or + IsForControlLabeled(locator + ":", options) +
                    or + IsForControlLabeled(locator + "*", options) +
                    or + IsForControlLabeled("*" + locator, options) +
                    or + IsContainerLabeled(locator, options) +
                    or + IsContainerLabeled(locator + ":", options) +
                    or + IsContainerLabeled(locator + "*", options) +
                    or + IsContainerLabeled("*" + locator, options) +
                    or + HasName(locator) +
                    or + IsText(locator, options));

        public string Select(string locator, Options options) => (string.IsNullOrEmpty(locator)) ?
                    Descendent("select") +
                    Where(
                        TagNamedOneOf(SelectTagName)) :
                Descendent("select") +
                Where(
                    IsForLabeled(locator, options) +
                    or + IsForControlLabeled(locator, options) +
                    or + IsContainerLabeled(locator, options) +
                    or + HasId(locator) +
                    or + HasControlId(locator) +
                    or + HasName(locator));

        public string FrameXPath(string locator, Options options) => (string.IsNullOrEmpty(locator)) ?
                    Descendent() +
                    Where(
                        TagNamedOneOf("iframe", "frame")) :
                Descendent() +
                Where(
                    TagNamedOneOf("iframe", "frame") +
                     And(
                         FrameAttributesMatch(locator)
                         ));

        public string Fieldset(string locator, Options options) => Descendent("fieldset") +
                Where(
                    Child("legend") +
                    Where(IsText(locator, options)) +
                    or + HasControlId(locator) +
                    or + HasId(locator));

        public string Section(string locator, Options options) => (string.IsNullOrEmpty(locator)) ?
                    Descendent() +
                    Where(
                        TagNamedOneOf(SectionTags)) :
                (Descendent() +
                Where(
                    TagNamedOneOf(SectionTags) +
                    And(
                        Child() +
                        Where(
                            IsText(locator, options)
                        ) +
                        or + HasControlId(locator) +
                        or + HasId(locator)))) + "/..";

        public string Header(string locator, Options options) => (string.IsNullOrEmpty(locator)) ?
                    Descendent() +
                    Where(
                        TagNamedOneOf(HeaderTags)) :
                Descendent() +
                Where(
                    TagNamedOneOf(HeaderTags) +
                    And(
                        IsText(locator, options) +
                        or + HasControlId(locator) +
                        or + HasId(locator)

                        ));

        public string HeaderSection(string locator, Options options) => Header(locator, options) + "/../..";

        public string Row(string locator, Options options) => Descendent("tr") +
                Where(
                    TagNamedOneOf(RowTagName) +
                    And(
                        Child() +
                        Where(
                            IsText(locator, options)
                            ) +
                        or + HasControlId(locator) +
                        or + HasId(locator)));

        public string Table(string locator, Options options) => Row(locator, options) + "/../..";

        public string TableColumn(string locator, Options options) => Column(locator, options) + "/../../..";

        public string Column(string locator, Options options) => Descendent("th") +
                Where(
                    TagNamedOneOf(ColumnHeaderTagName) +
                    And(
                        IsText(locator, options)
                        ));

        public string Body(string locator, Options options) => Descendent("body") +
                Where(
                    TagNamedOneOf(BodyTagName));

        public string Label(string locator, Options options) => (string.IsNullOrEmpty(locator)) ?
                    Descendent() +
                    Where(
                        TagNamedOneOf(LabelTagName)) :
                Descendent() +
                Where(
                    TagNamedOneOf(LabelTagName) +
                    And(
                        IsText(locator, options)
                ));

        public string LabelSection(string locator, Options options) => Label(locator, options) + "/../..";

        public string Text(string locator, Options options) => (string.IsNullOrEmpty(locator)) ?
                    Descendent() :
                Descendent() +
                Where(
                    IsTextShallow(locator, options) +
                    or + Is("@value", locator, options) +
                    or + Is("@placeholder", locator, options)
                    );

        public string Option(string locator, Options options) => Child("option") +
                Where(
                    IsText(locator, options) +
                or + Is("@value", locator, options));

        #endregion

        #region [Private Method]

        private string HasValue(string locator) => Group(AttributeIsOneOf("type", FindByValueTypes) + and + Attr("value", locator, Options.Exact));

        private string HasName(string locator) => Group(AttributeIsOneOfOrMissing("type", FindByNameTypes) + and + Attr("name", locator, Options.Exact));

        private string FrameAttributesMatch(string locator) => AttributesMatchLocator(locator.Trim(), Options.Exact, "@id", "@name", "@title");

        private string IsInputButton() => Group(TagNamedOneOf("input") + and + AttributeIsOneOf("type", InputButtonTypes));

        private string IsAFieldInputType(Options options) => AttributeIsOneOfOrMissing("type", options.ConsiderInvisibleElements ? FieldInputTypeWithHidden : FieldInputTypes);

        private string HasIdOrControlIdOrPlaceholder(string locator, Options options) => Group(IsAFieldInputType(options)
                         + And(HasId(locator) + or + HasId(locator) + or + Is("@placeholder", locator, options)));

        private string HasId(string locator) => Attr("id", locator, Options.Exact);

        private string HasControlId(string locator) => Attr("controlid", locator, Options.Exact);

        #endregion
    }
}
