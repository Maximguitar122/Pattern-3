using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
class Program
{
  static async System.Threading.Tasks.Task Main()
  {
    List<string> words = new List<string>
{
    "apple", "banana", "orange", "apple", "grape", "banana", "pear"
};

    var newWords = (from word in words
                    select word).Distinct().ToList();

    var sortedWords = newWords.OrderBy(word => word).ToList();

    string searchWord = sortedWords[0];
    int index = sortedWords.BinarySearch(searchWord);
    if (index >= 0)
    {
      Console.WriteLine($"Знайдено слово {searchWord} за індексом {index}");
    }
    else
    {
      Console.WriteLine("Слово не знайдено");
    }
    List<Task> task = new List<Task>();
    task.Add(new Task("Test", 6, "High", "This is a test task"));
    task.Add(new Task("Homework", 8, "Middle", "Importatnt task"));
    task.Add(new Task("Test", 6, "High", "This is a test task"));

    var uniqueTasks = task.Distinct().ToList();
    var sortedTasks = uniqueTasks.OrderBy(task => task).ToList();

    Task searchTasks = new Task("Test", 6, "High", "This is a test task");
    int Index = sortedTasks.BinarySearch(searchTasks);
    if (Index >= 0)
    {
      Console.WriteLine($"Знайдено слово {searchWord} за індексом {index}");
    }
    else
    {
      Console.WriteLine("Слово не знайдено");
    }
    await System.Threading.Tasks.Task.Run(() =>
    {
      foreach (var task in sortedTasks)
      {

        Console.WriteLine(task.Name);

      }

    });
  }

}
class Task : IComparable<Task>
{
  public string Name { get; set; }
  public int DoDate { get; set; }
  public string Preority { get; set; }
  public string Description { get; set; }
  public Task(string name, int doDate, string priority, string description)
  {
    Name = name;
    DoDate = doDate;
    Preority = priority;
    Description = description;
  }
  public override bool Equals(object obj)
  {
    if (obj is Task other)
    {
      return Name == other.Name &&
             DoDate == other.DoDate &&
             Preority == other.Preority &&
             Description == other.Description;
    }
    return false;
  }
  public override int GetHashCode() {
    return HashCode.Combine(Name, DoDate, Preority, Description);
  }

  public  int CompareTo(Task other) {

    return Name.CompareTo(other.Name);
  }


}
