﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introBehavior : StateMachineBehaviour {

    private Boss boss;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        boss = animator.GetComponent<Boss>();
        boss.Teleport = true;
	}
    
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
    }

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

}
