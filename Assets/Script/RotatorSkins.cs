using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorSkins : MonoBehaviour
{
    
    [SerializeField, Range(0,20)] private float _rotatioSpeed;
    private float _currentRotation = 0;
    void Update()
    {
        _currentRotation -= Time.deltaTime * _rotatioSpeed;
        transform.rotation = Quaternion.Euler(0, _currentRotation, 0);
    }
    public void ResetRotation() => _currentRotation = 0; 
    
}
