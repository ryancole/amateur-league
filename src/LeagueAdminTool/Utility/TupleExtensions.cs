using System;

namespace LeagueAdminTool.Utility
{
    public static class TupleExtensions
    {
        #region Methods

        public static bool Contains(this Tuple<long, long> source, long value)
        {
            return source.Item1 == value || source.Item2 == value;
        }

        #endregion
    }
}
