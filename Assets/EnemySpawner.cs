using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> spawnLocations;
    private bool canSpawn;
    [SerializeField]
    private GameObject[] Enemy;


    public float spawnRate = 6;

    private float timer = 0;

    private void Start()
    {
        //adding the spawn locations in a list 
       for (int i = 0; i < transform.childCount; i++)
            {
                Transform childTransform = transform.GetChild(i);
                spawnLocations.Add(childTransform);
            }
    }

    private void Update()
    {
        if (canSpawn)
        {
            //randomly instantiates a random enemy at a random spawn Location
            Instantiate(Enemy[Random.Range(0, Enemy.Length)], spawnLocations[Random.Range(0, spawnLocations.Count)].position, Quaternion.identity, this.transform);
            canSpawn = false;
        }

        if (!canSpawn)
        {
            timer += Time.deltaTime;

            if(timer >= spawnRate)
            {
                canSpawn = true;
                timer = 0;
            }
        }
    }
}
