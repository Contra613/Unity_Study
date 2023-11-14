using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Material _bgMaterial;            // ��� ��Ƽ����
    public float _scrollSpeed = 0.2f;       // ��ũ�� �ӵ�

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 direction = Vector2.up;
        _bgMaterial.mainTextureOffset += direction * _scrollSpeed * Time.deltaTime;     // P = P0 + vt
    }
}
