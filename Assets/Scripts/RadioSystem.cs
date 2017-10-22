using UnityEngine;
using System.Collections;
using System;

public class RadioSystem : MonoBehaviour {

	public AudioClip initialHeliCall;
	public AudioClip initialCallReply;
    private Vector3 flarePosition;
	private AudioSource audioSource;
    private Helicopter helicopter;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
        helicopter = FindObjectOfType<Helicopter>();
	}
	
	public void OnMakeInitialHeliCall (Vector3 pos) {
		print (name + " OnMakeInitialHeliCall");
		audioSource.clip = initialHeliCall;
		audioSource.Play ();
        flarePosition = pos;
		Invoke ("InitialReply", initialHeliCall.length + 1f);
	}

	void InitialReply () {
		audioSource.clip = initialCallReply;
		audioSource.Play ();

        StartCoroutine(DispathHelicopter());

		//BroadcastMessage ("OnDispatchHelicopter");
	}

    private IEnumerator DispathHelicopter()
    {
        helicopter.OnDispatchHelicopter(flarePosition);

        yield return new WaitForEndOfFrame();
    }
}
