using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float _rotSpeed = 200f;
    float mx = 0;

    void Start()
    {
        
    }

    void Update()
    {
        // Player는 좌우 회전만 가능
        float mouseX = Input.GetAxis("Mouse X");
        mx += mouseX * _rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, mx, 0);
    }
}
