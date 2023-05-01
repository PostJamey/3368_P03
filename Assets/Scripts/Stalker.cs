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
    private int _damage;
    [SerializeField]
    private int _health;
    [SerializeField]
    private int _speed;
    [SerializeField][Tooltip("Radius size where stalker will induce panic onto slayer")]
    private float _panicRadius;

}
