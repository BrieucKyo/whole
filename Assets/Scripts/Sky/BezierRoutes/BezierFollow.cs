﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierFollow : MonoBehaviour
{
    [SerializeField] private Transform[] routes;

    private int routeToGo = 0;

    private float tParam = 0f;

    private Vector3 BirdsGroupPosition;

    [SerializeField] private float speed = 0.5f; 
    private bool coroutineAllowed;

    void Start()
    {
    coroutineAllowed = true;
        
    }
    void Update()
    {
        if (coroutineAllowed){
            StartCoroutine(FollowRoute(routeToGo));
        }
    }

    private IEnumerator FollowRoute(int routeNumber) {
        coroutineAllowed = false;

        Vector3 p0 = routes[routeNumber].GetChild(0).position;
        Vector3 p1 = routes[routeNumber].GetChild(1).position;
        Vector3 p2 = routes[routeNumber].GetChild(2).position;
        Vector3 p3 = routes[routeNumber].GetChild(3).position;

        while (tParam < 1) {
            tParam += Time.deltaTime * speed;
            BirdsGroupPosition = Mathf.Pow(1 - tParam, 3) * p0 + 
            3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 
            3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
            Mathf.Pow(tParam, 3) * p3;

            transform.position = BirdsGroupPosition;
            
            yield return new WaitForEndOfFrame();
        }
        tParam = 0f;

        routeToGo += 1;

        if(routeToGo > routes.Length -1) {
            routeToGo = 0;
        }
        coroutineAllowed = true;
    }
}
