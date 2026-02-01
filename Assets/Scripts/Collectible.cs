using UnityEngine;

public class Collectible : MonoBehaviour
{
    public ItemType itemType;

    public void Collect(PlayerInventory inventory)
    {
        /*if (itemType.ToString() == "Fruta")
        {
            UIItensController.Instance.UpdateFrutasText(inventory.GetItemCount(itemType) + 1);
        }
        inventory.AddItem(itemType);
        Destroy(gameObject);*/

        inventory.AddItem(itemType);

        if (itemType == ItemType.Fruta)
        {
            UIItensController.Instance.UpdateFrutasText(
                inventory.GetItemCount(ItemType.Fruta)
            );
        }
        else if (itemType == ItemType.CuiaLatex)
        {
            UIItensController.Instance.UpdateLatexText(
                inventory.GetItemCount(ItemType.CuiaLatex)
            );
        }

        Destroy(gameObject);

    }
}
