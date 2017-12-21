using HTC.UnityPlugin.ColliderEvent;
using HTC.UnityPlugin.Utility;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class charleston : MonoBehaviour
    , IColliderEventHoverEnterHandler
{

    AudioSource audio;
    bool playMusic = true;
    tambours script;

    private void Start()
    {
        script = (tambours) GameObject.Find("tambours").GetComponent("tambours");
        audio = GetComponent<AudioSource>();
        audio.Stop();

    }

    public void OnColliderEventHoverEnter(ColliderHoverEventData eventData)
    {
        Debug.Log(8 - script.currentTime % 8);

        if (playMusic)
        {
            playMusic = false;
            audio.Stop();
        }

        else
        {
            playMusic = true;
            audio.PlayDelayed(8 - script.currentTime % 8);
        }
    }
}