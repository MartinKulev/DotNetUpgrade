namespace DotNetUpgrade
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection == null || !collection.Any();
        }

        public static bool ContainsAny<T>(this IEnumerable<T> source, IEnumerable<T> items)
        {
            return source != null && items != null && source.Any(items.Contains);
        }

        public static bool ContainsAll<T>(this IEnumerable<T> source, IEnumerable<T> items)
        {
            return source != null && items != null && items.All(source.Contains);
        }
    }
}
