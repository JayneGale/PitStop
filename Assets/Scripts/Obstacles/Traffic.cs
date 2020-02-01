using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Left,
    Right
}

public class Traffic : MonoBehaviour
{
    public float speed;
    public Direction _dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (_dir)
        {
            case Direction.Left:
                transform.localPosition -= new Vector3(speed * Time.deltaTime, 0, 0);
                break;
            case Direction.Right:
                transform.localPosition += new Vector3(speed * Time.deltaTime, 0, 0);
                break;
        }
    }
}
