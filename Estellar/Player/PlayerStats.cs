using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public int life;
    public int maxLife;
    public int jetpackBooster;

    public HealthBar healthBar;

    private void Start() {
        healthBar.setHealth(maxLife);
    }
    public void takeDamage(int damage) {
        this.life -= damage;
        healthBar.setHealth(life);
    }
}
