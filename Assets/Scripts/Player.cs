using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //stamina specifics
    public Slider staminaBar;
    [Tooltip("The amount being subtracted from the stamina bar when sprinting.")]
    public float dValue;
    private float _currentRecharge;
    private float _currentSpeed;

    [Header("Stamina Stats")]
    [SerializeField]
    private float _currentStamina;
    [SerializeField]
    private float _maxStamina;
    [SerializeField]
    [Tooltip("Speed the player goes after running out of stamina altogther.")]
    private float _slowSpeed;
    [SerializeField]
    private float _normalSpeed;
    [SerializeField]
    private float _fastSpeed;
    [SerializeField]
    [Tooltip("Normal recharge rate - when the stamina bar hasn't run out.")]
    private float _normalRecharge;
    [SerializeField]
    [Tooltip("Slow recharge rate - when the stamina bar has run out.")]
    private float _slowRecharge;
    [SerializeField]
    [Tooltip("The threshhold when the recharge speed goes back to normal after the stamina bar has" +
             "been completely emptied")]
    private float _speedRestoreThresh;


    //allowing values to be changed in inspector
    public float CurrentStamina => _currentStamina;
    public float MaxStamina => _maxStamina;
    public float SlowSpeed => _slowSpeed;
    public float NormalSpeed => _normalSpeed;
    public float FastSpeed => _fastSpeed;
    public float NormalRecharge => _normalRecharge;
    public float SlowRecharge => _slowRecharge;
    public float SpeedRestoreThresh => _speedRestoreThresh;

    //character movement
    private CharacterController _characterController;

    //stamina stuff
    private void DecreaseEnergy()
    {
        if (_currentStamina != 0)
            _currentStamina -= dValue * Time.deltaTime;
        
            
        if (_currentStamina <= 0)
        {
            _currentRecharge = _slowRecharge;
            _currentSpeed = _slowSpeed;
            _currentStamina = 0;
        }
    }

    private void IncreaseEnergy( float rechargeScale )
    {
        _currentStamina += dValue * rechargeScale * Time.deltaTime;
        if (_currentStamina >= _maxStamina)
        {
            _currentStamina = _maxStamina;
            _currentRecharge = _normalRecharge;
            _currentSpeed = _normalSpeed;
        } 
        else if (_currentStamina >= _speedRestoreThresh * _maxStamina)
        {
            _currentSpeed = _normalSpeed;
        }
    }


    private void Start()
    {
        _characterController = GetComponent<CharacterController>();

        _maxStamina = _currentStamina;
        staminaBar.maxValue = _maxStamina;
        _currentSpeed = _normalSpeed;
        _currentRecharge = _normalRecharge;

    }

    private void Update()
    {
        //movement code
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //stamina code
        if (Input.GetKey(KeyCode.LeftShift) && _currentRecharge != _slowRecharge )
        {

            _characterController.Move(move * Time.deltaTime * _fastSpeed);
            DecreaseEnergy();
        }
        else 
        {
            _characterController.Move(move * Time.deltaTime * _currentSpeed);
            if ( _currentStamina != _maxStamina )
            {
                IncreaseEnergy( _currentRecharge );
            }
        }

        staminaBar.value = _currentStamina;
    }
}