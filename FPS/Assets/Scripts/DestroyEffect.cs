using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public float _destroyTime = 1.5f;

    float _currentTime = 0;

    void Update()
    {
        if(_currentTime > _destroyTime)
        {
            Destroy(gameObject);
        }

        _currentTime += Time.deltaTime;
    }
}
