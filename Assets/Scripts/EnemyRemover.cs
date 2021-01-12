using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRemover : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Destroy(otherCollider.gameObject);
        FindObjectOfType<LivesDisplay>().RemoveLive(otherCollider.GetComponent<Attacker>().GetLivesTakenByEnemy());
    }
}
