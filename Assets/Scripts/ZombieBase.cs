using UnityEngine;
using UnityEngine.AI;

public class ZombieBase : MonoBehaviour
{
    [Header("Stats Zombie")]
    public int maxHealth = 50;
    public int currentHealth;
    public float attackDamage = 10f;
    public float attackRange = 1.2f;

    [HideInInspector] public NavMeshAgent agent;

    void Awake()
    {
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
    }

    public virtual void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Zombie kena damage: " + amount + " | HP sekarang: " + currentHealth);
        if (currentHealth <= 0) Die();
    }

    protected virtual void Die()
    {
        Debug.Log("Zombie mati!");
        Destroy(gameObject);
    }
}
