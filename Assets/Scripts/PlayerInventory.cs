using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //private HashSet<ItemType> items = new HashSet<ItemType>();

    private Dictionary<ItemType, int> items = new Dictionary<ItemType, int>();


    public void AddItem(ItemType item)
    {
        //items.Add(item);
        // Debug.Log("Pegou: " + item);

        if (items.ContainsKey(item))
            items[item]++;
        else
            items[item] = 1;

        Debug.Log($"Pegou: {item} | Total: {items[item]}");
    }

    /*public bool HasItem(ItemType item)
    {
        return items.Contains(item);
    }*/

    public int GetItemCount(ItemType item)
    {
        if (items.TryGetValue(item, out int count))
            return count;

        return 0;
    }

    public bool HasItem(ItemType item)
    {
        return items.ContainsKey(item) && items[item] > 0;
    }

    

}
