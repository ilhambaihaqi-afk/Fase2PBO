using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public NavMeshAgent agent;         // Komponen NavMeshAgent
    public Transform player;           // Target player
    public float attackRange = 1.2f;   // Jarak serang
    public int damage = 10;            // Damage ke player
    public float attackCooldown = 1.2f; // Waktu cooldown serang

    private float nextAttackTime = 0f;

    void Start()
    {
        // Ambil NavMeshAgent dari zombie
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("ZombieAI: NavMeshAgent belum ditambahkan!");
        }

        // Cari player otomatis jika belum di-set
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogError("ZombieAI: Player dengan tag 'Player' tidak ditemukan!");
            }
        }
    }

    void Update()
    {
        // Jika player atau agent belum siap, hentikan update
        if (player == null || agent == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        // Zombie ngejar player
        agent.SetDestination(player.position);

        // Jika jarak dekat, serang player
        if (distance <= attackRange)
        {
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        // Cek cooldown
        if (Time.time < nextAttackTime) return;

        nextAttackTime = Time.time + attackCooldown;

        Debug.Log("Zombie nyerang! Player kena hit.");

        PlayerHealth playerHP = player.GetComponent<PlayerHealth>();
        if (playerHP != null)
        {
            playerHP.TakeDamage(damage);
        }
    }
}