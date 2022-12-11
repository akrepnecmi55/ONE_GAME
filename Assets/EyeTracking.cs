using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTracking : MonoBehaviour
{
    public Vector2 destination;
    public float firstPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = GameObject.Find("Ball").transform.position;
        destination.x = firstPosition+0.050f*(pos.x / (8.54f));
        transform.position = new UnityEngine.Vector2(destination.x, transform.position.y);
        //Debug.Log("destination.x:" + destination.x + "ball.x:" + pos.x);
    }
}
