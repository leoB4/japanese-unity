using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update is called once per frame
    // For every updae with physic
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime * Input.GetAxis("Vertical"));
        transform.Translate(Vector3.right * speed * Time.fixedDeltaTime * Input.GetAxis("Horizontal"));
     
        // JUMP
        if (Input.GetKeyDown(KeyCode.Space)) {
          GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.VelocityChange);
        }  
    }
}
