using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game
{
    public string fileName;
    
    public DateAndTime dateAndTime;

    public double money;

    public int equipmentCount;
    public List<Item> equipment;
}