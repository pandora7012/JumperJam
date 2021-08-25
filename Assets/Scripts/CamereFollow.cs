using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamereFollow : MonoBehaviour
{
    public GameObject player;
    private float  maxPos;
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 pos = player.transform.position;
        maxPos = Mathf.Max(maxPos, pos.y);
        gameObject.transform.position = new Vector3(0, maxPos, gameObject.transform.position.z);
    }
}
