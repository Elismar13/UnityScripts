using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAI : MonoBehaviour
{
    //This is the 'frog' object
    public Rigidbody2D frog;
    //This is the player object
    public Transform player;

    [Range(0, 10f)]public float jumpSpeed;
    [Range(0, 10f)]public float frogMovement;
    [Range(0, 10f)]public float frogSpeed;

    
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        frog = this.gameObject.GetComponent<Rigidbody2D>();

        StartCoroutine(frogController());
    }

    void moveFrog() {

        float playerPositionX = player.position.x;
        float frogPositionX = this.frog.velocity.x;
        float playerEnemyDiference = playerPositionX - frogPositionX;
        
        //Debug.Log(playerEnemyDiference);

        if(playerEnemyDiference > 0) {
            frog.velocity = new Vector2(frogPositionX + frogMovement * frogSpeed, this.frog.position.y);
        }
        else if (playerEnemyDiference < 0){
            frog.velocity = new Vector2(frogPositionX - frogMovement * frogSpeed, this.frog.position.y);
        }
    }

    // move frog in a x secounds interval
    IEnumerator frogController() {
        moveFrog();

        // force system to wait x secounds
        yield return new WaitForSeconds(1f);
        StartCoroutine(frogController());
    }
}


 