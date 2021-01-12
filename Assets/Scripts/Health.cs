using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            anim.SetTrigger("willDie");
            Destroy(gameObject.GetComponent<Collider2D>());
            if (gameObject.name == "Lizard(Clone)" || gameObject.name == "GraveStone(Clone)" || gameObject.name == "Target(Clone)")
            {
                TriggerDeathVFX();
                DissapearAttacker();
            }    
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) { return; }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1f);
    }

    public void DissapearAttacker()
    {     
        Destroy(gameObject);
    }

    public float GetCurrentHealth()
    {
        return health;
    }

}
