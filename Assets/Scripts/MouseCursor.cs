using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    public static MouseCursor instance;
    [SerializeField] private Camera mainCamera;
    private Rigidbody2D rigidbody;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            rigidbody = GetComponent<Rigidbody2D>();
        }
        else
        {
            Destroy(gameObject);
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.transform.position = mouseWorldPos;
        }
        if (Input.GetMouseButton(0))
        {
            
            rigidbody.velocity = (mouseWorldPos - gameObject.transform.position);
        }
    }
}
