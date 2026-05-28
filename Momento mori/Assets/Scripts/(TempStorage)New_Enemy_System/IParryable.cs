using UnityEngine;

public interface IParryable
{
    GameObject Parry_Box { get; }
    void Parried();
}
