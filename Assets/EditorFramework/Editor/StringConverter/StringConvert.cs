namespace EditorFramework.Editor.StringConverter
{
    public static class StringConvert
    {
        public static bool TryConvert<T>(this string self, out T result)
        {
            if (StringConverter.Get<T>().TryConvert(self, out result))
            {
                return true;
            }

            return false;
        }
    }
}