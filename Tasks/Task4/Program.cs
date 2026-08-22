namespace Task4
{
  internal class Program
  {
    static void PrintMenu()
    {
      Console.WriteLine();
      Console.WriteLine("========== Employee Menu ==========");
      Console.WriteLine("1) Add employee");
      Console.WriteLine("2) Update employee name by id");
      Console.WriteLine("3) Delete employee by id");
      Console.WriteLine("4) Search in employees");
      Console.WriteLine("5) Render logs");
      Console.WriteLine("0) Exit");
      Console.Write("Choose an option: ");
    }

    static bool TryReadId(string prompt, out int id)
    {
      Console.Write(prompt);
      if (!int.TryParse(Console.ReadLine(), out id))
      {
        Console.WriteLine("Invalid ID");
        return false;
      }
      return true;
    }

    static bool TryReadDecimal(string prompt, out decimal value)
    {
      Console.Write(prompt);
      if (!decimal.TryParse(Console.ReadLine(), out value))
      {
        Console.WriteLine("Invalid value");
        return false;
      }
      return true;
    }

    static bool TryReadString(string prompt, out string value)
    {
      Console.Write(prompt);
      string? input = Console.ReadLine();
      if (string.IsNullOrWhiteSpace(input))
      {
        Console.WriteLine("Invalid input");
        value = string.Empty;
        return false;
      }
      value = input;
      return true;
    }

    static AskOption? ReadOption()
    {
      bool isValid = Enum.TryParse(Console.ReadLine(), out AskOption option)
                  && Enum.IsDefined(typeof(AskOption), option);

      return isValid ? option : null;
    }

    static void AddEmployee(GenericListManager<Employee> manager)
    {
      if (!TryReadId("Employee ID: ", out int id)) return;

      if (manager.Find(e => e.Id == id) is not null)
      {
        Console.WriteLine($"Employee with ID {id} already exists");
        return;
      }

      if (!TryReadString("Employee Name: ", out string name)) return;
      if (!TryReadDecimal("Employee Salary: ", out decimal salary)) return;

      manager.Add(new Employee { Id = id, Name = name, Salary = salary });
      Console.WriteLine($"Employee '{name}' added");
    }

    static void UpdateEmployeeName(GenericListManager<Employee> manager)
    {
      if (!TryReadId("Employee ID: ", out int id)) return;

      Employee? existing = manager.Find(e => e.Id == id);
      if (existing is null)
      {
        Console.WriteLine($"No employee found with ID {id}");
        return;
      }

      if (!TryReadString("New Name: ", out string newName)) return;

      manager.Edit(
          e => e.Id == id,
          new Employee { Id = existing.Id, Name = newName, Salary = existing.Salary }
      );
      Console.WriteLine($"Employee ID {id} renamed to '{newName}'");
    }

    static void DeleteEmployee(GenericListManager<Employee> manager)
    {
      if (!TryReadId("Employee ID: ", out int id)) return;

      Employee? emp = manager.Find(e => e.Id == id);
      if (emp is null)
      {
        Console.WriteLine($"No employee found with ID {id}");
        return;
      }

      manager.Delete(e => e.Id == id);
      Console.WriteLine($"Employee '{emp.Name}' deleted");
    }

    static void SearchEmployees(GenericListManager<Employee> manager)
    {
      if (!TryReadString("Search: ", out string search)) return;

      List<Employee> results = manager.Where(
          e => e.Name.Contains(search, StringComparison.OrdinalIgnoreCase)
      );

      if (results.Count == 0)
      {
        Console.WriteLine("No employees matched");
        return;
      }

      Console.WriteLine($"Count: {results.Count}");
      foreach (var e in results)
        Console.WriteLine($"  ID: {e.Id,-4} Name: {e.Name,-20} Salary: {e.Salary:C0}");
    }

    static void RenderLogs(GenericListManager<Employee> manager)
    {
      List<string> logs = manager.GetLogs();

      if (logs.Count == 0)
      {
        Console.WriteLine("No logs");
        return;
      }

      foreach (var log in logs)
        Console.WriteLine($"  {log}");
    }

    static void Ask(GenericListManager<Employee> manager)
    {
      bool isRunning = true;

      while (isRunning)
      {
        PrintMenu();

        AskOption? option = ReadOption();
        if (option is null)
        {
          Console.WriteLine("Invalid option");
          continue;
        }

        switch (option)
        {
          case AskOption.AddEmployee: AddEmployee(manager); break;
          case AskOption.UpdateEmployeeName: UpdateEmployeeName(manager); break;
          case AskOption.DeleteEmployee: DeleteEmployee(manager); break;
          case AskOption.SearchEmployees: SearchEmployees(manager); break;
          case AskOption.RenderLogs: RenderLogs(manager); break;
          case AskOption.Exit: isRunning = false; break;
        }
      }
    }

    static void Main(string[] args)
    {
      var employeeManager = new GenericListManager<Employee>();
      Ask(employeeManager);
    }
  }
}