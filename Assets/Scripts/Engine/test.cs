﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update


    IslandEngine tmp;
    void Start()
    {
        
        tmp = new IslandEngine();

        tmp.StartEngine();
        tmp.WriteInput("git log --graph");
        StringBuilder ttt = tmp.ReadOutput();


        //while (ttt == null && k != 10000)
        //{
        //    ttt = tmp.ReadOutput();
        //    k++;
        //}
        //if(k == 10000)
        //    UnityEngine.Debug.Log("1000");
        //UnityEngine.Debug.Log("############" + ttt.Length);
        //UnityEngine.Debug.Log(ttt.ToString());
    }

    // Update is called once per frame
    void Update()
    {
    }
}