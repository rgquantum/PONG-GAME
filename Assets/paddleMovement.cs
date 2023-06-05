using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class paddleMovement : MonoBehaviourPun
{
    // Start is called before the first frame update

    public float speed = 5;

    public Rigidbody2D rb;
    public Vector2 movement;

    PhotonView view;

    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(view.IsMine)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical"); 
        }
        
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);  
    }

    private void OnCollisionEnter2D(Collision2D paddle) 
    {
        if(paddle.gameObject.name == "Circle")
        {
            speed += 1f;
        }    
    }
}
