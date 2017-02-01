using UnityEngine;
using System.Collections;

public interface IBonus
{
    int ID { get; }
    void Activate();
    IEnumerator Timer();

}
