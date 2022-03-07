using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raqueta : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public int id;
    public float moveSpeed = 2f; 

    private Vector3 startPosition;


    private void Start() {
        startPosition = transform.position;
        GameManager.instance.onReset += ResetPosition;
    }

    private void ResetPosition() {
        transform.position = startPosition;
    }
    


    public void Update(){
        
        float movement  = ProcessInput();
        Move(movement);

    }

    private float  ProcessInput(){

        float movement = 0f;

        switch(id){
            case 1:
            movement = Input.GetAxis("MovePlayer1");
            break;
            
            case 2:
            movement = Input.GetAxis("MovePlayer2");
            break;
        }


        return movement;

    }

    private void Move(float movement){

        Vector2 velo = rb2d.velocity;
        velo.y = moveSpeed * movement;
        rb2d.velocity = velo;


    }
}
