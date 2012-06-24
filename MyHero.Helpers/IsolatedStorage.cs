using System.IO;
using System.IO.IsolatedStorage;
using System.Text;
using Newtonsoft.Json;

namespace MyHero.Helpers
{
    public class IsolatedStorage
    {
        public static T GetObject<T>(string key)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains(key))
            {

                string serializedObject = IsolatedStorageSettings.ApplicationSettings[key].ToString();
                return JsonConvert.DeserializeObject<T>(serializedObject);
            }

            return default(T);
        }

        public static void SaveObject<T>(string key, T objectToSave)
        {
            string serializedObject = JsonConvert.SerializeObject(objectToSave);
            IsolatedStorageSettings.ApplicationSettings[key] = serializedObject;
        }

        public static void DeleteObject(string key)
        {
            IsolatedStorageSettings.ApplicationSettings.Remove(key);
        }
    }
}
