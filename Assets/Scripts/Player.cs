using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private LayerMask collisionLayerMask;
    [SerializeField] private PlayerStatsUI playerStatsUI;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int maxMana = 10;
    private int _currentHealth;
    public static Player Instance { get; private set; }
    private float _currentMana;
    private bool _isMoving;

    #region States

    public PlayerStateMachine StateMachine { get; private set; }

    public NoWeaponState NoWeaponState { get; private set; }

    #endregion

    private void Awake()
    {
        Instance = this;
        StateMachine = new PlayerStateMachine();

        NoWeaponState = new NoWeaponState(this, StateMachine);
        _currentHealth = maxHealth;
    }
    private void Start()
    {
        StateMachine.Initialize(NoWeaponState);
    }
    private void Update()
    {
        HandleMovement();
        HandleMana();
        StateMachine.CurrentState.Update();
    }

    private void HandleMana()
    {
        if (_currentMana >= maxMana) return;
        _currentMana += Time.deltaTime;
        playerStatsUI.SetMana(_currentMana);
    }

    private void HandleMovement()
    {
        Vector2 move = GameInput.Instance.GetMovementVector();
        Vector3 moveDir = new Vector3(move.x, 0, move.y);

        var moveDistance = (moveSpeed * Time.deltaTime);
        float playerRadius = 0.7f;
        float playerHeight = 2f;
        bool canMove = !Physics.BoxCast(transform.position, Vector3.one * playerRadius,
            moveDir, Quaternion.identity, moveDistance, collisionLayerMask);

        if (!canMove)
        {
            //1. check if we can move forward
            Vector3 forwardDir = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = (moveDir.x < -0.5f || moveDir.x > 0.5f) && !Physics.BoxCast(transform.position,
                Vector3.one * playerRadius,
                forwardDir, Quaternion.identity, moveDistance, collisionLayerMask);

            //2. check if we can move to the side
            if (canMove)
            {
                moveDir = forwardDir;
            }
            else
            {
                Vector3 sideDir = new Vector3(0, 0, moveDir.z).normalized;
                canMove = (moveDir.z < -0.5f || moveDir.z > 0.5f) && !Physics.BoxCast(transform.position,
                    Vector3.one * playerRadius,
                    sideDir, Quaternion.identity, moveDistance, collisionLayerMask);

                if (canMove)
                {
                    moveDir = sideDir;
                }
                else
                {
                    //Can't move forward or to the side
                    moveDir = Vector3.zero;
                }
            }
        }

        _isMoving = moveDir != Vector3.zero;

        transform.position += (moveDir * moveDistance);
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }
    public float GetCurrentMana()
    {
        return _currentMana;
    }

    public void UseMana(float amount)
    {
        _currentMana -= amount;
        playerStatsUI.SetMana(_currentMana);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("Player has died");
    }
 
}