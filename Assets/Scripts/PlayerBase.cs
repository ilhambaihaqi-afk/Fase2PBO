using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [Header("Stats Player")]
    public int maxHealth = 100;
    public int currentHealth;
    public float moveSpeed = 3f;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    // Fungsi menerima damage
    public virtual void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player kena damage: " + amount + " | HP sekarang: " + currentHealth);
        if (currentHealth <= 0) Die();
    }

    // Fungsi mati player
    protected virtual void Die()
    {
        Debug.Log("Player mati!");
        // nanti bisa ditambah respawn / game over
    }
}