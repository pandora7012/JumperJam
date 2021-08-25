using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DATA", menuName = "CREATE/DATA", order = 1)]

public class DATA : ScriptableObject
{
    public Character[] characters;
    public Map[] maps;
}
[System.Serializable]
public class Character  {
    public Sprite die;
    public Sprite idle;
    public Sprite jump;
    public bool Trigger = false;
    public int cost;
    public int ID; 
}
[System.Serializable]
public class Map
{
    public Sprite layer1;
    public Sprite layer2;
    public Sprite layer3;
    public int ID;
    public Sprite platform;
}

