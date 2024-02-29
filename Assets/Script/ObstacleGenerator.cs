using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    public float interval = 1f;
    private float cooldown = 0f;
    public List<GameObject> obstacleList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(GameManager.Instance.isEndGame()){
            return;
        }

        cooldown -= Time.deltaTime;
        if(cooldown <= 0){
            GenerateObejct();
            cooldown = interval;
        }
    }

    private void GenerateObejct(){
        var obstacle = obstacleList[Random.Range(0, obstacleList.Count)];
        var positionVariation = Random.Range(-3.5f, 1f);
        var position = new Vector3(16,positionVariation,-0.6f);
        var rotation = obstacle.transform.rotation;
        Instantiate(obstacle, position, rotation);

    }
}
