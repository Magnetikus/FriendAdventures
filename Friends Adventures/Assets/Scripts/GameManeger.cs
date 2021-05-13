using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    public static Text scoreGT;
    public static Text lifeGT;
    public Basket _Basket = null;
    public Ghost _Ghost = null;
    public bool pause = false;
    readonly string[] tagColor = { "Red", "Yellow", "Blue", "Green" };

    //GameObject[] destroyRed, destroyYellow, destroyBlue, destroyGreen;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("Score");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
        GameObject lifeGO = GameObject.Find("Life");
        lifeGT = lifeGO.GetComponent<Text>();
        lifeGT.text = "5";

        
        
    }

    public void Popadanie ()
    {
        int score = int.Parse(scoreGT.text);
        score += 100;
        scoreGT.text = score.ToString();
    }

    public void Promah ()
    {
        int life = int.Parse(lifeGT.text);
        life -= 1;
        lifeGT.text = life.ToString();
        //Time.timeScale = 0;
        pause = true;
        Debug.Log("Promah");
        Invoke("DestroyAll", 0.2f);
        
        /*
        destroyRed = GameObject.FindGameObjectsWithTag("Red");
        foreach (GameObject destApple in destroyRed)
        {
            Destroy(destApple);
        }
        destroyYellow = GameObject.FindGameObjectsWithTag("Yellow");
        foreach (GameObject destApple in destroyYellow)
        {
            Destroy(destApple);
        }
        destroyGreen = GameObject.FindGameObjectsWithTag("Green");
        foreach (GameObject destApple in destroyGreen)
        {
            Destroy(destApple);
        }
        destroyBlue = GameObject.FindGameObjectsWithTag("Blue");
        foreach (GameObject destApple in destroyBlue)
        {
            Destroy(destApple);
        }
        */

        if (life == 0)
        {
            
        } 
        
    }

    void DestroyAll ()
    {
        Debug.Log("DesroyAll");

        for (int i = 0; i < tagColor.Length; i++)
        {
            Debug.Log(tagColor[i]);

            GameObject[] destroy = GameObject.FindGameObjectsWithTag(tagColor[i]);
            if (destroy.Length > 0)
            {
                Debug.Log("destroy.Length>0");
                foreach (GameObject dest in destroy)
                {
                    Destroy(dest);
                }
            }
            Debug.Log("no" + tagColor[i]);
        }

        Invoke("Go", 3f);
    } 

    void Go() 
    {
        Debug.Log("Go");
        Time.timeScale = 0;
        /*
        if (Input.GetMouseButtonDown(0))
        {
            pause = false;
            Time.timeScale = 1;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            pause = false;
            Time.timeScale = 1;
        }
        */
    }
    // Update is called once per frame
    void Update()
    {
        if (_Basket.popadanie) Popadanie();
        if (_Basket.promah) Promah();

        if (pause == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                pause = false;
                Time.timeScale = 1;
                _Ghost.DropApple();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                pause = false;
                Time.timeScale = 1;
                _Ghost.DropApple();
            }
        }
        else Time.timeScale = 1;
        
    }

   
}
