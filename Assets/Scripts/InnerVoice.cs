using UnityEngine;
using System.Collections;

public class InnerVoice : MonoBehaviour {

	public AudioClip whatHappened;
	public AudioClip goodLandingArea;
    private RadioSystem radioSystem;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = whatHappened;
		audioSource.Play ();
        radioSystem = GetComponent<RadioSystem>();
	}
	
	public void OnFindClearArea (Vector3 flarePosition) {
        print (name + " OnFindClearArea");
		audioSource.clip = goodLandingArea;
		audioSource.Play ();

		//Invoke ("CallHeli", goodLandingArea.length + 1f);
        //StartCoroutine(CallHeli());
        radioSystem.OnMakeInitialHeliCall(flarePosition);
    }

	void CallHeli () {
		//SendMessageUpwards ("OnMakeInitialHeliCall");
        //radioSystem.OnMakeInitialHeliCall();

    }

}
