using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq; //had to add it in otder to use method list<>.Last :)

public class UtilScript : MonoBehaviour
{

public static void GoToScene(string sceneName)
{
   SceneManager.LoadScene(sceneName);
}

}