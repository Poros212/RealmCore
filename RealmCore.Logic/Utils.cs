namespace RealmCore.Logic
{
    public class Utils
    {
        // clone a obj with a parameterless constructor
        public static T Clone<T>(T obj) where T : new()
        {

            T newObj = new T();
            return newObj;
        }
    }
}
