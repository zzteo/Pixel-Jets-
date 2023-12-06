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
    public float scrollSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < 10; x++)
        {
            spawnObstaclePanel();
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(buildingParent.transform.childCount < 10){
            spawnObstaclePanel();
        }

        if(buildingParent.transform.childCount > 0){
            for(int x = 0; x < buildingParent.transform.childCount; x++)
                {
                    buildingParent.transform.GetChild(x).GetComponent<Transform>().position = new Vector3(buildingParent.transform.GetChild(x).GetComponent<Transform>().position.x, buildingParent.transform.GetChild(x).GetComponent<Transform>().position.y - (scrollSpeed * Time.deltaTime), buildingParent.transform.GetChild(x).GetComponent<Transform>().position.z);
                }
        }
        scrollSpeed += 0.003f;
        Debug.Log(scrollSpeed);
    }
    void spawnObstaclePanel(){
        var lastSpawned = Instantiate(buildingSetObj, spawnLocation.position, Quaternion.identity, buildingParent.transform);
        spawnLocation = lastSpawned.GetComponent<buildSetController>().topAttach;
    }
}
