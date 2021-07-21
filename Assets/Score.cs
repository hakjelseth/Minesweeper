using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int BombsLeft;
    public static int OthersLeft;
    public static bool lost;
    public static bool flaggModus;
    // Start is called before the first frame update
    void Start()
    {
        BombsLeft = 0;
        OthersLeft = 0;
        lost = false;
        flaggModus = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if(lost)
        {
            gameObject.GetComponent<Text>().text = "YOU LOSE";
        }
        else if(OthersLeft == 0){
            gameObject.GetComponent<Text>().text = "YOU WIN!!!";
        }
        else{
            gameObject.GetComponent<Text>().text = "Bombs: " + BombsLeft.ToString() + " Other: " + OthersLeft;
        }
    }
}
