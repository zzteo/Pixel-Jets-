using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class buildSetController : MonoBehaviour
{
    [SerializeField]
    private GameObject buildingObj;
    [SerializeField]
    private GameObject buildingPositions;
    [SerializeField]
    private List<Transform> _spawnLocations;
    public Transform topAttach;
    // Start is called before the first frame update
    void Start()
    {

        for(int x = 0; x < buildingPositions.transform.childCount; x++)
        {
            _spawnLocations.Add(buildingPositions.transform.GetChild(x).GetComponent<Transform>());

            var temp = UnityEngine.Random.Range(0, 2);
            if (temp >= 1)
            {
                Instantiate(buildingObj, _spawnLocations[x].position, Quaternion.identity, _spawnLocations[x]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
