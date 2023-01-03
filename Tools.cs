using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;

namespace GCScript_Tools_API
{
    public static class Tools
    {

        public static string OnlyLetters(string text)
        {
            return Regex.Replace(TreatText(text).ToLower(), @"[^a-zA-Z]", "");
        }

        public static string ForSlug(string text)
        {
            text = Regex.Replace(TreatText(text).ToLower().Trim(), @"\s", "-");
            text = Regex.Replace(text.Trim(), @"[^a-zA-Z0-9-]", "");
            text = Regex.Replace(text.Trim(), @"-{2,}", "-");
            return text;
        }

        public static string OnlyLettersAndNumbers(string text)
        {
            return Regex.Replace(TreatText(text).ToLower(), @"[^a-zA-Z0-9]", "");
        }

        public static string TreatText(string text, bool trim = true, bool toUpper = true, bool removeAccents = true, bool removeDuplicateSpaces = true)
        {
            if (trim)
                text = text.Trim();
            if (toUpper)
                text = text.ToUpper();
            if (removeAccents)
                text = RemoveAccents(text);
            if (removeDuplicateSpaces)
                text = RemoveDuplicateSpaces(text);
            return text;
        }

        public static string RemoveAccents(string texto)
        {
            var stringBuilder = new StringBuilder();
            StringBuilder sbReturn = stringBuilder;
            var arrayText = texto.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

        public static string RemoveDuplicateSpaces(string texto)
        {
            texto = Regex.Replace(texto, @"\s{2,}", " ");
            texto = texto.Trim();

            return texto;
        }
    }
}
