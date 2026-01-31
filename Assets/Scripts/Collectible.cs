using UnityEngine;

public class Collectible : MonoBehaviour
{
    public ItemType itemType;

    public void Collect(PlayerInventory inventory)
    {
        inventory.AddItem(itemType);
        Destroy(gameObject);
    }
}
