using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PrederminedSpawner : MonoBehaviour
{
    public string fileName;
    public float xOffset;
    public float yOffset;

    public IEnumerator LoopCoroutine;
    float waitTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("MyCoroutine");
        {
            //MakeRow(level[i], -i);
            //Invoke("MakeRow(level[i], -i)", 3);
            //LoopCoroutine = MakeRow(level[i], -i);
            //StartCoroutine("LoopCoroutine");
            StartCoroutine("MyCoroutine");
            }

    }

    IEnumerator MyCoroutine()
    {
        StreamReader reader = new StreamReader(fileName);
        string contentOfFile = reader.ReadToEnd();
        reader.Close();

        char[] newLineChar = {'\n'};
        string[] level = contentOfFile.Split(newLineChar);

        for (int i=0; i < level.Length; i++)
        {
            MakeRow(level[i], -i);
            yield return new WaitForSeconds(waitTime);
        }
    }

    //IEnumerator MakeRow(string rowStr, float y)
    public void MakeRow(string rowStr, float y)
    {
        char[] rowArray = rowStr.ToCharArray();
        for (int x=0; x < rowStr.Length; x++)
        {
            char c = rowArray[x];
            if (c == 'F')
            {
                GameObject fireball = Instantiate(Resources.Load("Fireball")) as GameObject;
                fireball.transform.position = new Vector3(
                    x * fireball.transform.localScale.x + xOffset,
                    y * fireball.transform.localScale.y + yOffset,
                    0);
            } 
            
            else if (c == 'D')
            {
                GameObject diamond = Instantiate(Resources.Load("Diamond")) as GameObject;
                diamond.transform.position = new Vector3(
                    x * diamond.transform.localScale.x + xOffset,
                    y * diamond.transform.localScale.y + yOffset,
                    0);
            } 
            
            else if (c == 'H')
            {
                GameObject heart = Instantiate(Resources.Load("Heart")) as GameObject;
                heart.transform.position = new Vector3(
                    x * heart.transform.localScale.x + xOffset,
                    y * heart.transform.localScale.y + yOffset,
                    0);
            }
        }

        //yield return new WaitForSeconds(waitTime);
    }

    void InstantiateObject()
    {

    }
}
