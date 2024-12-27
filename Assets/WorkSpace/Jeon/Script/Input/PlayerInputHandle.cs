using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandle : MonoBehaviour,IPlayerUesableUI
{
    PlayerMarcine characterMarcine;

    public void Initialize(PlayerMarcine playerMarcine)
    {
        this.characterMarcine = playerMarcine;
    
    }
    private void Update()
    {
        if (!characterMarcine) return;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetMouseButton(0) && characterMarcine.isAttackAble)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 objectPosition = characterMarcine.transform.position;
            Vector2 direction = mousePosition - objectPosition;
            characterMarcine.SetAttackAngle(direction);
            characterMarcine.SetAnimatorValue(CharacterAnimeBoolName.CanAttack, true);
        }   
        characterMarcine.Walkable = Mathf.Abs(moveHorizontal) > 0.2 || Mathf.Abs(moveVertical) > 0.2;
        characterMarcine.SetDir(new Vector2(moveHorizontal, moveVertical));
    
    }
}

