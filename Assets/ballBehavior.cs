using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ballBehavior : MonoBehaviour
{


    public float speed = 5;
    public bool gameStart = false;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {       
    
    }

    void FixedUpdate()
    {
        
    }

    public void moveBall()
    {
        float x = Random.Range(1,2);
        float y = Random.Range(1,2);
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(x*speed, y*speed);
    }
    

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(5f);
    }


    [PunRPC]
    private void OnCollisionEnter2D(Collision2D Collision) 
    {
        if(Collision.gameObject.name == "paddle")
        {
            speed += .25f;
        }

        if(Collision.gameObject.name == "P1WALL")
        {
            gameManager.player2score += 1f;
            placeBallCenter();
            moveBall();
            gameManager.timerReset();
        }

        if(Collision.gameObject.name == "P2WALL")
        {
            gameManager.player1score += 1f;
            placeBallCenter();
            moveBall();
            gameManager.timerReset();
        }

        
    }

    public void placeBallCenter()
    {
        this.gameObject.transform.position = new Vector2(-0.0011932f, 9.8154e-05f);
    }

    public void stopBall()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}