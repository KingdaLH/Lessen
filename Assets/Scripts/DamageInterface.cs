using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable<T>
{
    void TakeDamage(T damage);
}

public interface IKillable
{
    void OnEmptyBar();
}