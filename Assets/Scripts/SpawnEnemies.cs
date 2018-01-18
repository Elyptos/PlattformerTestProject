using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemy;

    [Range(0.5f, 10f)]
    public float spawnInterval = 2;

    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnInterval)
        {
            Spawn();
            timer = 0;
        }
    }

    void Spawn()
    {
        Vector3 spawnPosition = transform.position;

        //spawnPosition.x = -10 + (Random.value * 20);
        spawnPosition.x = Random.Range(2, 15);

        Instantiate(enemy, spawnPosition, transform.rotation);
    }
}
