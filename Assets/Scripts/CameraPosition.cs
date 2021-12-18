using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//reference for source code: https://generalistprogrammer.com/unity/unity-2d-how-to-make-camera-follow-player/

public class CameraPosition : MonoBehaviour
{
    private Transform player1, player2;
    private float dist;
    private float originalSize = 0f;
    private float maxSize = 5f;

    private void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("player1").GetComponent<PlayerMovement>().transform;
        player2 = GameObject.FindGameObjectWithTag("player2").GetComponent<PlayerMovement>().transform;
        originalSize = GetComponent<Camera>().orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(player1 != null && player2 != null)
        {
            this.transform.position = new Vector3((player1.position.x + player2.position.x)/2, (player1.position.y + player2.position.y)/2, this.transform.position.z);

            // camera zoom - subject to change
            float dist_old = dist;
            dist = Vector2.Distance(player1.position, player2.position);
            
            if( dist > 10f && dist - dist_old >= 0 && GetComponent<Camera>().orthographicSize < maxSize)
            {
                GetComponent<Camera>().orthographicSize +=  dist * 0.0001f;
            } 
            else if( dist > 10f && dist - dist_old < 0 && GetComponent<Camera>().orthographicSize > originalSize)
            {
                GetComponent<Camera>().orthographicSize -= dist * 0.001f;
            } 
            else if( dist <= 10f && GetComponent<Camera>().orthographicSize > originalSize)
            {
                GetComponent<Camera>().orthographicSize -= dist * 0.001f;
            }


        } else { 

            if(player1 != null) { 
                this.transform.position = new Vector3(player1.position.x, player1.position.y, this.transform.position.z);
            }
            else if(player2 != null)
            {
                this.transform.position = new Vector3(player2.position.x, player2.position.y, this.transform.position.z);
            }
            if(GetComponent<Camera>().orthographicSize > originalSize)
            {
                GetComponent<Camera>().orthographicSize -= dist * 0.001f;
            }
        }
    }
}
