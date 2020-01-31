using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            float horizonDir = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
            float VerticalDir = Input.GetAxisRaw("Vertical") * Time.deltaTime;
            transform.position += new Vector3(horizonDir * speed, 0, VerticalDir * speed);
        }
    }
}
