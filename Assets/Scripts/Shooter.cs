using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, bow;
    List<AttackerSpawner> myLaneSpawner = new List<AttackerSpawner>();
    Animator anim;
    GameObject projectileParent;
    [SerializeField] AudioClip arrowSFX;
    const string PROJECTILE_PARENT_NAME = "Arrows";

    private void Start()
    {
        anim = GetComponent<Animator>();
        SetLaneSpawner();
        CreateProjectileParent();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAttackerInLane())
        {
            anim.SetBool("IsAttacking", true);
        }
        else
        {
            anim.SetBool("IsAttacking", false);
        }

    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (var spawner in spawners)
        {
            bool IsCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;
            if (IsCloseEnough)
            {
                myLaneSpawner.Add(spawner);
            }
        }
    }

    private bool IsAttackerInLane()
    {
        try
        {
            foreach (AttackerSpawner lane in myLaneSpawner)
            {
                if (lane.transform.childCount > 0)
                { 
                    return true;
                }
            }
            return false;
        }
        catch
        {
            return false;
        }          
    }

    public void Fire()
    {
        GameObject Arrow = Instantiate(projectile, bow.transform.position, projectile.transform.rotation) as GameObject;
        AudioSource.PlayClipAtPoint(arrowSFX, Camera.main.transform.position);
        Arrow.transform.parent = projectileParent.transform;
    }

}
