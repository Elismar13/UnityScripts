using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamegeDetection : MonoBehaviour {

    [Range(0, 10)] public int spikeDamage;
    private GameObject player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Spikes")) {
            print("hero");
            player.GetComponent<PlayerStats>().takeDamage(spikeDamage);
        }
    }
}
