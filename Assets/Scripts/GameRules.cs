using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 ������� �������. ������ ����� ��� �������. ��� �������� � ����������, �� SetActive �� �������� ����������� � ���������� ��������. � Start ������ ���� ������ ������ ������� � 1,
��� ����, ����� ��� 0 ����������� ������. ���������� ������� ����� ������ ����� ��� ����, ����� ������ ��������� � ������� �� ������ ������� (�� ���� ����������� �������� ����������
���� �� ��������)
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
