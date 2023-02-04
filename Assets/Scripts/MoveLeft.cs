using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30;
    private PlayerController playerController;
    private float lowerBound = -8;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController  >();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.gameOver == false){
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (transform.position.x < lowerBound && gameObject.CompareTag("Obstacle")){
            Destroy(gameObject);
        }
        
    }
}
