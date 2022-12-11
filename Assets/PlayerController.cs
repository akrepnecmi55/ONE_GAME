using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode moveUp;
    public KeyCode moveDown;
    public float speed = 25;

    private Rigidbody2D myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float vspd;

        if (Input.GetKey(moveUp))
        {
            vspd = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            vspd = -speed;
        }
        else
        {
            vspd = 0;
        }

        myRigidbody.velocity = new Vector2(0, vspd);
    }
}
