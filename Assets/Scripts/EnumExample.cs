using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MainMenu,
    InGame,
    Paussed,
    GameOver
}

public class EnumExample : MonoBehaviour
{
    public GameState curState;

    private void Start()
    {
        curState = GameState.MainMenu;
    }

    private void Update()
    {
        if(curState == GameState.MainMenu)
        {
            // Hiển thị UI Menu

        }
        else if(curState == GameState.InGame)
        {
            // Ẩn UI Menu
        }
    }
}
