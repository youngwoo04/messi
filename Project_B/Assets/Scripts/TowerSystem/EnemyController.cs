using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

    private EnemyPath thePath;          //���Ͱ� ������ �ִ� path ��
    private int currentPoint;           //���� �� ��° point�� ���ϰ� �ִ��� ����
    private bool reacheEnd;             //���� �Ϸ� üũ 
        
    void Start()
    {
        if(thePath == null)
        {
            thePath = FindObjectOfType<EnemyPath>();    //��� ������Ʈ�� �˻��ؼ� EnemyPath�� �ִ� ������Ʈ�� �����´�.
        }
    }
   
    void Update()
    {
        if(reacheEnd == false)  // if(!reacheEnd) ���� ����
        {
            transform.LookAt(thePath.points[currentPoint]); //���ʹ� ���� ������ ���ؼ� ����. (LookAt �Լ�)

            //MoveToward �Լ� (����ġ , Ÿ�� ��ġ, �ӵ���) 
            transform.position =
                Vector3.MoveTowards(transform.position, thePath.points[currentPoint].position, moveSpeed * Time.deltaTime);

            //Vector3.Distance (A,B) ������ �Ÿ� => �Ÿ��� 0.01���� �� ��� �����ߴٰ� ����
            if (Vector3.Distance(transform.position , thePath.points[currentPoint].position) < 0.01f)    
            {
                currentPoint += 1;          //���� ����Ʈ�� ����
                if(currentPoint >= thePath.points.Length)   //����Ʈ �迭������ ������쿡�� ���� �Ϸ�
                {
                    reacheEnd = true;
                }
            }
        }
    }
}
