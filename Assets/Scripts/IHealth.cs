using UnityEngine;
using System.Collections;

public interface IHealth
{
    void ModifyHealth(int damage);
    int ReturnHealth();

}
