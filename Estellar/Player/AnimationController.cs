using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Rigidbody2D player;

    public Animator PlayerAnimation;

    private bool leftMovement = true; 

    private bool isGrounded;

    private bool isJumping;

    void Start() {
        player = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // getting data from Movement class
        isGrounded = player.GetComponent<Movement>().getIsGrounded();
        isJumping = player.GetComponent<Movement>().getIsJumping();

        if (isGrounded) {
            PlayerAnimation.SetBool("isJumping", false);
        }

        if (isJumping) {
            PlayerAnimation.SetBool("isJumping", true);
        }
    }

    private void FixedUpdate() {
        Vector2 velocity = player.velocity;
        if ((velocity.x > 0 && !leftMovement) || (velocity.x < 0 && leftMovement))
            flipPlayer();

        PlayerAnimation.SetFloat("Speed", Mathf.Abs(velocity.x));
    }

    private void flipPlayer( ) {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        this.leftMovement = !this.leftMovement;
    }
}
