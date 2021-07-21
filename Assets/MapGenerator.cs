using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    int[][] grid;
    GameObject[][] objectGrid;
    public GameObject bomb;
    public GameObject notBomb;

    void Start()
    {
        grid = new int[10][];
        for(int i = 0; i < 10; i++){
            grid[i] = new int[10];
            for(int j = 0; j < 10; j++){
                int index = Random.Range(0,9);
                grid[i][j] = index;
            }
        }
        int x_axis = 90;
        int y_axis = 120;
        objectGrid = new GameObject[10][];
        for(int i = 0; i < 10; i++){
            objectGrid[i] = new GameObject[10];
            for(int j = 0; j < 10; j++){
                if(grid[i][j] == 0){
                    GameObject theBomb = GameObject.Instantiate(bomb, new Vector2(x_axis, y_axis), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
                    objectGrid[i][j] = theBomb;
                    Score.BombsLeft++;
                }
                else{
                    GameObject notTheBomb = GameObject.Instantiate(notBomb, new Vector2(x_axis, y_axis), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
                    //notTheBomb.GetComponentInChildren<Text>().text = findBombNeighbors(i, j).ToString();
                    notTheBomb.GetComponent<ButtonClicker>().bombs = findBombNeighbors(i, j);
                    objectGrid[i][j] = notTheBomb;
                    Score.OthersLeft++;

                }
                x_axis += 140;
            }
            x_axis = 90;
            y_axis += 140;
        }

        for(int i = 0; i < 10; i++){
            
            for(int j = 0; j < 10; j++){
                if(objectGrid[i][j] != null){
                    objectGrid[i][j].GetComponent<ButtonClicker>().neighbors = returnNeighborList(i,  j);
                }
            }
        }
    }

    int findBombNeighbors(int x,  int y){
        int antall = 0;
        try{
            if(grid[x+1][y] == 0){
                antall ++;
            }
        }
        catch{
            Debug.Log("FEIL");
        }
        
        try{
            if(grid[x-1][y] == 0){
                antall ++;
            }
        }
        catch{
            Debug.Log("FEIL");
        }

        try{
            if(grid[x][y+1] == 0){
                antall ++;
            }
        }
        catch{
            Debug.Log("FEIL");
        }

        try{
            if(grid[x+1][y+1] == 0){
                antall ++;
            }
        }
        catch{
            Debug.Log("FEIL");
        }

        try{
            if(grid[x-1][y+1] == 0){
                antall ++;
            }
        }
        catch{
            Debug.Log("FEIL");
        }

        try{
            if(grid[x][y-1] == 0){
                antall ++;
            }
        }
        catch{
            Debug.Log("FEIL");
        }

        try{
            if(grid[x+1][y-1] == 0){
                antall ++;
            }
        }
        catch{
            Debug.Log("FEIL");
        }

        try{
            if(grid[x-1][y-1] == 0){
                antall ++;
            }
        }
        catch{
            Debug.Log("FEIL");
        }
        return antall;

    }

    GameObject[] returnNeighborList(int x,  int y){
        GameObject[] liste = new GameObject[8];
        int counter = 0;
        try{
            if(grid[x+1][y] != 0){
                liste[counter] = objectGrid[x+1][y];
                counter++;
            }
        }
        catch{
            Debug.Log("FEIL");
        }
        
        try{
            if(grid[x-1][y] != 0){
                liste[counter] = objectGrid[x-1][y];
                counter++;
            }
        }
        catch{
            Debug.Log("FEIL");
        }

        try{
            if(grid[x][y+1] != 0){
                liste[counter] = objectGrid[x][y+1];
                counter++;
            }
        }
        catch{
            Debug.Log("FEIL");
        }

        try{
            if(grid[x+1][y+1] != 0){
                liste[counter] = objectGrid[x+1][y+1];
                counter++;
            }
        }
        catch{
            Debug.Log("FEIL");
        }

        try{
            if(grid[x-1][y+1] != 0){
                liste[counter] = objectGrid[x-1][y+1];
                counter++;
            }
        }
        catch{
            Debug.Log("FEIL");
        }

        try{
            if(grid[x][y-1] != 0){
                liste[counter] = objectGrid[x][y-1];
                counter++;
            }
        }
        catch{
            Debug.Log("FEIL");
        }

        try{
            if(grid[x+1][y-1] != 0){
                liste[counter] = objectGrid[x+1][y-1];
                counter++;
            }
        }
        catch{
            Debug.Log("FEIL");
        }

        try{
            if(grid[x-1][y-1] != 0){
                liste[counter] = objectGrid[x-1][y-1];
                counter++;
            }
        }
        catch{
            Debug.Log("FEIL");
        }
        return liste;

    }

    public void flaggKnapp()
    {
        Score.flaggModus = !Score.flaggModus;
        GameObject button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        if(Score.flaggModus){
            button.GetComponentInChildren<Text>().text = "Flaggmodus: På";
        }
        else{
            button.GetComponentInChildren<Text>().text = "Flaggmodus: Av";
        }
    }
}
