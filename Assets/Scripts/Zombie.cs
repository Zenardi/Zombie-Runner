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

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Bullet>() != null)
        {
            Debug.Log("Wow, a bullet hited me");
            //Play damage anim
            //Update Health
            //Destroy bullet
            Destroy(other.gameObject);

            
        }
    }
}
