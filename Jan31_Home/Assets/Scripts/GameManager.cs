using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameObject Loser; //thing that remembers who is the loser 
    public static GameObject Winner; //thing that remembers the winner
    public static string loserName;

    //singleton is here!
    private static GameManager instance;
    public static GameManager FindInstance() 
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private int score; //the score is still private though as it just gets updated throughout the game

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }


    public void EndGame(GameObject Loser)
    {
        loserName = Loser.GetComponent<UISetup>().Name.text;
        Debug.Log(loserName);   
        UtilScript.GoToScene("EndScene");
        //var endGameScriptInstance = EndGameScript.FindInstance();
        //Debug.Log(endGameScriptInstance);
        //instance.UpdateEndText(loserName);  
    }
}
