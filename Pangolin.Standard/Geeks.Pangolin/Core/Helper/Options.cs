using System;
using System.Linq;

namespace Geeks.Pangolin.Core.Helper
{
    public class Options
    {
        #region [Property]

        private const bool DEFAULT_CONSIDER_INVISIBLE_ELEMENTS = false;
        private const bool DEFAULT_EXPECT_ELEMENTS = true;
        private const TextPrecision DEFAULT_PRECISION = TextPrecision.PreferExact;
        private const Match DEFAULT_MATCH = Match.First;
        private static readonly TimeSpan DEFAULT_TIMEOUT = TimeSpan.FromSeconds(1);
        private static readonly TimeSpan DEFAULT_RETRY_INTERVAL = TimeSpan.FromSeconds(0.05);
        private static readonly TimeSpan DEFAULT_WAIT_BEFORE_CLICK = TimeSpan.Zero;
        protected bool? considerInvisibleElements;
        private bool? expectElements;
        private Area area;
        private TextPrecision? textPrecision;
        private Match? match;
        private TimeSpan? retryInterval;
        private TimeSpan? timeout;
        private TimeSpan? waitBeforeClick;
        public static Options NoWait = new Options { Timeout = TimeSpan.Zero };
        public static Options Invisible = new Options { ConsiderInvisibleElements = true };
        public static Options First { get { return new Options { Match = Match.First }; } }
        public static Options Single => new Options { Match = Match.Single };
        public static Options Exact => new Options { TextPrecision = TextPrecision.Exact };
        public static Options Substring => new Options { TextPrecision = TextPrecision.Substring };
        public static Options PreferExact => new Options { TextPrecision = TextPrecision.PreferExact };
        public static Options FirstExact = Merge(First, Exact);
        public static Options FirstSubstring = Merge(First, Substring);
        public static Options FirstPreferExact = Merge(First, PreferExact);
        public static Options SingleExact = Merge(Single, Substring);
        public static Options SingleSubstring = Merge(Single, Substring);
        public static Options SinglePreferExact = Merge(Single, PreferExact);
        public TimeSpan Timeout { get { return timeout ?? DEFAULT_TIMEOUT; } set { timeout = value; } }
        public TimeSpan RetryInterval { get { return retryInterval ?? DEFAULT_RETRY_INTERVAL; } set { retryInterval = value; } }
        public TimeSpan WaitBeforeClick { get { return waitBeforeClick ?? DEFAULT_WAIT_BEFORE_CLICK; } set { waitBeforeClick = value; } }
        public bool ConsiderInvisibleElements { get { return considerInvisibleElements ?? DEFAULT_CONSIDER_INVISIBLE_ELEMENTS; } set { considerInvisibleElements = value; } }
        public bool ExpectElements { get { return expectElements ?? DEFAULT_EXPECT_ELEMENTS; } set { expectElements = value; } }
        public Area Area { get { return area ?? new Area(); } set { area = value; } }
        public TextPrecision TextPrecision { get { return textPrecision ?? DEFAULT_PRECISION; } set { textPrecision = value; } }
        public bool TextPrecisionExact => textPrecision == TextPrecision.Exact;
        public Geeks.Pangolin.Core.Helper.Match Match { get { return match ?? DEFAULT_MATCH; } set { match = value; } }

        #endregion

        #region [Constructor]

        #endregion

        #region [Public Method]

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals((Options)obj);
        }

        public string BuildAmbiguousMessage(string queryDescription, int count)
        {
            var message = string.Format(@"Ambiguous match, found {0} elements matching {1}

Geeks.Pangolin does this by default from v2.0. Your options:

 * Look for something more specific",
                    count, queryDescription);


            if (TextPrecision != TextPrecision.Exact)
                message += Environment.NewLine + " * Set the Options.TextPrecision option to Exact to exclude substring text matches";

            if (Match != Match.First)
                message += Environment.NewLine + " * Set the Options.Match option to Match.First to just take the first matching element";

            return message;
        }

        public static Options Merge(Options preferredOptions, Options defaultOptions)
        {
            preferredOptions = preferredOptions ?? new Options();
            defaultOptions = defaultOptions ?? new Options();

            return new Options
            {
                considerInvisibleElements = Default(preferredOptions.considerInvisibleElements, defaultOptions.considerInvisibleElements),
                textPrecision = Default(preferredOptions.textPrecision, defaultOptions.textPrecision),
                match = Default(preferredOptions.match, defaultOptions.match),
                retryInterval = Default(preferredOptions.retryInterval, defaultOptions.retryInterval),
                timeout = Default(preferredOptions.timeout, defaultOptions.timeout),
                waitBeforeClick = Default(preferredOptions.waitBeforeClick, defaultOptions.waitBeforeClick),
                expectElements = Default(preferredOptions.expectElements, defaultOptions.expectElements),
                area = preferredOptions.area ?? defaultOptions.area
            };
        }

        protected static T? Default<T>(T? value, T? defaultValue) where T : struct => value.HasValue ? value : defaultValue;

        public override string ToString() => string.Join(Environment.NewLine, GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).Select(p => p.Name + ": " + p.GetValue(this, null)).ToArray());

        protected bool Equals(Options other) => considerInvisibleElements.Equals(other.considerInvisibleElements) && textPrecision.Equals(other.textPrecision) && match == other.match && retryInterval.Equals(other.retryInterval) && timeout.Equals(other.timeout) && waitBeforeClick.Equals(other.waitBeforeClick);

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = considerInvisibleElements.GetHashCode();
                hashCode = (hashCode * 397) ^ textPrecision.GetHashCode();
                hashCode = (hashCode * 397) ^ match.GetHashCode();
                hashCode = (hashCode * 397) ^ retryInterval.GetHashCode();
                hashCode = (hashCode * 397) ^ timeout.GetHashCode();
                hashCode = (hashCode * 397) ^ waitBeforeClick.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Options left, Options right) => Equals(left, right);

        public static bool operator !=(Options left, Options right) => !Equals(left, right);

        #endregion

        #region [Private Method]

        #endregion
    }
}
