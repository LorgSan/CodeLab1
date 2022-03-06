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
        myCollider = GetComponent<BoxCollider2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        myManager = GameManager.FindInstance(); //accessing the GameManager (this way cause it uses a singletone pattern)
        TransitionState(State.Normal);
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
            TransitionState(State.Immune);
        }
        if (collision.gameObject.name == "HeartFallingObject(Clone)") //if the collided object has such name we +1 health;
        {
            GameObject collidedObject = collision.gameObject; //remember the collided game object!
            gameObject.GetComponent<UISetup>().UpdateHealth(this.gameObject, 1, false); //call the function in the manager
            Destroy(collidedObject); //and destroy it
        }

    }

    //7mar homework here

    public enum State //stating the all the states we will use
    {
        Normal,
        Immune
    }

    public Color mainColor;
    public Color immuneColor; //we will declare two color parameters to see the difference between states easily
    public SpriteRenderer myRenderer; //and of course the renderer component
    public BoxCollider2D myCollider; //also collider
    public bool isFlickering; //check if we want the sprite to flicker
    public float immunityDuration = 1.5f; //how long the immune state will be

    public State currentState; 

    public void TransitionState(State newState) //the transition state void that is getting triggered from the start and when the player hits the fireball
    //overall it has the same functionality as the class code
    {
        currentState = newState;
        switch (newState)
        {
            case State.Normal: //this is our 'default' state when we exist most of the time
                Debug.Log("normal");
                myRenderer.color = mainColor; //we have our main color on
                myCollider.enabled = true; //and our collider is always on!
                break;
            case State.Immune: //immune state is sort of a 'break' moment after you get hit
                Debug.Log("immune");
                //myRenderer.color = immuneColor;
                myCollider.enabled = !myCollider.enabled; //switch the activity of collider component while we'are immune so we won't hit anything
                isFlickering = true; //activating the flickering effect
                StartCoroutine("Flicker"); //starting it's coroutine 
                StartCoroutine(StateDelay(State.Normal, immunityDuration)); //and now starting the main delay coroutine
                break;
            default:
                Debug.Log("this state doesn't exist");
                break;
        }
    }

     IEnumerator StateDelay(State nextState, float timeToWait) //this coroutine counts time of the whole immune system state, how long should it be
     {
        Debug.Log("in coroutine!");
        yield return new WaitForSeconds(timeToWait); //we wait for the given amount of time
        TransitionState(nextState); //and get ourselves into the state we need to go to
        StopCoroutine("Flicker"); //also stop the flickering effect coroutine! 
        isFlickering = false; //I think these two lines make the code more hardcoded, but I didn't figure out where I can put this stuff to make it work properly
     }

       public IEnumerator Flicker() //the flickering effect state!
      {
          while (isFlickering == true) //while this is true we just go between two colors (the immune color has A of 0, so it looks like it kinda disappers)
        {
             myRenderer.color = immuneColor;
             yield return new WaitForSeconds(0.08f);
             myRenderer.color = mainColor;
             yield return new WaitForSeconds(0.05f);
        }
     }
}
