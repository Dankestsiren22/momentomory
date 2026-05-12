using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SAvingSataTest
{
    public bool Memento1;
    public bool Memento2;
    public bool Memento3;
    public bool Memento4;
    public float[] position;

    public SAvingSataTest(PlayerData player)
    {
        Memento1 = player.Memento1;
        Memento2 = player.Memento2;
        Memento4 = player.Memento4;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }


}