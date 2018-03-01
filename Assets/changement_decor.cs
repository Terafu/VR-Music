using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using HTC.UnityPlugin.ColliderEvent;

public class changement_decor : MonoBehaviour
    , IColliderEventHoverEnterHandler
{

    public VideoPlayer player;
    int videoPlaying = 1;

	// Use this for initialization
	void Start () {
		
	}

    public void OnColliderEventHoverEnter(ColliderHoverEventData eventData)
    {
        if (videoPlaying == 5)
        {
            videoPlaying = 0;
        }

        videoPlaying++;
        player.url = "C:\\Users\\Maxime\\Documents\\GitHub\\VR-Music\\Assets\\Video\\Video"+ videoPlaying + ".mp4";
    }
}
