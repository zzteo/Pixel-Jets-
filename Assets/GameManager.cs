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
    public float PointsPerKill = 100f;

    [SerializeField]
    private TMP_Text distanceText;

    
    public float distanceTravelled;
    private float localScrollSpeed;
    public int score;
    public int highScoreSave = 100;
    
    private void Start()
    {
        projectileScript = FindAnyObjectByType<ProjectileScript>();
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
        obstacleController = FindAnyObjectByType<obstacleController>();
         
    }

    private void Update()
    {
        localScrollSpeed = obstacleController.scrollSpeed;
        distanceTravelled += ((5 * localScrollSpeed) * Time.deltaTime);
        score = Mathf.RoundToInt(distanceTravelled + (enemiesKilled * PointsPerKill));
        distanceText.SetText(score.ToString());
        if (score > highScoreSave)
        {
            highScoreSave = score;
        }

    }
   
}
