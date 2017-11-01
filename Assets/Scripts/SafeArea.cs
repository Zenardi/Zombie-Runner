using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour {

    [SerializeField] float timeToStayNearHelicopter = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        //if (other.GetType() == typeof(Player))
        //{
        //    Debug.Log("StarTimer");

        //}
    }

    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("StarTimer");
        //if (collision.rigidbody.GetComponent<Player>())
        //{
        //    //Start countdown
        //    Debug.Log("StarTimer");
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {

    }





}
