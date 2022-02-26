using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneScript : MonoBehaviour
{

    public string SceneName;

    // Start is called before the first frame update

    public void SetName(Text Name)
    {
        PlayerPrefs.SetString("PlayerNameKey", Name.text);
        Debug.Log(PlayerPrefs.GetString("PlayerNameKey"));
        UtilScript.GoToScene(SceneName);
    }
}
