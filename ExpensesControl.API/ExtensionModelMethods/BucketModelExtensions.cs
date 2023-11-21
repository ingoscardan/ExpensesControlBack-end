using ExpensesControl.API.Models;

namespace ExpensesControl.API.ExtensionModelMethods;

public static class BucketModelExtensions
{
    public static string GetDashedName(this BucketModel model)
    {
        var modelName = model.Name.ToLower();
        var words = modelName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        var sanitizedWords = new List<string>();
        for(int i = 0; i < words.Length; i++)
        {
            var letters = words[i].ToCharArray();

            if (letters.Length > 0)
            {
                var filter = Array.FindAll<char>(letters, (c => (char.IsLetterOrDigit(c) 
                                                    || char.IsWhiteSpace(c) 
                                                    || c == '-')));
                if (filter.Length > 0)
                {
                    sanitizedWords.Add(new string(filter));
                }
            }
            
        }

        return string.Join('-', sanitizedWords);
    } 
}