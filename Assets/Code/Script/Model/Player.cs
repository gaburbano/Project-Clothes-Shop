using UnityEngine;

[System.Serializable]
public class Player
{
    int id;
    
    bool enabled;
    
    string name;

    public Player(int id, bool enabled, string name)
    {
        this.id = id;
        this.enabled = enabled;
        this.name = name;
    }
}