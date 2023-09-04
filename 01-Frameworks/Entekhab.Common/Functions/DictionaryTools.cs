namespace Entekhab.Common.Functions;

public class DictionaryTools
{
    //********************************************************************************************************************
    public static T DictionaryToModelMapper<T>(Dictionary<string, string> dictionary) where T : new()
    {
        T model = new T();

        foreach (var property in typeof(T).GetProperties())
        {
            if (dictionary.ContainsKey(property.Name))
            {
                object value = dictionary[property.Name];
                if (property.PropertyType.IsAssignableFrom(value.GetType()))
                {
                    property.SetValue(model, value);
                }
                else
                {
                    // Handle type conversion to int
                    if (property.PropertyType == typeof(int))
                    {
                        if (int.TryParse(value.ToString(), out int intValue))
                        {
                            property.SetValue(model, intValue);
                        }
                    }
                    
                }
            }
        }

        return model;
    }
    //********************************************************************************************************************
}