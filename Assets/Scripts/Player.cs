using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    [SerializeField] AudioClip gunSFX;
    [SerializeField] GameObject FlarePrefab;

	public Transform playerSpawnPoints; // The parent of the spawn points
	public GameObject landingAreaPrefab;
    private AudioSource audioSource;
    private InnerVoice innerVoice;

	private bool reSpawn = false;
	//private Transform[] spawnPoints;
	private bool lastRespawnToggle = false;
    public Vector3 landingArea;
    [SerializeField] private Timer timer;
    [SerializeField] private Text firstObjective;
    [SerializeField] private Text secongObjective;




    // Use this for initialization
    void Start () {
        Cursor.visible = false;
        
        audioSource = GetComponent<AudioSource>();
        innerVoice = GetComponent<InnerVoice>();
        timer.GetComponent<Text>().enabled = false;
        //spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform> ();
        secongObjective.GetComponent<Text>().enabled = false;


    }
	
	// Update is called once per frame
	void Update () {

        if(!timer.IsTimerPaused())
            UpdateTimerHud();

        ///TODO verify landing area location (colision with trees)
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("key f pressed. droping flare");
            var p = Instantiate(FlarePrefab, this.transform.position, Quaternion.identity);
            p.SetActive(true);
            innerVoice.OnFindClearArea(p.transform.position);

            firstObjective.GetComponent<Text>().text += " - <Done>";
            secongObjective.GetComponent<Text>().enabled = true;
        }
	}

    private void UpdateTimerHud()
    {
        timer.GetComponent<Text>().text = timer.GetTimeLeft();
    }

    public void OnFindClearArea () {
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

    private void OnTriggerEnter(Collider collider)
    {
        var a = collider.GetComponentInChildren<SafeArea>();
        if (a != null)
        {
            timer.GetComponent<Text>().enabled = true;
            timer.StartTimer();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var a = other.GetComponentInChildren<SafeArea>();
        if (a != null)
        {
            timer.GetComponent<Text>().enabled = true;
            timer.StartTimer();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        var a = collider.GetComponentInChildren<SafeArea>();
        if (a != null)
        {
            timer.PauseTimer();
        }
    }
}
