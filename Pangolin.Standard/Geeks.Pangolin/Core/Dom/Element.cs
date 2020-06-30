using System.Drawing;

namespace Geeks.Pangolin.Core.Dom
{
    public abstract class Element
    {
        #region [Property]

        public virtual string Id { get; }
        public virtual string Name { get; }
        public virtual string TagName { get; }
        public virtual string[] Classes { get; }
        public virtual Size Size { get; }
        public virtual Point Location { get; }
        public virtual string VisualText { get; }
        public virtual string Type { get; }
        public virtual string Label { get; set; }
        public virtual bool IsCheckbox { get; }
        public virtual bool IsRadio { get; }
        public virtual bool IsColour { get; }
        public virtual bool IsRadioGroup { get; }
        public virtual bool IsChosenField { get; }
        public virtual bool IsChosenItem { get; }

        #endregion

        #region [Constructor]

        #endregion

        #region [Public Method]

        public abstract bool HasSize();

        public abstract Rectangle GetRect();

        #endregion

        #region [Protected Method]

        #endregion

        #region [Private Method]

        #endregion
    }
}
