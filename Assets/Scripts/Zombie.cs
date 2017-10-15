using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieRunner.Ammo;

public class Zombie : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void Damage(int gunDamage)
    {
        Debug.Log("Ouch!");
    }
}
