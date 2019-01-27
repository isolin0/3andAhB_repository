using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStarter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		FindObjectOfType<AudioManager>().Stop("intro");
		FindObjectOfType<AudioManager>().Play("music");
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
