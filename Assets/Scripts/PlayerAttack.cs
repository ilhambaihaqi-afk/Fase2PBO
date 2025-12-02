using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public float attackRange = 1.5f;     // Jarak serangan
    public float attackCooldown = 0.5f;  // Waktu jeda antara serangan
    public int damage = 10;              // Damage ke zombie

    private float nextAttackTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void Attack()
    {
        Debug.Log("Player menyerang!");

        Vector3 rayOrigin = transform.position + Vector3.up * 0.5f;
        Ray ray = new Ray(rayOrigin, transform.forward);

        Debug.DrawRay(rayOrigin, transform.forward * attackRange, Color.red, 0.3f);

        if (Physics.Raycast(ray, out RaycastHit hit, attackRange))
        {
            if (hit.collider.CompareTag("Zombie"))
            {
                Debug.Log("Zombie terkena serangan!");

                // panggil TakeDamage di ZombieHealth
                ZombieHealth zombieHP = hit.collider.GetComponent<ZombieHealth>();
                if (zombieHP != null)
                {
                    zombieHP.TakeDamage(damage);
                }
            }
        }
    }
}