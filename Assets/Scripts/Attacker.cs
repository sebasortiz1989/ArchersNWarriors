using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    //Configuration Parameters
    [Range (0f, 1f)] [SerializeField] public float currentSpeed = 1f;
    GameObject currentTarget;
    [SerializeField] float damage = 10f;
    [SerializeField] int LivesTaken = 1;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
            levelController.AttackerKilled();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
            
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget()
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();

        if (health.GetCurrentHealth() > 0)
        {
            health.DealDamage(damage);
        }
    }

    public int GetLivesTakenByEnemy() { return LivesTaken; }
}
