using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleController : MonoBehaviour
{
    [SerializeField]
    private GameObject buildingSetObj;
    
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
        if(this.gameObject.transform.childCount > 0){
            for(int x = 0; x < this.gameObject.transform.childCount; x++)
                {
                    this.gameObject.transform.GetChild(x).GetComponent<Transform>().position = new Vector3(this.gameObject.transform.GetChild(x).GetComponent<Transform>().position.x, this.gameObject.transform.GetChild(x).GetComponent<Transform>().position.y - 0.01f, this.gameObject.transform.GetChild(x).GetComponent<Transform>().position.z);
                }
        }

    }
    void spawnObstaclePanel(){
        Debug.Log("spawn");
        var lastSpawned = Instantiate(buildingSetObj, spawnLocation.position, Quaternion.identity, this.gameObject.transform);
        //spawnedObstaclePanels.Add(Instantiate(buildingSetObj, spawnLocation.position, Quaternion.identity, this.gameObject.transform));
        spawnLocation = lastSpawned.GetComponent<buildSetController>().topAttach;
    }
}
