using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    public Transform warpTarget;
    public Transform cameraTarget;

    public Camera camera;

    void OnTriggerEnter2D(Collider2D snake)
    {
        //Screen_Fader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<Screen_Fader>();
        //yield return StartCoroutine (sf.FadeToBlack());
        //yield return StartCoroutine(sf.FadeToClear());


        Vector3 offset = new Vector3(0.0f, 0.0f, 0.0f);

        if(this.gameObject.tag == "North")
        {
            offset = new Vector3(snake.gameObject.transform.position.x - warpTarget.position.x, 0.0f, 0.0f);
        }

        else if (this.gameObject.tag == "South")
        {
            offset = new Vector3(snake.gameObject.transform.position.x - warpTarget.position.x, 0.0f, 0.0f);
        }

        else if (this.gameObject.tag == "East")
        {
            offset = new Vector3(0.0f, snake.gameObject.transform.position.y - warpTarget.position.y, 0.0f);
        }

        else if (this.gameObject.tag == "West")
        {
            offset = new Vector3(0.0f, snake.gameObject.transform.position.y - warpTarget.position.y, 0.0f);
        }

        else if (this.gameObject.tag == "Door")
        {
            offset = new Vector3(0.0f, 0.0f, 0.0f);
        }

        snake.gameObject.transform.position = warpTarget.position + offset;

        camera.transform.position = cameraTarget.position;
    }
}
