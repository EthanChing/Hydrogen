﻿using UnityEngine;
using System.Collections;
using NewtonVR;

/// <summary>
/// This will eventually be turned into an abstract class;
/// This repreesents all guns that the user must insert the projectile
/// into the weapon and then it is automatically engaged
/// </summary>

public class Cannon : NVRInteractableItem
{
    public GameObject ammoPrefab;
    public GameObject firePoint;

    private bool _currentlyLoaded;

    //Properties below
    //Checks if object is within cannon's trigger; 
    public bool isEngaged
    {
        get { return _currentlyLoaded; }
        set { _currentlyLoaded = value; }
    }


    void OnTriggerEnter(Collider hit)
    {
        //if it is the proper bullet type
        if (hit.gameObject.tag == "CannonBullet")
        {
            isEngaged = true;

        }
    }

    //Methods below

    public override void UseButtonDown()
    {
        base.UseButtonDown();
        shootCannon();
    }

    void shootCannon()
    {
        if (isEngaged)
        {
            GameObject ammo = Instantiate(ammoPrefab);
            ammo.transform.position = firePoint.transform.position;
            ammo.transform.rotation = firePoint.transform.rotation;
            ammo.GetComponent<Bullet>().addForce();
            isEngaged = false;
        }

        else Debug.Log("no  ammo");
    }
    
}