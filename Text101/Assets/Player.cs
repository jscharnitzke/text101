using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Player", menuName = "Text101/Player", order = 0)]
public class Player : ScriptableObject
{
    private List<string> inventory;

    public Player()
    {
        this.inventory = new List<string>();
    }

    public bool inventoryContains(string itemName)
    {
        return this.inventory.Contains(itemName);
    }

    public List<string> getInventory()
    {
        return this.inventory;
    }

    public void addToInventory(string itemName)
    {
        this.inventory.Add(itemName);
    }

    public void removeFromInventory(string itemName)
    {
        this.inventory.Remove(itemName);
    }
}
