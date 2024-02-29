using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameManager.Instance.isEndGame()){
            return;
        }

        var step = GameManager.Instance.ObstacleSpeed * Time.deltaTime;
        transform.position -= new Vector3(step, 0, 0);

        if(transform.position.x <= -17f){
            Destroy(gameObject);
        }
    }
}
