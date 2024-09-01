using System.Reflection;

namespace LibraryAPI.Business.Helpers
{
    public static class ObjectHasProperty
    {
        public static bool HasProperty(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null;
        }
    }
}
