using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalker : MonoBehaviour
{
    [Header("General Stats")]
    [SerializeField]
    private string _name;

    [Header("Combat Stats")]
    [SerializeField]
    private int _currentHealth;
    [SerializeField]
    private int _maxHealth;
    [SerializeField]
    private int _damage;
    [SerializeField]
    private int _speed;
    [SerializeField]
    private int _downTime;
    [SerializeField]
    [Tooltip("Radius size where stalker will induce panic onto player")]
    private int _panicRadius;


    //allowing values to be changed in inspector
    public string Name =>_name;
    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;
    public int Damage => _damage;
    public int Speed => _speed;
    public int DownTime => _downTime;
    public int PanicRadius => _panicRadius;

    public void TakeDamage(int amount)
    {
        _currentHealth = amount;

        if (_currentHealth <= 0)
        {
            //stalker is down for the set downTime
            //will become active again after downTime is over
            //call upon downtime function

        }
    }

    //create "downTime" function here 
    //in the downTime function, include a check that recovers all of the stalkers
        //health when they've gotten back up.
}
