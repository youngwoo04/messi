using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericContainer<T>        //���ʸ� ���� Class�� ����ϱ� ���ؼ� ����
{
    private T[] items;                  //Item �迭�� ����
    private int currentIndex = 0;       //Item �ε���

    public GenericContainer(int capacity)   //class���� class�̸��� ���� �Լ��� ���� ������ 
    {
        items = new T[capacity];
    }

    public void Add(T item)                 //�� �����̳ʿ� ���� �ִ´�.
    {
       if(currentIndex < items.Length)      //�����̳� �迭 ĭ �̻� �ɰ�� ���´�. 
       {
            items[currentIndex] = item;     //���� ���� �迭�� �ִ´�.
            currentIndex++;                 //�ε����� �����ñ��. 
       }
    }

    public T[] GetItems()                   //�迭�� �ִ� ���� ���� 
    {
        return items;
    }
}
