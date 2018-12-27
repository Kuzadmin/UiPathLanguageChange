using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageChange.Designer
{
    using LanguageChange.Designer;
    using System.Activities.Presentation.Metadata;

    public sealed class LanguageChangeMetadata : IRegisterMetadata
    {
        public static void RegisterAll()
        {
            var builder = new AttributeTableBuilder();    
            LanguageChangeDesigner.RegisterMetadata(builder);

            // TODO: Other activities can be added here
            MetadataStore.AddAttributeTable(builder.CreateTable());
        }

        /// <summary>
        /// Registers metadata
        /// </summary>
        public void Register()
        {
            RegisterAll();
        }
    }
}
