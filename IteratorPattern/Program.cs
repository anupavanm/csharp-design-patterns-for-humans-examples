using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorPattern
{
class RadioStation
{
  private float mFrequency;

  public RadioStation(float frequency)
  {
    mFrequency = frequency;
  }

  public float GetFrequecy()
  {
    return mFrequency;
  }

}

class StationList : IEnumerable
{
  private List<RadioStation> mStations;

  public StationList()
  {
    mStations = new List<RadioStation>();
  }

  public void AddStation(RadioStation station)
  {
    mStations.Add(station);
  }

  public void RemoveStation(RadioStation station)
  {
    mStations.Remove(station);
  }

  public IEnumerator GetEnumerator()
  {
    return new StationIterator(mStations);
  }
}

class StationIterator : IEnumerator
{
  private List<RadioStation> mStations;
  private int currentPosition = -1;

  public object Current
  {
    get
    {
      return mStations[currentPosition];
    }
  }

  public StationIterator(List<RadioStation> stations)
  {
    mStations = stations;
  }
  public bool MoveNext()
  {
    if(currentPosition < mStations.Count - 1)
    {
      currentPosition = currentPosition + 1;
      return true;
    }

    return false;
  }

  public void Reset()
  {
    currentPosition = -1;
  }
}

class Program
{
  static void Main(string[] args)
  {
    var stations = new StationList();
    var station1 = new RadioStation(89);
    stations.AddStation(station1);

    var station2 = new RadioStation(101);
    stations.AddStation(station2);

    var station3 = new RadioStation(102);
    stations.AddStation(station3);

    foreach(RadioStation station in stations)
    {
      Console.WriteLine(station.GetFrequecy());
    }

    stations.RemoveStation(station2); // Will Remove station 101

    Console.ReadLine();
  }
}
}
