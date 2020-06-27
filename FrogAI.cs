using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAI : MonoBehaviour
{
    //This is the 'frog' object
    public Rigidbody2D frog;
    public Animator FrogAnimation;
    //This is the player object
    private Transform player;
    
    [Range(1f, 10f)]public float jumpSpeed;
    [Range(1f, 10f)]public float frogMovement;
    [Range(1f, 10f)]public float frogSpeed;

    private bool isJumping = false;
    private bool isOnLeft = true;
    
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        frog = this.gameObject.GetComponent<Rigidbody2D>();

        StartCoroutine(frogController());
    }

    private void LateUpdate() {
        float playerPositionX = player.position.x;
        float frogPositionX = this.frog.position.x;
        float playerEnemyDiference = playerPositionX - frogPositionX;

        if(playerEnemyDiference > 0 && isOnLeft)
            this.flipFrog();
        else if(playerEnemyDiference < 0 && !isOnLeft)
            this.flipFrog();
    }
    void flipFrog() {
        Vector3 frog = this.transform.localScale;
        frog.x *= -1;
        this.transform.localScale = frog;

        this.isOnLeft = !this.isOnLeft;
    }

    void moveFrog() {
        float playerPositionX = player.position.x;
        float frogPositionX = this.frog.position.x;
        float playerEnemyDiference = playerPositionX - frogPositionX;

        Debug.Log(playerEnemyDiference);

        
        if(playerEnemyDiference > 0) 
            frog.velocity = new Vector2(frogPositionX + frogMovement * frogSpeed, jumpSpeed);
        else if (playerEnemyDiference < 0)
            frog.velocity = new Vector2(frogPositionX - frogMovement * frogSpeed, jumpSpeed);

    }

    // move frog in a x secounds interval
    IEnumerator frogController() {
        // Jump animation
        FrogAnimation.SetBool("Jump", true);
        moveFrog();
        // force system to wait x secounds
        yield return new WaitForSeconds(4f);
        // end the animation
        FrogAnimation.SetBool("Jump", false);
        // then get ready for the next loop
        StartCoroutine(frogController());
    }
}


 