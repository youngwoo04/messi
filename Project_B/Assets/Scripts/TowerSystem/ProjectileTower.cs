using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTower : MonoBehaviour
{
    private Tower thisTower;            //���� ������Ʈ �ȿ��ִ� ������Ʈ Tower�� ����

    public GameObject projectile;           //�߻�ü ������
    public Transform firePoint;             //�߻� ��ġ Transfrom ��
    public float timeBetweenShot = 1.0f;    //�߻� �ð� ����

    private float shotCounter;              //�ð��� ����

    private Transform target;               //Ÿ�� ��ġ��
    public Transform launcherModel;         //��ó �� Transfrom ��  

    // Start is called before the first frame update
    void Start()
    {
        thisTower = GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)  //Ÿ���� ���� ���
        {
            launcherModel.rotation =
                Quaternion.Slerp(launcherModel.rotation,    //���ʹϾ�
                Quaternion.LookRotation(target.position - transform.position), //���� (���� ����)
                5f * Time.deltaTime);

            launcherModel.rotation = Quaternion.Euler(
                0.0f,       // x
                launcherModel.rotation.eulerAngles.y,
                0.0f);  // z

            //���� ȸ���ؼ� �ٶ󺸰� �ϴ� ����
        }

        shotCounter -= Time.deltaTime;

        if(shotCounter <= 0.0f && target != null)
        {
            shotCounter = thisTower.fireRate;       //Tower�� �ִ� �߻� �ð��� �����ͼ� �Է�

            firePoint.LookAt(target);               //firePoint�� target�� ���� �ٶ�

            Instantiate(projectile, firePoint.position, firePoint.rotation);    //firePoint�� �߻�ü ����
        }

        if(thisTower.enemiesUpdate)
        {
            if(thisTower.enemiesInRange.Count > 0) 
            {
                float minDistance = thisTower.range + 1f;
                foreach(EnemyController enemy in thisTower.enemiesInRange)
                {
                    if(enemy != null)
                    {
                        float distance = Vector3.Distance(transform.position, enemy.transform.position);
                        
                        if(distance < minDistance)  //�������� 
                        {
                            minDistance  = distance; //������ �� �ּҰ��� ��� ����
                            target = enemy.transform;
                        }
                    }
                }
            }
            else
            {
                target = null;  //�Ÿ��� Ÿ���� ����
            }
        }
    }
}
