using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject[] targetPrefabs;
    private float minX = -3.75f;
    private float minY = -3.75f;
    private float distanceBetweenSquares = 2.5f;
    private int score;

    public bool isGameOver; //publico para poder usarlo en otros scripts
    public float spawnRate = 2f;
    public List<Vector3> targetPositionsInScene;
    public Vector3 randomPos;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject gameOverPanel;
    public GameObject startGamePanel;


    private int lives = 3;

    public bool hasPowerupShield;

    private void Start()
    {
        startGamePanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }
    private Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minX + Random.Range(0, 4) *
         distanceBetweenSquares;
        float spawnPosY = minY + Random.Range(0, 4) *
         distanceBetweenSquares;
        return new Vector3(spawnPosX, spawnPosY, 0);
    }

    private IEnumerator SpawnRandomTarget()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);

            int randomIndex = Random.Range(0, targetPrefabs.Length);

            randomPos = RandomSpawnPosition();
            while (targetPositionsInScene.Contains(randomPos))
            {
                randomPos = RandomSpawnPosition();
            }

            Instantiate(targetPrefabs[randomIndex], randomPos,
             targetPrefabs[randomIndex].transform.rotation);

            targetPositionsInScene.Add(randomPos);
        }
    }

    public void UpdateScore(int newPoints)
    {
        score += newPoints;
        scoreText.text = $"Score:  { score}";
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.
         GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameOver = false;

        score = 0;
        UpdateScore(0);

        lives = 3;
        livesText.text = $"Lives:  { lives}";

        spawnRate /= difficulty; //divideix els segons (cada 2 surt un topo) per 1-2-3 i això ho fa anar mes rapid.
        
        StartCoroutine(SpawnRandomTarget());
        startGamePanel.SetActive(false); //desactivar los paneles al empezar el juego
        gameOverPanel.SetActive(false);
        
    }

    public void MinusLife()
    {
        lives--;
        livesText.text = $"Lives:  { lives}";

        if (lives <= 0)
        {
            GameOver();
        }
    }

}
