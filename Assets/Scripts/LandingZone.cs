using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider collider)
    {

    }

    private void OnTriggerStay(Collider collider)
    {
        //var t = collider.GetComponent<Tree>();
        //if (t)
        //    Debug.Log("AAAA");
    }
}
