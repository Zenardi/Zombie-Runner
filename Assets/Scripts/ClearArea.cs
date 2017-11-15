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

        if (timeSinceLastTrigger > 1f && Time.realtimeSinceStartup > 10f && !foundClearArea)
        {
            _player.OnFindClearArea();
            //SendMessageUpwards("OnFindClearArea");
            foundClearArea = true;
        }
    }

	void OnTriggerStay () {
        timeSinceLastTrigger = 0;
    }
}
