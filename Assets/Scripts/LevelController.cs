using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float waitToLoad = 4f;
    int numberOfAttackers = 0;
    public bool levelTimerFinished = false;
    
    // Start is called before the first frame update
    void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (levelTimerFinished && numberOfAttackers == 0 && !FindObjectOfType<Attacker>())
        {
            StartCoroutine(HandleWinCondition());
        }          
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    private void StopSpawners()
    {
        foreach (AttackerSpawner spawner in FindObjectsOfType<AttackerSpawner>())
        {
            spawner.StopSpawning();
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);

        float currentMusicVolume = PlayerPrefsController.GetMasterVolume();
        PlayerPrefsController.SetMasterVolume(0f);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);

        PlayerPrefsController.SetMasterVolume(currentMusicVolume);
        FindObjectOfType<Level>().LoadNextScene();
    }
}
