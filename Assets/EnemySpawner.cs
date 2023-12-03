using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> _spawnLocations;
    private bool _canSpawn;
    [SerializeField]
    private GameObject _Enemy;
    [SerializeField]
    private float _spawnRate;

    private float timer = 0;

    private void Start()
    {
        foreach(Transform spawnLocations in transform.GetComponentsInChildren<Transform>())
        {
            _spawnLocations.Add(spawnLocations);
        }
    }

    private void Update()
    {
        if (_canSpawn)
        {
            var enemy = Instantiate(_Enemy, _spawnLocations[Random.RandomRange(0, _spawnLocations.Count)].position, Quaternion.identity);
            enemy.transform.parent = this.transform;
            _canSpawn = false;
        }

        if (!_canSpawn)
        {
            timer += Time.deltaTime;

            if(timer >= _spawnRate)
            {
                _canSpawn = true;
                timer = 0;
            }
        }
    }
}
