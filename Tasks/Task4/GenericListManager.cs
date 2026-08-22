
using System.Data;

namespace Task4
{
  public class GenericListManager<T>          // no () here
  {
    private List<T> items = new();
    private List<string> logs = new();
    private DateTime? lastCreatedAt;
    private DateTime? lastSearchAt;

    public void Add(T item)
    {
      items.Add(item);
      lastCreatedAt = DateTime.Now;
      logs.Add($"New item added at '{lastCreatedAt:yyyy-MM-dd HH:mm:ss}'");
    }

    public void Edit(Func<T, bool> predicate, T updatedItem)
    {
      int index = items.FindIndex(item => predicate(item));
      if (index == -1) return;

      items[index] = updatedItem;
      logs.Add($"Item edited at '{DateTime.Now:yyyy-MM-dd HH:mm:ss}'");
    }

    public void Delete(Func<T, bool> predicate)
    {
      int index = items.FindIndex(item => predicate(item));
      if (index == -1) return;

      items.RemoveAt(index);
      logs.Add($"Item deleted at '{DateTime.Now:yyyy-MM-dd HH:mm:ss}'");
    }

    public T? Find(Func<T, bool> predicate)
    {
      lastSearchAt = DateTime.Now;
      return items.FirstOrDefault(item => predicate(item));
    }

    public List<T> Where(Func<T, bool> predicate)
    {
      lastSearchAt = DateTime.Now;
      return items.Where(predicate).ToList();
    }

    public int GetCount() => items.Count;

    public DateTime? GetLastCreatedAt() => lastCreatedAt;

    public DateTime? GetLastSearchAt() => lastSearchAt;

    public List<string> GetLogs() => logs;
  }


}

