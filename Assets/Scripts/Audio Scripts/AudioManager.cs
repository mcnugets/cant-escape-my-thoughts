using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] footsteps;
    public AudioClip doorAudioClip;
    public GameObject player;
    private bool oneTime;
    
  
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        oneTime = false;



    }
    private void playerWalk()
    {

        System.Random rnd = new System.Random();
        int getrnd = rnd.Next(0, footsteps.Length - 1);
        
       
        AudioSource walkSound = player.GetComponent<AudioSource>();
        walkSound.volume = 0.04f;
        AudioClip oneStep = footsteps[getrnd];

        timer += Time.deltaTime / 1.3f;
       
        if (timer > 0.5f)
        {
            
            walkSound.PlayOneShot(oneStep);
            timer = 0;
           

        }
      

    }
    
    private void doorManager() 
    {
     
        List<GameObject> theDoors = gameObject.GetComponent<useItemManager>().theDoors;
        for (int i = 0; i < theDoors.Count; i++)
        {
            
            GameObject Door = theDoors[i];
            door doorTrigger = Door.GetComponent<door>();
            AudioSource doorAudioSource = Door.GetComponent<AudioSource>();
            if (doorTrigger.inTrigger)
            {


                if (doorTrigger.Open && !doorTrigger.Close)
                {

                    if (!oneTime)
                    {
                        oneTime = true;
                        doorAudioSource.volume = 0.2f;
                        doorAudioSource.PlayOneShot(doorAudioClip);


                    }
                }
                if (!doorTrigger.Open && doorTrigger.Close) oneTime = false;

            }

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        charController charC = player.GetComponent<charController>();
        if (charC.isWalking)
            playerWalk();
        
       doorManager();
        
        
       

    }
}
