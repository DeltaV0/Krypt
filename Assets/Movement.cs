using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;

public class Movement : MonoBehaviour
{
    public float movespeed;

    public Transform orient;

    float horizIn;
    float vertiIn;

    Vector3 moveDir;

    public Rigidbody rb;

    public CinemachineImpulseSource impulseSource;

    public GameObject Enemy;

    public int keys;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizIn = Input.GetAxisRaw("Horizontal");
        vertiIn = Input.GetAxisRaw("Vertical");

        //Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        //if(flatVel.magnitude > 5){
        //Vector3 limitedVel = flatVel.normalized * movespeed;
        //rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        //} //else {
           // rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
       // }
    }

    void FixedUpdate()
    {
        moveDir = orient.forward * vertiIn + orient.right * horizIn;
        Vector3 q = Vector3.Lerp(rb.linearVelocity, moveDir.normalized * movespeed * 10f, 0.1f);
        rb.linearVelocity = new Vector3(q.x, rb.linearVelocity.y, q.z);


    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy.SetActive(true);
        impulseSource.GenerateImpulse(new Vector3(0.1f, 0.1f, 0.1f));
        other.transform.gameObject.SetActive(false);
    }
}
