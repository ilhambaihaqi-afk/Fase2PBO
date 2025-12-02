using UnityEngine;

public class ZombieVision : MonoBehaviour
{
    public float visionRange = 5f;

    void Update()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 1f, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, visionRange))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Zombie melihat player!");
            }
        }
    }
}