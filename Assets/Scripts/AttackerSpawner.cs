using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    float minSpawnDelay = 18f;
    float maxSpawnDelay = 28f;
    [SerializeField] Attacker[] attackerPrefab;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        float difficulty = PlayerPrefsController.GetDifficultyValue();
        minSpawnDelay = minSpawnDelay - minSpawnDelay * difficulty/5f;
        maxSpawnDelay = maxSpawnDelay - maxSpawnDelay * difficulty/5f;
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttackers();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }
         
    private void SpawnAttackers()
    {
        var attackerIndex = Random.Range(0, attackerPrefab.Length);
        Spawn(attackerPrefab[attackerIndex]);
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate
            (myAttacker, transform.position, transform.rotation)
            as Attacker;
        newAttacker.transform.parent = transform;
    }

}
