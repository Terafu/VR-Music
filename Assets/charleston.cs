using HTC.UnityPlugin.ColliderEvent;
using HTC.UnityPlugin.Utility;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class charleston : MonoBehaviour
    , IColliderEventHoverEnterHandler
{

    AudioSource audio;
    bool playMusic = false;
    tambours script;
    public Material mat1;
    public Material mat2;
    Vector3 posDepart;

    private void Start()
    {
        script = (tambours) GameObject.Find("tambours").GetComponent("tambours");
        audio = GetComponent<AudioSource>();
        audio.Stop();
        posDepart = GetComponentsInChildren<MeshRenderer>()[1].transform.position;
    }

    public void OnColliderEventHoverEnter(ColliderHoverEventData eventData)
    {
        //Debug.Log(8 - script.currentTime % 8);

        if (playMusic)
        {
            playMusic = false;
            audio.Stop();

            GetComponentsInChildren<MeshRenderer>()[1].material.color = mat1.color;
        }

        else
        {
            playMusic = true;
            audio.PlayDelayed(6 - script.currentTime % 6);
            StartCoroutine(colorChange(2));
            //GetComponentsInChildren<MeshRenderer>()[1].material.color = mat2.color;
        }
    }


    IEnumerator colorChange(int mat)
    {
        if (playMusic)
        {
            yield return new WaitForSeconds(0.3f);
            if (mat == 1)
            {
                GetComponentsInChildren<MeshRenderer>()[1].material.color = mat1.color;
                if (6 - script.currentTime % 6 > 0.4f)
                    StartCoroutine(colorChange(2));
                else
                {
                    GetComponentsInChildren<MeshRenderer>()[1].material.color = mat2.color;
                    StartCoroutine(drum_active());
                }
            }

            else
            {
                GetComponentsInChildren<MeshRenderer>()[1].material.color = mat2.color;
                if (6 - script.currentTime % 6 > 0.4f)
                    StartCoroutine(colorChange(1));
                else
                {
                    GetComponentsInChildren<MeshRenderer>()[1].material.color = mat2.color;
                    StartCoroutine(drum_active());
                }
            }
        }
    }

    IEnumerator drum_active()
    {
        while (playMusic)
        {
            yield return new WaitForSeconds(0.3f);
            GetComponentsInChildren<MeshRenderer>()[1].transform.position -= new Vector3(0, 0.01f, 0);
            yield return new WaitForSeconds(0.3f);
            GetComponentsInChildren<MeshRenderer>()[1].transform.position += new Vector3(0, 0.01f, 0);
        }
    }
}