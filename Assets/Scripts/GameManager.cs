using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] targetPrefabs;
    private float minX = -3.75f;
    private float minY = -3.75f;
    private float distanceBetweenSquares = 2.5f;

    public bool isGameOver;
    public float spawnRate = 2f;
    public List<Vector3> targetPositionsInScene;
    public Vector3 randomPos;

    public TextMeshProUGUI scoreText;
    private int score;

    public TextMeshProUGUI gameOverText;


    void Start()
    {
        isGameOver = false;
        StartCoroutine("SpawnRandomTarget");
        scoreText.text = $"Score: { score}";
    }

    // Update is called once per frame
    void Update()
    {
        
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
        scoreText.text = $"Score: { score}";
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);
    }
}
