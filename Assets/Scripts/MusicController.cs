using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicController : MonoBehaviour {

    public GameObject electronic;
   
    bool donne = false;

    private void FixedUpdate()
    {
        if (ScrEnemyManager.sfurerAlive && !donne)
            {
                ChangeMusic();  
            }
    }
    public void ChangeMusic()
    {
        electronic.GetComponent<AudioSource>().Stop();
    }
}
