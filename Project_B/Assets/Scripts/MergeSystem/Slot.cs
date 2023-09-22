using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public enum SLOTSTATE       //���� ���°�
    {
        EMPTY,
        FULL
    }
    public int id;                            //���� ��ȣ ID
    public Item itemObject;                   //������ Ŀ���� Class Item
    public SLOTSTATE state = SLOTSTATE.EMPTY; //Enum �� ����
    private void ChangeStateTo(SLOTSTATE targetState)
    {//�ش� ������ ���°��� ��ȯ �����ִ� �Լ�
        state = targetState;
    }
    public void ItemGrabbed()
    {//RayCast�� ���ؼ� �������� ����� �� 
        Destroy(itemObject.gameObject); //���� �������� ����
        ChangeStateTo(SLOTSTATE.EMPTY); //������ �� ����
    }
    public void CreateItem(int  id)
    {
        //������ ��δ� (Resources/Prefabs/Item_000)
        string itemPath = "Prefabs/Item_" + id.ToString("000"); 
        var itemGo = (GameObject)Instantiate(Resources.Load(itemPath));
        itemGo.transform.SetParent(this.transform);
        itemGo.transform.localPosition = Vector3.zero;
        itemGo.transform.localScale = Vector3.one;
        //������ �� ������ �Է�
        itemObject = itemGo.GetComponent<Item>();
        itemObject.Init(id, this);  //�Լ��� ���� �� �Է�(this -> Slot Class)
        ChangeStateTo(SLOTSTATE.FULL); //���� �� ����
    }
}
