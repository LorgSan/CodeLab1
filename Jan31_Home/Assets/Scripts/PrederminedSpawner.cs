using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PrederminedSpawner : MonoBehaviour
{
    public string fileName;
    public float xOffset;
    //public float yOffset;

    //public IEnumerator LoopCoroutine; 
    public float waitTime = 2; // this is a pause between two objects falling

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

    IEnumerator MyCoroutine() //here we have a coroutine that triggers the MakeRow void with a pause (waitTime)
    {
        StreamReader reader = new StreamReader(fileName); //we read the file
        string contentOfFile = reader.ReadToEnd(); //read all of it and save it to the var
        reader.Close();

        char[] newLineChar = {'\n'}; //this is a invisible symbol in text documenta that basically reads the new line
        string[] level = contentOfFile.Split(newLineChar); //we're creating the array of each line in the text, splitting them with the invisible symbol saved before

        for (int i=0; i < level.Length; i++)
        {
            MakeRow(level[i], -i); //trigger the makerow for each line
            yield return new WaitForSeconds(waitTime); //placing yield return in for loop bc we want only this part to trigger
        }
    }

    //IEnumerator MakeRow(string rowStr, float y)
    public void MakeRow(string rowStr, float y) //this whole thing is basically what we did in class
    {
        char[] rowArray = rowStr.ToCharArray();
        for (int x=0; x < rowStr.Length; x++)
        {
            char c = rowArray[x];
            if (c == 'F')
            {
                GameObject fireball = Instantiate(Resources.Load("Fireball")) as GameObject;
                fireball.transform.position = new Vector3(
                    //(x * fireball.transform.localScale.x) - ((fireball.transform.localScale.x*rowStr.Length)/2),
                    (gameObject.transform.position.x + (fireball.transform.localScale.x + xOffset)*x) - (((fireball.transform.localScale.x + xOffset)*(rowArray.Length-1))/2),
                    gameObject.transform.position.y,
                    //y * fireball.transform.localScale.y + yOffset,
                    0f);
            } 
            
            else if (c == 'D')
            {
                GameObject diamond = Instantiate(Resources.Load("Diamond")) as GameObject;
                diamond.transform.position = new Vector3(
                    //(x * diamond.transform.localScale.x) - ((diamond.transform.localScale.x*rowStr.Length)/2),
                    //x * diamond.transform.localScale.x * xOffset,
                    (gameObject.transform.position.x + (diamond.transform.localScale.x + xOffset)*x) - (((diamond.transform.localScale.x + xOffset)*(rowArray.Length-1))/2),
                    gameObject.transform.position.y,
                    //y * diamond.transform.localScale.y + yOffset,
                    0f);
            } 
            
            else if (c == 'H')
            {
                GameObject heart = Instantiate(Resources.Load("HeartFallingObject")) as GameObject;
                heart.transform.position = new Vector3(
                    //(x * heart.transform.localScale.x) - ((heart.transform.localScale.x*rowStr .Length)/2),
                    //x * heart.transform.localScale.x * xOffset,
                    (gameObject.transform.position.x + (heart.transform.localScale.x + xOffset)*x) - (((heart.transform.localScale.x + xOffset)*(rowArray.Length-1))/2),
                    gameObject.transform.position.y,
                    //y * heart.transform.localScale.y + yOffset,
                    0f);
            }
        }

        //yield return new WaitForSeconds(waitTime);
    }
}
