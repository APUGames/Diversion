using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    //Logic for Shack Door, 
    private bool doorisOpen = false;
    private float doorTimer = 0.0f;
    public float doorOpenTime = 3.0f;

    //Door sounds
    public AudioClip doorOpenSound;
    public AudioClip doorShutSound;
    private new AudioSource audio; 

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Timer that automatically shuts door once it's open
        if (doorisOpen)
        {
            doorTimer += Time.deltaTime;
        }
        if(doorTimer > doorOpenTime)
        {
            ShutDoor();
            doorTimer = 0.0f;
        }
    }

    //Collision detection
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "shackDoor" && !doorisOpen)
        {
            OpenDoor();
        }   
    }


    void OpenDoor()
    {
        //Play audio 
        audio.PlayOneShot(doorOpenSound);
        //Set doorIsOpen to true 
        doorisOpen = true;
        //Find the GameObject that has animation 
        GameObject myShack = GameObject.Find("Shack");
        //Play animation
        myShack.GetComponent<Animation>().Play("doorOpen");
    }

    void ShutDoor()
    {
        //Play audio 
        audio.PlayOneShot(doorShutSound);
        //Set doorIsOpen to true 
        doorisOpen = false;
        //Find the GameObject that has animation 
        GameObject myShack = GameObject.Find("Shack");
        //Play animation
        myShack.GetComponent<Animation>().Play("doorShut");
    }

}
