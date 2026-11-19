using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnr : MonoBehaviour
{
    private KillCounter killCounter;
    private ChangeSc changeScene;

    private Rigidbody rb1;
    private Rigidbody rb2;
    private Rigidbody rb3;

    public Transform parentTransform;

    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;

    public GameObject Boss;
    public GameObject bigZombie;
    public GameObject z1;
    public GameObject z2;

    GameObject[] spawns;
    GameObject[] zombies;

    public float spawnInterval = 1.0f;
    public float timeSinceLastSpawn = 0.0f;

    public float spawnInterval1 = 3.0f;
    public float timeSinceLastSpawn1 = 0.0f;

    public float spawnInterval2 = 5.0f;
    public float timeSinceLastSpawn2 = 0.0f;

    void Start()
    {
        spawns = new GameObject[] { s1, s2, s3, s4 };
        zombies = new GameObject[] { z1, z2 };
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            timeSinceLastSpawn = 0.0f;
            spawnInterval = Mathf.Max(1.0f, spawnInterval - 0.05f);
            spawnZombie();
        }

        timeSinceLastSpawn1 += Time.deltaTime;

        if (timeSinceLastSpawn1 >= spawnInterval1)
        {
            timeSinceLastSpawn1 = 0.0f;
            spawnInterval1 = Mathf.Max(4.0f, spawnInterval1 - 0.1f);
            spawnBigZombie();
        }

        timeSinceLastSpawn2 += Time.deltaTime;

        if (timeSinceLastSpawn2 >= spawnInterval2)
        {
            timeSinceLastSpawn2 = 0.0f;
            spawnInterval2 = Mathf.Max(6.5f, spawnInterval2 - 0.2f);
            spawnBoss();
        }
    }

    void spawnZombie()
    {
        int i = Random.Range(0, spawns.Length);
        GameObject spawnPoint = spawns[i];
        int j = Random.Range(0, zombies.Length);
        GameObject sZombie = zombies[j];

        Vector3 spawnPosition = spawnPoint.transform.position;
        spawnPosition.y += sZombie.transform.localScale.y / 2;

        GameObject SpawnedZombie = Instantiate(sZombie, spawnPosition, Quaternion.identity);
        SpawnedZombie.transform.rotation = Quaternion.Euler(0.0f, -180.0f, 0.0f);

        rb1 = SpawnedZombie.GetComponent<Rigidbody>();
        Vector3 movementVector = new Vector3(0.0f, 0.0f, -1.0f);
        rb1.velocity = movementVector;

        if (SpawnedZombie.transform.position.z < -5)
        {
            GameOver();
        }

        Collider zombieCollider = SpawnedZombie.GetComponent<Collider>();
        if (zombieCollider != null && zombieCollider.isTrigger)
        {
            killCounter.IncrementKillCount();
            Destroy(SpawnedZombie);
        }

    }

    void spawnBigZombie()
    {
        int i = Random.Range(0, spawns.Length);
        GameObject spawnPoint = spawns[i];
        GameObject sZombie = bigZombie;
        Vector3 spawnPosition = spawnPoint.transform.position;
        spawnPosition.y += sZombie.transform.localScale.y / 2;

        GameObject SpawnedZombie = Instantiate(sZombie, spawnPosition, Quaternion.identity);
        SpawnedZombie.transform.rotation = Quaternion.Euler(0.0f, -180.0f, 0.0f);

        rb2 = SpawnedZombie.GetComponent<Rigidbody>();
        Vector3 movementVector = new Vector3(0.0f, 0.0f, -0.75f);
        rb2.velocity = movementVector;

        if (SpawnedZombie.transform.position.z < -5)
        {
            GameOver();
        }

        Collider zombieCollider = SpawnedZombie.GetComponent<Collider>();
        int hits = 0;
        if (zombieCollider != null && zombieCollider.isTrigger)
        {
            hits++;
            if(hits==2)
            {
                killCounter.IncrementKillCount();
                Destroy(SpawnedZombie);
            }
        }
    }

    void spawnBoss()
    {
        int i = Random.Range(0, spawns.Length);
        GameObject spawnPoint = spawns[i];
        GameObject sZombie = Boss;
        Vector3 spawnPosition = spawnPoint.transform.position;
        spawnPosition.y += sZombie.transform.localScale.y / 2;

        GameObject SpawnedZombie = Instantiate(sZombie, spawnPosition, Quaternion.identity);
        SpawnedZombie.transform.rotation = Quaternion.Euler(0.0f, -180.0f, 0.0f);

        rb3 = SpawnedZombie.GetComponent<Rigidbody>();
        Vector3 movementVector = new Vector3(0.0f, 0.0f, -0.5f);
        rb3.velocity = movementVector;

        if (SpawnedZombie.transform.position.z < -5)
        {
            GameOver();
        }

        Collider zombieCollider = SpawnedZombie.GetComponent<Collider>();
        int hits = 0;
        //&& zombieCollider.other.CompareTag("bullet")
        if (zombieCollider != null && zombieCollider.isTrigger)
        {
            hits++;
            if (hits == 5)
            {
                killCounter.IncrementKillCount();
                Destroy(SpawnedZombie);
            }
        }
    }

    void GameOver()
    {
        changeScene.ChangeScene("GameOver");
    }
}
