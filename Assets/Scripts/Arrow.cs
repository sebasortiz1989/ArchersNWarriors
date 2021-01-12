using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Range(5f, 10f)] [SerializeField] public float currentSpeed = 5f;
    [SerializeField] float damage = 50f;
    [SerializeField] bool freezer = false;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
            if (freezer)
                Freeze(attacker);
        }
    }

    private void Freeze(Attacker attacker)
    {
        attacker.SetMovementSpeed(attacker.currentSpeed / 3f);
        StartCoroutine(FreezeForTime(attacker));
    }

    IEnumerator FreezeForTime(Attacker attacker)
    {
        yield return new WaitForSeconds(2f);
        attacker.SetMovementSpeed(attacker.currentSpeed * 3f);
    }
}
