using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;



public class PlayerController : MonoBehaviour
{
    [Range(0, 100)] public int life;

    public Text DisplayLife;
    void Start() {
        DisplayLife.supportRichText = false;
    }

    void Update() {
        
    }

    public void takeDamage(int damage) {
        this.life -= damage;
    }
    private void LateUpdate() {
        DisplayLife.text = string.Format("Life: {0}", life);
    }
}
