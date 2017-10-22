using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {
	
	private bool called = false;
	private Rigidbody rigidBody;
    private Vector3 flarePos;
    private Player player;
    private float speed = 20f;

    // Use this for initialization
    void Start () {
		rigidBody = GetComponent<Rigidbody> ();
        player = FindObjectOfType<Player>();
	}

    private void Update()
    {
        if(called)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, flarePos, step);
        }
    }

    public void OnDispatchHelicopter (Vector3 flareLocation) {
		Debug.Log ("Helicopter called");
		//rigidBody.velocity = new Vector3 (0,0,50f);
        called = true;
        flarePos = flareLocation;
        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, player.GetLandingAreaLocation(), step);

        //rigidBody.transform.position = player.GetLandingAreaLocation();


    }
}
