using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;

    public Vector2 Margin, Smoothing;

    public BoxCollider2D Bounds;

    public Vector3 _min, _max;


    public bool isFollowing { get; set; }

    public void Start()
    {
        _min = Bounds.bounds.min;
        _max = Bounds.bounds.max;
        isFollowing = true;
        FindObjectOfType<AudioManager>().Play("menusound");
    }

    public void Update()
    {
        var x = transform.position.y;
        var y = transform.position.x;

        if (isFollowing)
        {
            if(Mathf.Abs(x - Player.position.x) > Margin.x)
            {
                Debug.Log("Were in here X");
                x = Mathf.Lerp(x, Player.position.x, Smoothing.x * Time.deltaTime);
            }
            if(Mathf.Abs(y - Player.position.y) > Margin.y)
            {
                Debug.Log("Were in here Y");
                y = Mathf.Lerp(y, Player.position.y, Smoothing.y * Time.deltaTime);
            }
        }
        var orthSize = GetComponent<Camera>().orthographicSize;
        var cameraHalfWidth = orthSize * ((float)Screen.width / Screen.height);
        Debug.Log("Orthsize = " + cameraHalfWidth);
        x = Mathf.Clamp(x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
        y = Mathf.Clamp(y, _min.y + orthSize, _max.y - orthSize);

        transform.position = new Vector3(x, y, transform.position.z);
    }

}
