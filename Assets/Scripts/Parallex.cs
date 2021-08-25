using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallex : MonoBehaviour
{
    [SerializeField]private float length, startPos;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = cam.transform.position.y  * (1-parallaxEffect);
        float dis = (cam.transform.position.y * parallaxEffect);
        transform.position = new Vector3(transform.position.x, startPos + dis, transform.position.z);
        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;
    }
}
