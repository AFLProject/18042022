using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody))]

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject win, lose, ground, scoreboard; //пустые объекты дл€ отображени€ элементов или скрыти€
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float force;
    private Vector3 moveVector;

    [SerializeField] private float defTime = 0;
    [SerializeField] private Text textdefTime, wintext, losetext, record; //текстовые пол€ дл€ данных (рекорда)
    void Start()
    {
        record.text = PlayerPrefs.GetFloat("Score").ToString("F3"); //получение рекорда
        rigidbody = GetComponent<Rigidbody>();
        win = GameObject.Find("Win");
        win.SetActive(false);      //те элементы, из начала
        lose.SetActive(false);
        ground.SetActive(true);
        scoreboard.SetActive(true); //конец
        textdefTime.text = defTime.ToString("F3"); //конвертаци€ в строку, F3 - количество цифр после зап€тых 
    }
    private void FixedUpdate()
    {
        moveVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        rigidbody.AddForce(moveVector.normalized * force, ForceMode.Acceleration);
    }
    private void Update()
    {
        defTime += Time.deltaTime; //генераци€ счЄта (секундомер)
        textdefTime.text = defTime.ToString("F3");
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (PlayerPrefs.HasKey("Score")) //проверка, есть ли такой ключ
        {
            PlayerPrefs.DeleteKey("Score"); //есть есть - удал€ет
        }
        PlayerPrefs.SetFloat("Score", defTime); // создаЄт ключ с результатом
        Debug.Log(defTime);
        win.SetActive(true); //отображение нужной панели
        ground.SetActive(false); //убираю лишнее со сцены, т.к. уже не нужно
        scoreboard.SetActive(false);
        PlayerPrefs.GetFloat("Score"); //получаю ключ с результатом
        Time.timeScale = 0; //остановка времени
        wintext.text = PlayerPrefs.GetFloat("Score").ToString("F3"); //получаю результат дл€ Text (победа)
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(defTime);
        lose.SetActive(true); //активирую панель Lose (проиграл)
        ground.SetActive(false); //также пр€чу
        scoreboard.SetActive(false);
        losetext.text = PlayerPrefs.GetFloat("Score").ToString("F3"); //получаю ключ последнего победного результата
        Time.timeScale = 0; //остановка времени
    }
}
