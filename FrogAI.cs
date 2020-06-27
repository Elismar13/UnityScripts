using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAI : MonoBehaviour
{
    //This is the 'frog' object
    public Rigidbody2D frog;
    //This is the player object
    public Transform player;

    public float jumpSpeed;
    public float movementSpeed;

    

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        frog = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        this.moveFrog();
    }

    void moveFrog() {
        float playerPositionX = player.position.x;
        float frogPositionX = this.frog.velocity.x;
        float playerEnemyDiference = playerPositionX - frogPositionX;
        
        Debug.Log(playerEnemyDiference);

        if(playerEnemyDiference > 0) {
            frog.velocity = new Vector2(frogPositionX + movementSpeed, this.frog.position.y);
        }
        else if (playerEnemyDiference < 0){
            frog.velocity = new Vector2(frogPositionX - movementSpeed, this.frog.position.y);
        }
    }
}
 