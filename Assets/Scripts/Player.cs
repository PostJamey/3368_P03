using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("General Stats")]
    [SerializeField]
    private int _currentHealth;
    [SerializeField]
    private int _maxHealth;
    [SerializeField]
    private int _currentStamina;
    [SerializeField]
    private int _maxStamina;
    [SerializeField]
    private int _slowSpeed;
    [SerializeField]
    private int _normalSpeed;
    [SerializeField]
    private int _fastSpeed;
    [SerializeField]
    [Tooltip("The set amount of panic the player can endure before experiencing" +
                        "into a panic attack")]
    private int _panicLimit;
    [SerializeField]
    [Tooltip("The set amount of time the player experiences a panic attack ")]
    private int _panicAttackDuration;


    //allowing values to be changed in inspector
    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;
    public int CurrentStamina => _currentStamina;
    public int MaxStamina => _maxStamina;
    public int SlowSpeed => _slowSpeed;
    public int NormalSpeed => _normalSpeed;
    public int FastSpeed => _fastSpeed;
    public int PanicLimit => _panicLimit;
    public int PanicAttackDuration => _panicAttackDuration;

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;

        if (_currentHealth <= 0)
        {
            //player is dead
            //developer can choose death animation, game over screen, etc.

            //play game over screen
        }
    }

    public void Heal(int amount)
    {
        _currentHealth += amount;
        //I want health to restore over time, like stamina

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    public void StaminaOut(int amount)
    {
        _currentStamina -= amount;

        if (_currentStamina <= 0)
        {
            //player speed has now changed to slowSpeed
            //call upon "slowSpeed" function here
        }
    }

    public void StaminaRestore(int amount)
    {
        _currentStamina += amount;
        //i want stamina to recover over time; not sure how to do that
            //but may just need to add restoring items

        if (_currentStamina > _maxStamina)
        {
            _currentStamina = _maxStamina;
        }
    }
}