using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public int difficulty; // 1= facil; 2= medium, 3= dificil
    private Button _button;
    private GameManager gameManager; //comunicacion entre scripts


    private void Awake() //componente propia 
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
}
