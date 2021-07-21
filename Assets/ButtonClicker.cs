using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClicker : MonoBehaviour
{
    public int bombs = 0;
    public bool visited = false;
    public bool markert = false;
    public GameObject[] neighbors;
    public void pressedBomb()
    {   
        if(!Score.flaggModus)
        {
            if(!markert)
            {
                Score.lost = true;
                StartCoroutine(newGame());
                GameObject button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
                button.GetComponent<Image>().color = new Color32 (255,0,0,255);
                button.GetComponentInChildren<Text>().text = "BOMB";
                Debug.Log("Game Over");
            }
        }
        else
        {
            GameObject button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            if(markert)
            {
                button.GetComponent<Image>().color = new Color32 (255,255,255,255);
                Score.BombsLeft++;
            }
            else
            {
                button.GetComponent<Image>().color = new Color32 (255,0,165,255);
                Score.BombsLeft--;
            }
            markert = !markert;

        }
    }

    public void pressedOther()
    {   
        if(!visited){
            if(!Score.flaggModus)
            {
                if(!markert)
                {   
                Button button = gameObject.GetComponent<Button>();
                Score.OthersLeft--;
                if(Score.OthersLeft == 0){
                    StartCoroutine(newGame());
                }
                visited = true;
                //UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
                gameObject.GetComponent<Image>().color = new Color32 (0,255,0,255);
                if(bombs == 0){
                    for(int i = 0; i < 8; i++){

                
                            if(neighbors[i] != null)
                            {
                                if(!neighbors[i].GetComponent<ButtonClicker>().visited){
                                    neighbors[i].GetComponent<ButtonClicker>().pressedOther();
                                }
                            }
                    
                        
                    }
                }
                gameObject.GetComponentInChildren<Text>().text = bombs.ToString();
                }
            }
            else
            {
                GameObject button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
                if(markert)
                {
                    button.GetComponent<Image>().color = new Color32 (255,255,255,255);
                    Score.BombsLeft++;
                }
                else
                {
                    button.GetComponent<Image>().color = new Color32 (255,0,165,255);
                    Score.BombsLeft--;
                }
                markert = !markert;
            }
        }

    }

    IEnumerator newGame(){
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
