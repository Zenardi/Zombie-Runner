using UnityEngine;
using System.Collections;

public class ClearArea : MonoBehaviour {

    [SerializeField]
	public float timeSinceLastTrigger = 0f;
    private Player _player;
	private bool foundClearArea = false;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update () {
        timeSinceLastTrigger += Time.deltaTime;

        if (timeSinceLastTrigger > 2f && Time.realtimeSinceStartup > 10f && !foundClearArea)
        {
            _player.OnFindClearArea();
            Debug.Log("Clear Area Found!");
            //SendMessageUpwards("OnFindClearArea");
            foundClearArea = true;
        }
    }

	void OnTriggerStay () {
        timeSinceLastTrigger = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        timeSinceLastTrigger = 0;
    }

    private void OnTriggerExit(Collider other)
    {
        timeSinceLastTrigger = 0;
    }
}
