using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandle : MonoBehaviour,IPlayerUesableUI
{
    CharacterMarcine characterMarcine;

    public void Initialize(CharacterMarcine playerMarcine)
    {
        this.characterMarcine = playerMarcine;
    
    }
    private void Update()
    {
        if (!characterMarcine) return;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 objectPosition = characterMarcine.transform.position;
            Vector2 direction = mousePosition - objectPosition;
            characterMarcine.SetAttackAngle(direction);
        }

        characterMarcine.SetDir(new Vector2(moveHorizontal, moveVertical));
    
    }
}

