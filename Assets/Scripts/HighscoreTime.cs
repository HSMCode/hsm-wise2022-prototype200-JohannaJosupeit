using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTime : MonoBehaviour

{
    public Text counterText;
    public int seconds, minutes;
    public  bool gameStarted;
    //public bool isPlaying = false; 
    
    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<Text>() as Text;
        gameStarted =false;


    }

    // Update is called once per frame
    void Update()

    {
       if(Input.GetKeyDown("space"))
            {
            gameStarted = true;
           
            }
        if(Input.GetKeyUp("space"))
            {
            gameStarted = true;
           
            }
        
         if (gameStarted)
            {
                counterText.text= "Highscore: " + Time.timeSinceLevelLoad;
            }
        
    
    }
    
    
}
