using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

//this link may be useful in making sure the music carries over between scenes
//https://answers.unity.com/questions/11314/audio-or-music-to-continue-playing-between-scene-c.html

/*
 * This script should be applied to the object that you want to collide with to trigger a transition. 
 * For example, if you want to collide with a cube, you should attach this to the cube. Make sure that
 * the collider for the object is set to "IsTrigger".
 * The FPS Controller's RigidBody should be set to IsKinematic as well
 * 
 * 
*/
public class TriggerLevelLoad : MonoBehaviour
{
    public string nextScene;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected");
        if (other.gameObject.tag == "Player"){
            AudioSource sound = this.gameObject.GetComponent<AudioSource>(); //the particular transition music would just be attached to the object it collides with

            if (sound != null && sound.GetComponent<AudioClip>() != null)
            {
                sound.Play();
                Debug.Log("Sound Played");
            }

            //if we want the entire transition music to play before scene changes
            //if (!soundCave.isPlaying){
            //    SceneManager.LoadScene(wellScene);

            //}

            //transition to next scene
            if (!string.IsNullOrEmpty(nextScene))
            {
                Debug.Log("Attemptingt to Load Scene: " + nextScene);
                SceneManager.LoadScene(nextScene);
            }
        }

    }


    //mostly to turn off the music --> not sure if we'll need this
    public void OnTriggerExit(Collider other)
    {

    }




}
