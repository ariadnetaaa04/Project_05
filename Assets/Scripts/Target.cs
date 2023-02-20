using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float lifeTime = 2f;
    private GameManager gameManager;
    public int points;
    public GameObject explosionParticle;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Destroy(gameObject, lifeTime);
    }

   
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!gameManager.isGameOver)
        {
            if (gameObject.CompareTag("Bad"))
        {
            gameManager.isGameOver = true;
        } else if (gameObject.CompareTag("Good"))
            {
            gameManager.UpdateScore(points);
            }

            Destroy(gameObject); 
        }
           
    }
    private void OnDestroy()
    {
        gameManager.targetPositionsInScene.
         Remove(transform.position);

        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

    }
}
