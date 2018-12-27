using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LanguageChange
{
    public static class LanguageFactory
    {

        public static List<Language> GetLanguages()
        {
            List<Language> langs = new List<Language>();
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (CultureInfo culture in cultures)
            {
                if ((culture.LCID == culture.KeyboardLayoutId) && ((culture.LCID == 9) || (culture.LCID >= 1025) && (culture.LCID <= 4096)))
                {
                    Language language = new Language();
                    language.name_en = culture.EnglishName;
                    language.id = (culture.LCID).ToString("X8");
                    langs.Add(language);
                }

            }
            langs.Sort(new LangComparer());
            return langs;
        }

    }

    class LangComparer : IComparer<Language>
    {
        public int Compare(Language x, Language y)
        {
            return String.Compare(x.name_en, y.name_en);
        }
    }


    public class Language
    {
        public string id { get; set; }
        public string name_en { get; set; }        

        public override string ToString()
        {
            return this.name_en + " - '" + this.id + "'";
        }

        public override bool Equals(object obj)
        {
            if(obj is Language)
            {
                Language lan = obj as Language;
                if ((this.id == lan.id) && (this.name_en.Equals(lan.name_en)))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        
        public override int GetHashCode()
        {
            return (this.id + " " +this.name_en).GetHashCode();
        }

    }
}
