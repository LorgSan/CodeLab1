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
    public GameManager myManager;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Diamond(Clone)") //if the collided object has such name we add +1 score
        {
            GameObject collidedObject = collision.gameObject; //remember the collided object
            //Debug.Log("Diamond");
            myManager.Score += 1; //add the score in the game manager class
            Destroy(collidedObject); //and destroy it
        }
        if (collision.gameObject.name == "Fireball(Clone)") //if the collided object has such name we -1 health;
        {
            GameObject collidedObject = collision.gameObject; //remember the collided game object!
            myManager.UpdateHealth(); //call the function in the manager
            Destroy(collidedObject); //and destroy it
        }

    }
}