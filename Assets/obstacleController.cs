using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleController : MonoBehaviour
{
    [SerializeField]
    private GameObject buildingSetObj;
    [SerializeField]
    private GameObject buildingParent;
    
    [SerializeField]
    private Transform spawnLocation;
    private List<GameObject> spawnedObstaclePanels;
    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < 10; x++)
        {
            spawnObstaclePanel();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(buildingParent.transform.childCount < 10){
            spawnObstaclePanel();
        }

        if(buildingParent.transform.childCount > 0){
            for(int x = 0; x < buildingParent.transform.childCount; x++)
                {
                    buildingParent.transform.GetChild(x).GetComponent<Transform>().position = new Vector3(buildingParent.transform.GetChild(x).GetComponent<Transform>().position.x, buildingParent.transform.GetChild(x).GetComponent<Transform>().position.y - 0.01f, buildingParent.transform.GetChild(x).GetComponent<Transform>().position.z);
                }
        }

    }
    void spawnObstaclePanel(){
        var lastSpawned = Instantiate(buildingSetObj, spawnLocation.position, Quaternion.identity, buildingParent.transform);
        spawnLocation = lastSpawned.GetComponent<buildSetController>().topAttach;
    }
}
