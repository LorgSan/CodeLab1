using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float Speed = 0.2f;
    //public KeyCode upKey;
    public KeyCode leftKey;
    //public KeyCode downKey;
    public KeyCode rightKey;

    // Start is called before the first frame update
    void Start() //comment!
    {

    }

    // Update is called once per frame
    void Update()
    {

        //WASD controller!!
        Vector3 newPosition = transform.position;
        //if (Input.GetKey(upKey)) //up movement on W
        //{
        //    newPosition.y += Speed;
        //}
        if (Input.GetKey(leftKey)) //left movement on A
        {
            newPosition.x -= Speed;
        }
        //if (Input.GetKey(downKey)) // down movement on S
        //{
        //    newPosition.y -= Speed;
        //}
        if (Input.GetKey(rightKey)) // right movement on D
        {
            newPosition.x += Speed;
        }

        transform.position = newPosition; //updating the position every time
    }
}