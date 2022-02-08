using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    GameManager myManager;

    public int health; //I've decided to leave health public to be able to easily change it through editor to create multiple player with different stats
                        //if we were talking about smth more specific I'd have a class that sets this whole player setup based on, say, a character that the player chosen
                        // it would also may have requiared smth like a structure which I don't know about in the Unity or c# context

    // public int Health
    // {
    //     get
    //     {
    //         return health;
    //     }
    //     set
    //     {
    //         health = value;
    //     }
    // }

    void Start()
    {
        myManager = GameManager.FindInstance(); //accessing the GameManager (this way cause it uses a singletone pattern)
    }

    void Update()
    {
       if (health < 1) //we keep track of health here
        {
            myManager.EndGame(this.gameObject);
            Destroy(this.gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision) //this is a collision manager that sees what type of object has collided with us and what to do wtih it
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
            gameObject.GetComponent<UISetup>().UpdateHealth(this.gameObject, 1, true); //call the function in the manager
            Destroy(collidedObject); //and destroy it
        }
        if (collision.gameObject.name == "HeartFallingObject(Clone)") //if the collided object has such name we +1 health;
        {
            GameObject collidedObject = collision.gameObject; //remember the collided game object!
            gameObject.GetComponent<UISetup>().UpdateHealth(this.gameObject, 1, false); //call the function in the manager
            Destroy(collidedObject); //and destroy it
        }

    }
}
