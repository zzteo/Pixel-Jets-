using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public ProjectileScript projectileScript;
    public BackgroundScript bgScript;
    public EnemySpawner enemySpawner;
    public obstacleController obstacleController;

    public int enemiesKilled;
    public int enemiesKilledBeforeChangingDifficulty;

    [SerializeField]
    private float PointsPerKill = 100f;

    [SerializeField]
    private TMP_Text _distanceText;

    
    private float distanceTravelled;
    private float localScrollSpeed;

    private void Start()
    {
        projectileScript = FindAnyObjectByType<ProjectileScript>();
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
        obstacleController = FindAnyObjectByType<obstacleController>();
        //bgScript = FindAnyObjectByType<BackgroundScript>(); 
    }

    private void Update()
    {
        localScrollSpeed = obstacleController.scrollSpeed;
        distanceTravelled += ((5 * localScrollSpeed) * Time.deltaTime);

        _distanceText.SetText(Mathf.RoundToInt(distanceTravelled + (enemiesKilled * PointsPerKill)).ToString());


    }
   
}
