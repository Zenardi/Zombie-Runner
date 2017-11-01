using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    float timeLeft = 15f;
    bool pause = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!pause)
        {
            timeLeft -= Time.deltaTime;
            Debug.Log("time left = " + timeLeft.ToString());
            if (timeLeft < 0)
            {
                timeLeft = 0;
                //Win!
            }
        }
    }

    public void StartTimer()
    {
        pause = false;
    }

    public void PauseTimer()
    {
        pause = true;
    }

    public string GetTimeLeft()
    {
        return timeLeft.ToString("n2");
    }

    public bool IsTimerPaused()
    {
        return pause;
    }
}
