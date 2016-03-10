using UnityEngine;
using System.Collections;

public interface IDamageable
{
    int Health
    { get; set; }
    int MaxHealth
    { get; set; }
    bool Alive
    { get; set; }
    
    void TakeDamage();
    void OnDeath();
}
