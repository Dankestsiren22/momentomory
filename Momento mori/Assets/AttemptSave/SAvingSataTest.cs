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

    public SAvingSataTest(PlayerData player)
    {
        Memento1 = player.Memento1;
        Memento2 = player.Memento2;
        Memento3 = player.Memento3;
        Memento4 = player.Memento4;
    }
}