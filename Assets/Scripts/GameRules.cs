using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 Игровые правила. Проект иммет два канваса. Оба включены в инспекторе, но SetActive не включает отключенные в инспекторе элементы. В Start указан явно указан размер времени в 1,
для того, чтобы при 0 записывался рекорд. Отключение канваса через скрипт нужен для того, чтобы небыло конфликта с камерой на другом канвасе (по моим наблюдениям рандомно включается
один из канвасов)
 */
public class GameRules : MonoBehaviour
{
    public GameObject MenuCanvas, TrackCanvas;

    void Start()
    {
        Time.timeScale = 1;

        MenuCanvas = GameObject.Find("Menu");
        TrackCanvas = GameObject.Find("Game");

        MenuCanvas.SetActive(true);
        TrackCanvas.SetActive(false);
    }

    void Update()
    {
        if (Time.timeScale == 0 & Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel(0);
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
