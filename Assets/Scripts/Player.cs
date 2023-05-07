using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Stamina specifics
    public Slider staminaBar;
    public float dValue;

    [Header("General Stats")]
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _maxHealth;
    [SerializeField]
    private float _currentStamina;
    [SerializeField]
    private float _maxStamina;
    [SerializeField]
    private float _slowSpeed;
    [SerializeField]
    private float _normalSpeed;
    [SerializeField]
    private float _fastSpeed;
    [SerializeField]
    [Tooltip("The set amount of panic the player can endure before experiencing" +
                        "into a panic attack")]
    private float _panicLimit;
    [SerializeField]
    [Tooltip("The set amount of time the player experiences a panic attack ")]
    private float _panicAttackDuration;


    //allowing values to be changed in inspector
    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;
    public float CurrentStamina => _currentStamina;
    public float MaxStamina => _maxStamina;
    public float SlowSpeed => _slowSpeed;
    public float NormalSpeed => _normalSpeed;
    public float FastSpeed => _fastSpeed;
    public float PanicLimit => _panicLimit;
    public float PanicAttackDuration => _panicAttackDuration;

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

    //Character Movement

    private CharacterController _characterController;

    //Stamina Stuff
    private void DecreaseEnergy()
    {
        //_currentSpeed = _fastSpeed;
        if (_currentStamina != 0)
            _currentStamina -= dValue * Time.deltaTime;
        
            
        if (_currentStamina <= -1)
            _currentStamina = 0;
    }

    private void IncreaseEnergy()
    {
        _currentStamina += dValue * Time.deltaTime;
        if (_currentStamina >= _maxStamina)
            _currentStamina = _maxStamina;
    }

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();

        _maxStamina = _currentStamina;
        staminaBar.maxValue = _maxStamina;
    }

    private void Update()
    {
        //Movement code
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _characterController.Move(move * Time.deltaTime * _normalSpeed);

        //Stamina code
        if (Input.GetKey(KeyCode.LeftShift))
            DecreaseEnergy();
        else if (_currentStamina != _maxStamina)
            IncreaseEnergy();

        staminaBar.value = _currentStamina;
    }
}