using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWeaponState : PlayerState
{
    public NoWeaponState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine) { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }


}