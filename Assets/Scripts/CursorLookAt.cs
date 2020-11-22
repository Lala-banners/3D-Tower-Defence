using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLookAt : MonoBehaviour
{
    public bool showCursor;


    // Start is called before the first frame update
    void Start()
    {
        if(showCursor == false)
        {
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float newRotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X");
        float newRotationX = transform.localEulerAngles.x + Input.GetAxis("Mouse Y");

        gameObject.transform.localEulerAngles = new Vector3(newRotationX, newRotationY);
    }
}
