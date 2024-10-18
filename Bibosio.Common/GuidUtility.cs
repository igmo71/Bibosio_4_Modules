namespace Bibosio.Common
{
    public class GuidUtility
    {
        public static Guid CreateV7()
        {
            var result = Guid.CreateVersion7();
            return result;
        }
    }
}
