using UnityEngine;
using System.Collections;
using System;

public class RadioSystem : MonoBehaviour {

	public AudioClip initialHeliCall;
	public AudioClip initialCallReply;

	private AudioSource audioSource;
    private Helicopter helicopter;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
        helicopter = FindObjectOfType<Helicopter>();
	}
	
	void OnMakeInitialHeliCall () {
		print (name + " OnMakeInitialHeliCall");
		audioSource.clip = initialHeliCall;
		audioSource.Play ();
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
        helicopter.OnDispatchHelicopter();

        yield return new WaitForEndOfFrame();
    }
}
