using UnityEngine;

[System.Serializable]
public class Item
{
    int id;
    
    bool enabled;
    
    string name;

    public Item(int id, bool enabled, string name)
    {
        this.id = id;
        this.enabled = enabled;
        this.name = name;
    }
}