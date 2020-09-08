using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [Range(0, 10f)] public float cameraSmoothness;

    private float followPlayerHeightOffset;
    private Vector3 targetOffset;
    private GameObject player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        targetOffset = this.transform.position - player.transform.position;
        followPlayerHeightOffset = 0;
    }

    void FixedUpdate() {
        bool isJumping = player.GetComponent<Movement>()
                                    .getIsJumping();
        followPlayerHeightOffset = isJumping ? -0.5f : 0;
        targetOffset.y += followPlayerHeightOffset;

        transform.position = Vector3.Lerp(this.transform.position,
                                            player.transform.position+targetOffset,
                                            cameraSmoothness);
        targetOffset.y -= followPlayerHeightOffset;
    }
}
