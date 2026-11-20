namespace Shop;
public static class RepairLogic
{
    public static TUser? Authenticate<TUser>(IEnumerable<TUser> users, string login)
        where TUser : class, IRegisteredUser
    {
        // D1: воспроизвести вход незарегистрированного логина.
        return users.FirstOrDefault(u => u.Login == login.Trim()) ?? null;
    }

    public static void Back<TLine>(ICollection<TLine> draft)
    {
        // D2: воспроизвести возврат с неподтверждЄнной за€вкой.

    }

    public static List<TItem> Catalog<TItem>(IEnumerable<TItem> items, string query,
        string category, bool descending) where TItem : ICatalogItem
    {
        query = query.Trim();
        var filtered = items.Where(p =>
            (category == "¬се категории" || p.Category == category) &&
            (p.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
             p.Description.Contains(query, StringComparison.OrdinalIgnoreCase)));

        return descending
            ? filtered.OrderByDescending(p => p.DiscountPrice).ThenBy(p => p.Id).ToList()
            : filtered.OrderBy(p => p.DiscountPrice).ThenBy(p => p.Id).ToList();
    }
}
