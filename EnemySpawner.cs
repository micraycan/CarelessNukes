using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawners;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        int rand = Random.Range(0, spawners.Length);

        Instantiate(enemy, spawners[rand].position, Quaternion.identity);
    }
}
