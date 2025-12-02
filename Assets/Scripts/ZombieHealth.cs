using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int maxHealth = 50;          // HP maksimal zombie
    [HideInInspector] public int currentHealth; // HP saat ini

    void Start()
    {
        currentHealth = maxHealth;      // set HP awal
    }

    // Fungsi dipanggil saat zombie kena damage
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(gameObject.name + " kena damage: " + amount);

        // Cek apakah HP habis
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Fungsi mati zombie
    void Die()
    {
        Debug.Log(gameObject.name + " mati!");
        Destroy(gameObject); // hapus zombie dari scene
    }
}