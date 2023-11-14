using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject _bombeffect;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject eff = Instantiate(_bombeffect);      // ����Ʈ ������ ����
        eff.transform.position = transform.position;    // ����Ʈ�� ��ġ�� ����ź�� ��ġ�� �����ϴ�.
        Destroy(gameObject);                            // �ڽ� ����
    }
}
