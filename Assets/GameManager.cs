using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private ProjectileScript projectileScript;
    [SerializeField]
    private int _enemiesKilledBeforeChangingDifficulty;

    [SerializeField]
    private TMP_Text _distanceText;

    [SerializeField]
    private float _distanceTravelled;
    private void Start()
    {
        projectileScript = FindAnyObjectByType<ProjectileScript>();
    }

    private void Update()
    {
        _distanceTravelled += (10 * Time.deltaTime);

        _distanceText.SetText("Distance: " + Mathf.RoundToInt(_distanceTravelled).ToString());
    }
    /*    private void Update()
        {
            if(projectileScript.enemiesKilled >= _enemiesKilledBeforeChangingDifficulty)
            {
                projectileScript.enemiesKilled = 0; 

                //increase level dificulty 
                //increase background speed
                //increase enemy speed 
            }
        }*/

   
}
