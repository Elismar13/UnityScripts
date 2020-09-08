using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght;
    private float startpos;
    private GameObject cam;

    private Transform player;
    public float parallax;
    [Range(0, 100f)] public float replaceBackgroundXAxis;
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        startpos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate() {
        float distance = cam.transform.position.x * parallax;

        transform.position = new Vector3(startpos + distance,
                                        this.transform.position.y,
                                        transform.position.z);

        print(String.Format("{0} - {1} && {2} ", player.position.x, this.transform.position.x,  lenght));
        if(player.position.x - this.transform.position.x >= lenght) {
            this.transform.position = player.position;
        }
    }
}
