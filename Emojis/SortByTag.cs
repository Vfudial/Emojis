namespace Emojis
{
    public class SortByTag : IComparer<Emoji>
    {
        public int Compare(Emoji? x, Emoji? y)
        {
            return String.Compare(x?.Tag, y?.Tag, StringComparison.Ordinal);
        }
    }
}