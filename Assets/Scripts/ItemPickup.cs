using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Item diambil!");
                Destroy(gameObject);
            }
        }
    }
}
