using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("General Stats")]
    [SerializeField]
    private int _health;
    [SerializeField]
    private int _stamina;
    [SerializeField]
    private int _walkSpeed;
    [SerializeField]
    private int _runSpeed;
    [SerializeField][Tooltip("The set amount of panic the player can endure before experiencing" +
                            "into a panic attack")]
    private int _panicLimit;
    [SerializeField][Tooltip("The set amount of time the player experiences a panic attack ")]
    private int _panicAttackDuration;

}
