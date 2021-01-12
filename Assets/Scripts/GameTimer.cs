using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our Level timer is in seconds")]
    [SerializeField] float levelTime = 60;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);

        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            Destroy(gameObject);
        }
    }

}
