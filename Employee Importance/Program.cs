using System;
using System.Collections.Generic;

namespace Employee_Importance
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
  }


  // Definition for Employee.
  public class Employee
  {
    public int id;
    public int importance;
    public IList<int> subordinates;
  }


  class Solution
  {
    public int GetImportance(IList<Employee> employees, int id)
    {
      Dictionary<int, Employee> adj = new Dictionary<int, Employee>();
      HashSet<int> visited = new HashSet<int>();
      foreach (var employee in employees)
      {
        if (!adj.ContainsKey(employee.id))
        {
          adj[employee.id] = employee;
        }
      }

      int total = 0;
      void Dfs(int id)
      {
        var employee = adj[id];
        total += employee.importance;
        visited.Add(id);
        foreach (var emp in employee.subordinates)
        {
          if (!visited.Contains(emp))
          {
            Dfs(emp);
          }
        }
      }
      Dfs(id);
      return total;
    }
  }
}
