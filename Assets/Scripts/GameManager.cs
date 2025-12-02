using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton supaya bisa diakses dari semua script
    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // biar tetap ada saat pindah scene
        }
        else
        {
            Destroy(gameObject); // jika ada lebih dari satu, hancurkan
        }
    }

    // Contoh fungsi untuk game over
    public void GameOver()
    {
        Debug.Log("Game Over!");
        // Bisa ditambah restart scene, UI, dll
    }
}