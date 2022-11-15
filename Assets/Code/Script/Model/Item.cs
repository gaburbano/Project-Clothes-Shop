using UnityEngine;

[System.Serializable]
public class Item
{
    public int id;
    
    public bool enabled;
    
    public string name;

    public Sprite icon;

    public Item(int id, bool enabled, string name, Sprite icon)
    {
        this.id = id;
        this.enabled = enabled;
        this.name = name;
        this.icon = icon;
    }
}