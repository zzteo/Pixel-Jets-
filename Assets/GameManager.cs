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
    private int previousEnemiesKilled;
    public int enemiesKilledBeforeChangingDifficulty;

    [SerializeField]
    private TMP_Text _distanceText;

    [SerializeField]
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

        _distanceText.SetText("Distance: " + Mathf.RoundToInt(distanceTravelled).ToString());

        if (enemiesKilled - previousEnemiesKilled >= enemiesKilledBeforeChangingDifficulty)
        {
            //call the function to update game difficulty
            //enemySpawner.spawnRate -= 0.3f;
            //increase bg speed
            //increase enemy speed


            //update previousEnemiesKilled to the current value
            previousEnemiesKilled = enemiesKilled;
        }

    }
   
}
