using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] int lives = 10;
    Text livesText;
    
    // Start is called before the first frame update
    void Start()
    {
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void RemoveLive(int amount)
    {
        if (lives > 1)
        {
            lives -= amount;
            UpdateDisplay();
        }
        else
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }

}
