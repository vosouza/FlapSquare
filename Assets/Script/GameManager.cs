using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}
    public float ObstacleSpeed = 5f;

    private int points = 0;

    private bool endGame = false;

    void Awake(){
        if(Instance != null && Instance != this){
            Destroy(this);
        }else{
            Instance = this;
        }
    }

    public void AddPoint(){
        points++;
    }
    public void EndGame(){
        endGame = true;
        StartCoroutine(ReloadScene(2));
    }

    public bool isEndGame() {
        return endGame;
    }

    private IEnumerator ReloadScene(float delay){
        yield return new WaitForSeconds(delay);

        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
    }
}
