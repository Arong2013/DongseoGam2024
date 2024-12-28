using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandle : MonoBehaviour, IPlayerUesableUI
{
    PlayerMarcine characterMarcine;
    public bool IsinputAble;
    public GameObject uiPanel;
    public bool isBtnUp;
    private bool isPaused = false;

    public void Initialize(PlayerMarcine playerMarcine)
    {
        this.characterMarcine = playerMarcine;

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 게임이 일시 정지된 상태라면
            if (isPaused)
            {
                uiPanel.SetActive(false);
                Time.timeScale = 1f; // 게임 진행
            }
            else
            {
                uiPanel.SetActive(true);
                Time.timeScale = 0f; // 게임 멈춤
            }

            // 일시 정지 상태 토글
            isPaused = !isPaused;
        }
        if (IsinputAble)
        {
            if (!characterMarcine) return;
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            if (Input.GetMouseButton(0) && characterMarcine.isAttackAble && isBtnUp)
            {
                isBtnUp = false;
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 objectPosition = characterMarcine.transform.position;
                Vector2 direction = mousePosition - objectPosition;
                characterMarcine.SetAttackAngle(direction);
                characterMarcine.SetAnimatorValue(CharacterAnimeBoolName.CanAttack, true);
            }
            if(Input.GetMouseButtonUp(0) && characterMarcine.isAttackAble) isBtnUp = true;
            characterMarcine.Walkable = Mathf.Abs(moveHorizontal) > 0.2 || Mathf.Abs(moveVertical) > 0.2;
            characterMarcine.SetDir(new Vector2(moveHorizontal, moveVertical));
        }


    }
}

