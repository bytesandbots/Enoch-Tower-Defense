using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int amountToSpawn;
    float spawnDistance = 12f;

    public float enemyRate = 6;
    public float nextEnemy = 1;
    public Transform Path;
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        nextEnemy -= Time.deltaTime;

        if (nextEnemy <= 0)
        {
            nextEnemy = enemyRate;


           // Vector3 offset = Random.onUnitSphere;

            //offset.z = 0;

            //offset = offset.normalized * spawnDistance;

            GameObject clone = Instantiate(enemyPrefab, transform.position, transform.rotation);
            clone.GetComponent<EnemyPath>().Path = Path;
            amountToSpawn--;
            if (amountToSpawn <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}