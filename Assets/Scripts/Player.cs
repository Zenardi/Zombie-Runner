using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

    [SerializeField] AudioClip gunSFX;

	public Transform playerSpawnPoints; // The parent of the spawn points
	public GameObject landingAreaPrefab;
    private AudioSource audioSource;

	private bool reSpawn = false;
	//private Transform[] spawnPoints;
	private bool lastRespawnToggle = false;
    public Vector3 landingArea;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
		//spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (lastRespawnToggle != reSpawn) {
			Respawn ();
			reSpawn = false;
		} else {
			lastRespawnToggle = reSpawn;
		}
	}

	private void Respawn() {
		//int i = UnityEngine.Random.Range (1, spawnPoints.Length);
		//transform.position = spawnPoints [i].transform.position;
	}

	void OnFindClearArea () {
		//Invoke ("DropFlare", 3f);
        StartCoroutine(DropFlare());
	}

    private IEnumerator DropFlare()
    {
        landingArea = transform.position;
        Instantiate(landingAreaPrefab, transform.position, transform.rotation);
        yield return new WaitForEndOfFrame();
    }

    public Vector3 GetLandingAreaLocation()
    {
        return landingArea;
    }

    public void PlayGunSound()
    {
        audioSource.PlayOneShot(gunSFX);
    }

}
