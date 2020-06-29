using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    [Range(0, 100)] public int life;

    public Text DisplayLife;

    private bool damage = false;
    void Start() {
        DisplayLife.supportRichText = false;
    }

    void Update() {
        
    }

    private void LateUpdate() {
        DisplayLife.text = string.Format("Life: {0}", life);
    }

    //Checking if player collider with the frog
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Frog")) {
            takeDamage(5);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        
    }
    void OnCollisionEnter2D(Collision2D collision) {
        foreach (ContactPoint2D contact in collision.contacts) {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }

    public void takeDamage(int damage) {
        this.life -= damage;
    }
}
