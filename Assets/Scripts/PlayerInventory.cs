using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private HashSet<ItemType> items = new HashSet<ItemType>();

    public void AddItem(ItemType item)
    {
        items.Add(item);
        Debug.Log("Pegou: " + item);
    }

    public bool HasItem(ItemType item)
    {
        return items.Contains(item);
    }
}
