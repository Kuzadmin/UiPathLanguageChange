namespace LanguageChange.Designer
{
    using LanguageChange;
    using System.Activities.Presentation.Metadata;
    using System.ComponentModel;
    using System.Drawing;

    public partial class LanguageChangeDesigner
    {
        public LanguageChangeDesigner()
        {
            this.InitializeComponent();
        }

        public static void RegisterMetadata(AttributeTableBuilder builder)
        {
            builder.AddCustomAttributes(
                typeof(LanguageChangeActivity),
                new DesignerAttribute(typeof(LanguageChangeDesigner)),
                new DescriptionAttribute("Change language activity"),
                new ToolboxBitmapAttribute(typeof(LanguageChangeActivity), "LangMark.png"));
        }

    }
}
