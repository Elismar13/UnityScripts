using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    private GameObject player;
    private Collider2D[] colliders;
    public Animator FrogAnimation;

    private bool isAlive = true;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
    }

    void Update() {
        
    }

    private void LateUpdate() {

    }
}
