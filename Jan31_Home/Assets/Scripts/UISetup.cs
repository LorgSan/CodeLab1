using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //had to add it in otder to use method list<>.Last :)
using UnityEngine.UI;

public class UISetup : MonoBehaviour
{
    public GameObject healthSprite; //sprite used to represent health
    float spriteWidth; //width of the sprite used for representing health
    public float gapValue = 0.1f; //the initial gap between the health sprites
    float spriteSeperator; //connects spriteWidth and gapValue togeteher;
    int heartsCreated = 0; //counter of hearts created to run an if statement a given amount of times
    int health; //privately used varialbe that inherits from player's setup health
    public List<GameObject> healthList = new List<GameObject>();

    public Text Name;

    // Start is called before the first frame update
    void Start()
    {
        health = gameObject.GetComponent<PlayerSetup>().health; //inherit the health value from player setup
        spriteWidth = healthSprite.GetComponent<SpriteRenderer>().bounds.size.x; //finding the width of the sprite
        spriteSeperator = spriteWidth + gapValue; //connecting them!

        HealthStater(); //call a repeating function

        Name.text = PlayerPrefs.GetString("PlayerNameKey", "Unnamed"); //inherit the name from the player prefs! that were set in the previous scene
        //next time I'll try to allow the player change it in the pause menu or smth
    }

    void HealthStater() //function that creates the hearts in the beginning of the game (theoretically can be remade to refill them at any point in time)
    {
       if (heartsCreated < health) //it's not <= bc otherwise it was creating 1 additional heart and I'm not sure why
        {
            heartsCreated ++; //right away add the value to the checking variable
            GameObject HeartCreated = Instantiate(healthSprite); //we draw the sprite
            healthList.Add(HeartCreated); //I'm adding it all to a list after the initial creation to have a handle on already created object
            // initially I wanted to draw a list as a whole afterwards, didn't find a right solution, so we're here
            HealthStater(); //call it again until we've created all the hearts
            
        }
    }

    // Update is called once per frame
    void Update() //we're moving our hearts along with the player body
    {
        Vector3 PlayerPos = gameObject.transform.position; //player's position variable

        Name.transform.position = new Vector3( //changing the position of the name
                                              PlayerPos.x,
                                              PlayerPos.y - 1.7f,
                                              0f);

        foreach (var Heart in healthList)
        {
            Heart.transform.position = new Vector3(
                                            PlayerPos.x + (spriteSeperator * healthList.IndexOf(Heart)) - ((spriteSeperator*(healthList.Count-1))/2),
                                            //we take player's position 
                                            //and separate each object depending on its number in the list and center it along all hearts in the list (-1 bc the last heart has spriteSeperator too
                                            PlayerPos.y - 0.9f, //same with y (but mostly for the sake of positioning is with the player, mb I should make a private variable to not ask another component each time)
                                            0f);
        }
    }

    public void UpdateHealth(GameObject Player, int value, bool isDamaged) 
    {
    if (isDamaged == true) //if the object was damaged we dsubtract the amount of health
    {
        GameObject heartToDelete = healthList.Last();
        healthList.Remove(heartToDelete);
        Destroy(heartToDelete);
        Player.GetComponent<PlayerSetup>().health -= value; //I've realised that this value doesn't mean anything cause I can't fire the destroy() and remove depending on the value
        //but is something that I'm gonna figure out in the future
        //inititally this code was in the other script, so this reference is still here, but I was thinking of moving it again so left 
    } else
    { //for the plus we're basically doing the same thing we were doing in the stater no difference
        heartsCreated ++;
        GameObject HeartCreated = Instantiate(healthSprite);
        healthList.Add(HeartCreated);
        Player.GetComponent<PlayerSetup>().health += value;
    }
    }
}
