using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orient;

    public float xRot;
    public float yRot;

    public Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Start is called before the first frame update
    void Update()
    {
        //float mousx = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        //float mousy = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRot = camera.eulerAngles.y;
        xRot = camera.eulerAngles.x;

        //xRot = Mathf.Clamp(xRot, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        orient.rotation = Quaternion.Euler(0, yRot, 0);
    }

}
