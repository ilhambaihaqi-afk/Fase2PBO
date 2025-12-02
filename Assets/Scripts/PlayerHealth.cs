using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Fungsi buat nurunin HP player
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player terkena damage! Sisa HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player mati!");
        // nanti tambahin animasi death atau restart level
    }
}