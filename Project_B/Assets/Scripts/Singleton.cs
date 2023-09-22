using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour      //1���� ��Ŭ�� Ŭ���� ����
{
    public static Singleton Instance { get; private set; } //�̱��� �ν��Ͻ� ������ ����

    private void Awake()                   //Awake �������� �ν��Ͻ� �˻�
    {
        if(Instance == null)                 //�ν��ͽ��� �������
        {
            Instance = this;        //���� �ν��Ͻ��� Static �� �Է�
            DontDestroyOnLoad(gameObject); //DontDestroyOnLoad �ı����� �ʴ� ������Ʈ�� ����
        }
        else
        {
            Destroy(gameObject);       //������ �ν��Ͻ��� �ִ� ��� �ı� ��Ų��.
        }
    }

    public int playerScore = 0;            //���� ���ھ� int ����

    public void IncreaseScore(int amount)     //���� ���ھ� ���� �Լ� ����
    {
        playerScore += amount;               //�����ش�.
    }
}
