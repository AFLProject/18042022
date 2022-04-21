using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody))]

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject win, lose, ground, scoreboard; //������ ������� ��� ����������� ��������� ��� �������
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float force;
    private Vector3 moveVector;

    [SerializeField] private float defTime = 0;
    [SerializeField] private Text textdefTime, wintext, losetext, record; //��������� ���� ��� ������ (�������)
    void Start()
    {
        record.text = PlayerPrefs.GetFloat("Score").ToString("F3"); //��������� �������
        rigidbody = GetComponent<Rigidbody>();
        win = GameObject.Find("Win");
        win.SetActive(false);      //�� ��������, �� ������
        lose.SetActive(false);
        ground.SetActive(true);
        scoreboard.SetActive(true); //�����
        textdefTime.text = defTime.ToString("F3"); //����������� � ������, F3 - ���������� ���� ����� ������� 
    }
    private void FixedUpdate()
    {
        moveVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        rigidbody.AddForce(moveVector.normalized * force, ForceMode.Acceleration);
    }
    private void Update()
    {
        defTime += Time.deltaTime; //��������� ����� (����������)
        textdefTime.text = defTime.ToString("F3");
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (PlayerPrefs.HasKey("Score")) //��������, ���� �� ����� ����
        {
            PlayerPrefs.DeleteKey("Score"); //���� ���� - �������
        }
        PlayerPrefs.SetFloat("Score", defTime); // ������ ���� � �����������
        Debug.Log(defTime);
        win.SetActive(true); //����������� ������ ������
        ground.SetActive(false); //������ ������ �� �����, �.�. ��� �� �����
        scoreboard.SetActive(false);
        PlayerPrefs.GetFloat("Score"); //������� ���� � �����������
        Time.timeScale = 0; //��������� �������
        wintext.text = PlayerPrefs.GetFloat("Score").ToString("F3"); //������� ��������� ��� Text (������)
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(defTime);
        lose.SetActive(true); //��������� ������ Lose (��������)
        ground.SetActive(false); //����� �����
        scoreboard.SetActive(false);
        losetext.text = PlayerPrefs.GetFloat("Score").ToString("F3"); //������� ���� ���������� ��������� ����������
        Time.timeScale = 0; //��������� �������
    }
}
