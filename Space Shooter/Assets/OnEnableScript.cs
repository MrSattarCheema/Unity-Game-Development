using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableScript : MonoBehaviour
{
    public void Awake()
    {
        Debug.Log("I am Awake()");
    }
    public void Start()
    {
        Debug.Log("I am Start()");
    }
    public void OnEnable()
    {
        Debug.Log("onEnabled called");
    }
    //public void FixedUpdate()
    //{
    //    Debug.Log("I am FixedUpdate()");
    //}
    //public void Update()
    //{
    //    Debug.Log("I am Update()");
    //}
    private void OnDisable()
    {
        Debug.Log("I am disable()");
    }
    private void OnApplicationQuit()
    {
        Debug.Log("onApplicationQuit()");
    }
    private void OnDestroy()
    {
        Debug.Log("onDestroy()");
    }
}
