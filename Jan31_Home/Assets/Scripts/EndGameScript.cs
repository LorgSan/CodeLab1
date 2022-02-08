using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScript : MonoBehaviour
{

    private static EndGameScript instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        } else
        {
            instance = this;
        }
    }
    public static EndGameScript FindInstance() 
    {
        return instance;
    }

    public Text FinalText;

    public void UpdateEndText(string loserName) //all of this thing for some reason doesn't work and I didn't get a chance to dig into it yet, unfortunately :( 
      {
          Debug.Log(loserName);
          FinalText.text = loserName + "died!";
     }
}
