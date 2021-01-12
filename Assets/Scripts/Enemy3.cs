using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Defender>() && !otherObject.GetComponent<GraveStone>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
        else if (otherObject.GetComponent<Defender>() && otherObject.GetComponent<GraveStone>())
        {
            anim.SetTrigger("JumpTrigger");
        }
    }
}
