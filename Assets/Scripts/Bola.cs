using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{


    public Rigidbody2D rb2d;
    public BallAudio audiobola;
    public float maxInitialAngle = 0.67f;
    public float moveSpeed = 1f;
    public float maxStartY = 4f;
    public float speedMultiplier = 1.1f;

    private float startX = 0f;



    private void Start() {
     GameManager.instance.onReset += ResetBall;
     GameManager.instance.gameUI.onStartGame += ResetBall;
    }


    private void ResetBall() {
        ResetBallPosition();
        InitialPush();
        
    }

    private void InitialPush(){
   Vector2 dir = Random.value < 0.5f ? Vector2.left : Vector2.right;
        dir.y = Random.Range(-maxInitialAngle, maxInitialAngle);
        rb2d.velocity = dir * moveSpeed;
    }

    private void ResetBallPosition(){

        float posY = Random.Range(-maxStartY, maxStartY);
        Vector2 position = new Vector2(startX, posY);
        transform.position = position;

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Marcador marcador = collision.GetComponent<Marcador>();
        if(marcador ){
        GameManager.instance.MarcadorAnotado(marcador.id);

        }
    } 

   private void OnCollisionEnter2D(Collision2D collision) {

        Raqueta raqueta = collision.collider.GetComponent<Raqueta>();

        if(raqueta){
           audiobola.PlayPaddleSound();
            rb2d.velocity *= speedMultiplier;
        }

         Pared pared = collision.collider.GetComponent<Pared>();

        if(pared){
           audiobola.PlayWallSound();
        }
        
    }
        
    }

