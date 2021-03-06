using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    //NOTES: tetap dipakai metode yang lama (bukan factory pattern) karena menyesuaikan dengan preview game pada pendahuluan
    //[SerializeField]
    //MonoBehaviour factory;
    //IFactory Factory { get { return factory as IFactory; } }

    void Start ()
    {
        //Mengeksekusi fungs Spawn setiap beberapa detik sesui dengan nilai spawnTime
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn ()
    {
        //Jika player telah mati maka tidak membuat enemy baru
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        //Mendapatkan nilai random
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        //int spawnEnemy = Random.Range(0, 3);

        //Menduplikasi enemy
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        //Factory.FactoryMethod(spawnEnemy);
    }
}
