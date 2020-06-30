namespace Geeks.Pangolin.Helper.UIContext
{
    public interface ICommandSet
    {
        /// <summary>
        /// set field. <para />
        /// Example: to set a field with value "value" use To("value");
        /// </summary>
        void To(string value);
        void To(params string[] values);
    }
}
