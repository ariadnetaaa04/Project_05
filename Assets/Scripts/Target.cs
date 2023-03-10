using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float lifeTime = 2f;
    private GameManager gameManager;
    public int points; //puntuacion de cada objeto
    public GameObject explosionParticle;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Destroy(gameObject, lifeTime); //autodestruccion cada 2 segundos (lifeTime =2)
    }

    private void OnMouseDown()
    {
        if (!gameManager.isGameOver)
        {
            if (gameObject.CompareTag("Bad"))
            {
                if (gameManager.hasPowerupShield)
                {
                    gameManager.hasPowerupShield = false;
                }
                else
                {
                    gameManager.MinusLife();
                }
                

            } 
            else if (gameObject.CompareTag("Good"))
                {
                gameManager.UpdateScore(points);
                }
            else if (gameObject.CompareTag("Shield"))
            {
                gameManager.hasPowerupShield = true;
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
