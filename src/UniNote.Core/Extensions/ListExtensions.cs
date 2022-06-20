using UniNote.Core.Common.Interfaces;

namespace UniNote.Core.Extensions;

public static class ListExtensions
{
    /// <summary>
    /// Applies DTO list to DAO list
    /// </summary>
    /// <param name="daoList">To apply changes to</param>
    /// <param name="dtoList">To apply changes from</param>
    /// <param name="updateStrategy">Strategy to update elements with same Id. First param is DAO (where we apply changes), second is DTO (from where we apply changes)</param>
    /// <param name="addStrategy">Strategy to add new elements with</param>
    /// <param name="equalsFunc">If dao and dto are equal</param>
    /// <param name="isDtoNewFunc">If dto is new</param>
    /// <param name="toRemove">Will items be removed or not</param>
    public static void Merge<T2, TDto2>(this List<T2> daoList, List<TDto2> dtoList, Action<T2, TDto2> updateStrategy,
        Func<TDto2, T2> addStrategy, Func<T2, TDto2, bool> equalsFunc, Func<TDto2, bool> isDtoNewFunc,
        bool toRemove = true)
        where T2 : IWithId<int>
    {
        // removing
        if (toRemove)
            daoList.RemoveAll(x => dtoList.All(y => !equalsFunc(x, y)));

        // updating (called before add because added entities have id=0)
        daoList.ForEach(x =>
        {
            var dtoItem = dtoList.FirstOrDefault(y => equalsFunc(x, y));
            if (dtoItem != null) updateStrategy(x, dtoItem);
        });
        // adding new
        daoList.AddRange(dtoList.Where(isDtoNewFunc).Select(addStrategy));
    }
}