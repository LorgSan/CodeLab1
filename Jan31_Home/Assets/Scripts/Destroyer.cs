using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    //this is just a function that delets everything outside of the game borders like instantiated prefabs, so we don't crush!
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidedObject = collision.gameObject; //remember the collided object
        Destroy(collidedObject); //and delete it
    }
}
