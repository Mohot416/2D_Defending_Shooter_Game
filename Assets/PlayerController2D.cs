using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    private Rigidbody2D player;
    private float moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //FixedUpdate is good at dealing with physic aspect
    private void FixedUpdate()
    {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");

        Vector2 playerMove = new Vector2(H, V);
        player.AddForce(playerMove * moveSpeed);
    }
}
