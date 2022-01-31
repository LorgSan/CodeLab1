using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int StartingHealth; //health that we have in the start of the game
    int Health; //actual used health
    public int Score; // score of the diamonds that we find
    public Text TextScore; //text for the score 
    public float Time; // timer
    public GameObject HeartSprite; //prefab of the health sprite of the choise
    float HealthDrawer; // the thing that helps us make some distance between the hearts when we draw them
    int CurrentStateHealth = 1; //this thing also helps with the distance and drawing a presice amount of hearts!
    GameObject HealthDraw; //this object is the filler for the hearts to get in and stay there until I delete them
    public List<GameObject> HeartsCreated = new List<GameObject>(); //I've tried to create a list of the Hearts to easily retrieve created hearts from it?

    // Start is called before the first frame update
    void Start()
    {
        Health = StartingHealth;
        HealthDrawer = HeartSprite.GetComponent<SpriteRenderer>().bounds.size.x; //here we are getting the width of the health sprite chosen
        HealthStater(); //calling for the function that states the health in the beginning of the game
    }

    // Update is called once per frame
    void Update()
    {
        TextScore.text = (Score + " diamonds"); //score on the screen
        if (Health < 1)
        {
            GoToScene("EndScene");
        }

    }

    void HealthStater()
    {
        if (CurrentStateHealth <= StartingHealth) //checking if the amount of hearts we've created is still not more than our actual health
        {
            //Debug.Log(CurrentStateHealth);
            HealthDraw = Instantiate(HeartSprite); //we draw the sprite
            HealthDraw.transform.position = new Vector3(
                                            -9f + ((HealthDrawer + 0.2f) * CurrentStateHealth), //we add the width of the sprite itself with a bit of a tick
                                            4f, //and multiply it by the amount of hearts we've created)
                                            0f);
            CurrentStateHealth++; //saying that we've created one of the hearts
            HeartsCreated.Add(HealthDraw); //we're adding this 
            HealthStater(); //and repeat it all
        }
        //else foreach (var x in HeartsCreated)
        //    {
        //        Debug.Log(x.ToString()); //this is just a debug instance
            }
        //Debug.Log("health is stated");
    public void UpdateHealth()
    {
        GameObject heartToDelete = HeartsCreated.Find(x => x.name == "Heart(Clone)"); //find the first object to have this name in the list and remember i
        HeartsCreated.Remove(heartToDelete); //first remove the found object from the list
        Destroy(heartToDelete); //and destroy it completely
        Health -= 1;
    }
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
