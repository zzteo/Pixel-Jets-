using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public ProjectileScript projectileScript;
    public BackgroundScript bgScript;

    public int enemiesKilled;
    public int enemiesKilledBeforeChangingDifficulty;

    [SerializeField]
    private TMP_Text _distanceText;

    [SerializeField]
    private float distanceTravelled;

    public bool increasedSpeed = false;

    private void Start()
    {
        projectileScript = FindAnyObjectByType<ProjectileScript>();
        //bgScript = FindAnyObjectByType<BackgroundScript>(); 
    }

    private void Update()
    {
        distanceTravelled += (10 * Time.deltaTime);

        _distanceText.SetText("Distance: " + Mathf.RoundToInt(distanceTravelled).ToString());

        if (enemiesKilled == enemiesKilledBeforeChangingDifficulty)
        {
            enemiesKilledBeforeChangingDifficulty = 0;

            if (increasedSpeed == false)
            {

                //bgScript.speed += 0.1f;
                increasedSpeed = true;
            }
            //increase level dificulty 
            //increase background speed
            //increase enemy speed 
        }
    }
   
}
