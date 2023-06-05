using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBehavior : MonoBehaviour
{


    public float speed = 5;
    public bool gameStart = false;

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

    void moveBall()
    {
        float x = Random.Range(1,2);
        float y = Random.Range(1,2);
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(x*speed, y*speed);
    }
    

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(5f);
        moveBall();
        gameStart = true;
    }

    private void OnCollisionEnter2D(Collision2D Collision) 
    {
        if(Collision.gameObject.name == "paddle")
        {
            speed += .25f;
        }
    }
}
