using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamegeDetection : MonoBehaviour {

    [Range(0, 10)] public int spikeDamage;
    private GameObject player;

    public int damage;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Spikes")) {
            player.GetComponent<PlayerStats>().takeDamage(damage);
        }
    }
}
