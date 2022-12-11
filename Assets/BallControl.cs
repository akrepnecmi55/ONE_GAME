using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float randomNumber = 0;
    public Rigidbody2D rb2D;
    public Vector2 move;
    public float ballSpeed = 100f;
    public float topSpeed = 0f;
    public float acceleration = 5;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GoBall());
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag == "Player")
        {
            GetComponent<AudioSource>().pitch = Random.Range(0.5f, 1.5f);
            GetComponent<AudioSource>().Play();
            
            if (rb2D.velocity.x > 0)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x + acceleration, rb2D.velocity.y / 2 + col.gameObject.GetComponent<Rigidbody2D>().velocity.y / 3);
            }
            if (rb2D.velocity.x < 0)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x - acceleration, rb2D.velocity.y / 2 + col.gameObject.GetComponent<Rigidbody2D>().velocity.y / 3);
            }
        }
    }

    public IEnumerator GoBall()
    {
        yield return new WaitForSeconds(1);
        float randomNumber = Random.Range(0f, 1f);
        rb2D = GetComponent<Rigidbody2D>();
        if (randomNumber < 0.5)
        {

            rb2D.AddForce(new Vector2(ballSpeed, 10));
        }
        else
        {
            rb2D.AddForce(new Vector2(-1 * ballSpeed, -10));
        }
    }

    public void InitialState()
    {
        // stop the ball from moving
        rb2D.velocity = new UnityEngine.Vector2(0, 0);
        // put the ball back in the middle
        rb2D.position = new UnityEngine.Vector2(0, 0);
        GameManager.InitialStateGM();
        GameManager.setZeroScores();
    }

    public void ResetBall()
    {
        // stop the ball from moving
        rb2D.velocity = new UnityEngine.Vector2(0, 0);
        // put the ball back in the middle
        rb2D.position = new UnityEngine.Vector2(0, 0);
        GameManager.setZeroScores();
        StartCoroutine(GoBall());
    }

    private void Update()
    {
        if (rb2D.velocity.x > 0 && rb2D.velocity.x < 20)
        {
            rb2D.velocity = new Vector2(20f, rb2D.velocity.y);
        }
        else if(rb2D.velocity.x < 0 && rb2D.velocity.x > -20)
        {
            rb2D.velocity = new Vector2(-20f, rb2D.velocity.y);
        }
        else if(rb2D.velocity.x > 0 && rb2D.velocity.x > 100)
        {
            rb2D.velocity = new Vector2(100f, rb2D.velocity.y);
        }
        else if (rb2D.velocity.x < 0 && rb2D.velocity.x < -100)
        {
            rb2D.velocity = new Vector2(-100f, rb2D.velocity.y);
        }
        //Debug.Log("Speed is" + rb2D.velocity);
    }
}
