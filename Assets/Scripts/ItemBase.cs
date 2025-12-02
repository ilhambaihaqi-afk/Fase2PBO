using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public string itemName = "Item";
    public int value = 1;

    public virtual void PickUp()
    {
        Debug.Log("Mengambil item: " + itemName);
        Destroy(gameObject);
    }
}