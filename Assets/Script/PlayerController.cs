using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float force = 10f;
    private float jumpCooldown = 0f;
    public float jumpInterval = 0.5f;

    private Rigidbody componentRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        componentRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isEndGame()){
            componentRigidbody.useGravity = false;
            return;
        }

        jumpCooldown -= Time.deltaTime;
        bool canJump = jumpCooldown <= 0;

        if(canJump == true){
            bool jumpInput = Input.GetKey(KeyCode.Space);
            if(jumpInput == true){
                Jump();
            }
        }
        
    }

    void OnCollisionEnter(Collision collision){
        CollisionLogic(collision.gameObject);
    }

    void OnTriggerEnter(Collider collision){
        CollisionLogic(collision.gameObject);
    }

    void CollisionLogic(GameObject g){
        if(g.CompareTag("sensor")){
            GameManager.Instance.AddPoint();
        }else{
            GameManager.Instance.EndGame();
        }
    }

    private void Jump(){

        this.componentRigidbody.velocity = Vector3.zero;
        this.componentRigidbody.AddForce(new Vector3(0,force,0), ForceMode.Impulse);
        jumpCooldown = jumpInterval;
    }
}
