using System.Globalization;
using System.Text;
using ExpensesControl.DataModelManager.Models;

namespace ExpensesControl.DataModelManager.ExtensionModelMethods;

public static class DashedNamePropertyInModelExtensions
{
    public static string GetDashedName(this DashedNamePropertyInModel billModel)
    {
        var name = billModel.Name;
        var normalizedString = name.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var c in normalizedString.EnumerateRunes())
        {
            var unicodeCategory = Rune.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        var cleanedName = stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        var ans = new StringBuilder();
        int i = 0;
        while (i < cleanedName.Length)
        {
            var letter = cleanedName[i++];

            if (char.IsLetterOrDigit(letter))
            {
                ans.Append(letter);
            }
            else
            {
                ans.Append('-');
                while (i < cleanedName.Length && char.IsWhiteSpace(cleanedName[i]))
                {
                    i++;
                }
            }
        }

        return ans.ToString();
    }
}