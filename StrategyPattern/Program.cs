using System;
using System.Collections.Generic;

namespace StrategyPattern
{
  interface ISortStrategy
  {
    List<int> Sort(List<int> dataset);
  }

  class BubbleSortStrategy : ISortStrategy
  {
    public List<int> Sort(List<int> dataset)
    {
      Console.WriteLine("Sorting using Bubble Sort !");
      return dataset;
    }
  }

  class QuickSortStrategy : ISortStrategy
  {
    public List<int> Sort(List<int> dataset)
    {
      Console.WriteLine("Sorting using Quick Sort !");
      return dataset;
    }
  }

  class Sorter
  {
    private readonly ISortStrategy mSorter;

    public Sorter(ISortStrategy sorter)
    {
      mSorter = sorter;
    }

    public List<int> Sort(List<int> unSortedList)
    {
      return mSorter.Sort(unSortedList);
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      var unSortedList = new List<int> { 1, 10, 2, 16, 19 };

      var sorter = new Sorter(new QuickSortStrategy());
      sorter.Sort(unSortedList); // // Output : Sorting using Bubble Sort !

      sorter = new Sorter(new QuickSortStrategy());
      sorter.Sort(unSortedList); // // Output : Sorting using Quick Sort !

      Console.ReadLine();
    }
  }
}
