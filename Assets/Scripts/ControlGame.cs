
// This script works as a main controller that can control
// how this game works, and switch between game states

using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class ControlGame : MonoBehaviour
{
    public enum GameState
    {
        Home,
        Difficulty,
        Game,
        Ask,
        Credit,
        Learn,
        GameWin,
        GameOver
    }

    [SerializeField] private GameObject
        vt_HomePanel,
        vt_DifficultyPanel,
        vt_GamePanel,
        vt_AskPanel,
        vt_CreditPanel,
        vt_LearnPanel,
        vt_GameWinPanel,
        vt_GameOverPanel;

    private GameState vt_GameState;
    public void SetGameState(GameState state)
    {
        vt_GameState = state;
        vt_HomePanel.SetActive(vt_GameState == GameState.Home);
        vt_DifficultyPanel.SetActive(vt_GameState == GameState.Difficulty);
        vt_GamePanel.SetActive(vt_GameState == GameState.Game);
        vt_AskPanel.SetActive(vt_GameState == GameState.Ask);
        vt_CreditPanel.SetActive(vt_GameState == GameState.Credit);
        vt_LearnPanel.SetActive(vt_GameState == GameState.Learn);
        vt_GameWinPanel.SetActive(vt_GameState == GameState.GameWin);
        vt_GameOverPanel.SetActive(vt_GameState == GameState.GameOver);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        SetGameState(GameState.Home);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // State-change function
    public void Home_State()
    {
        SetGameState(GameState.Home);
    }
    public void Difficulty_State()
    {
        SetGameState(GameState.Difficulty);
    }
    public void Game_State()
    {
        SetGameState(GameState.Game);
    }
    public void Ask_State()
    {
        SetGameState(GameState.Ask);
    }
    public void Credit_State()
    {
        SetGameState(GameState.Credit);
    }
    public void Learn_State()
    {
        SetGameState(GameState.Learn);
    }
    public void GameWin_State()
    {
        SetGameState(GameState.GameWin);
    }
    public void GameOver_State()
    {
        SetGameState(GameState.GameOver);
    }

    // Credit screen button
    public void OpenNet1()
    {
        Application.OpenURL("https://miro.com/app/board/uXjVO2n0xkg=/");
    }
    public void OpenNet2()
    {
        Application.OpenURL("https://miro.com/app/board/uXjVO2QL4po=/");
    }
}
