using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    public Transform warpTarget;
    public Transform cameraTarget;

    public Camera camera;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Screen_Fader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<Screen_Fader>();

        //yield return StartCoroutine (sf.FadeToBlack());


        Vector3 offset = new Vector3(0.0f, 0.0f, 0.0f);

        if(other.gameObject.transform.position.x < warpTarget.position.x 
            || other.gameObject.transform.position.x > warpTarget.position.x)
        {
            offset = new Vector3(0.0f, other.gameObject.transform.position.y - warpTarget.position.y, 0.0f);
        }

        if (other.gameObject.transform.position.y < warpTarget.position.y
            || other.gameObject.transform.position.y > warpTarget.position.y)
        {
            offset = new Vector3(other.gameObject.transform.position.x - warpTarget.position.x, 0.0f, 0.0f);
        }

        other.gameObject.transform.position = warpTarget.position + offset;

        camera.transform.position = cameraTarget.position;


        //yield return StartCoroutine(sf.FadeToClear());
    }
}
