using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devil : MonoBehaviour
{
    public Animator animator;
    public TimeManager timeManager;
    private RectTransform devilTransform;

    public float speed = 15f;
    public Vector2 startingPosition;
    private float screenWidth;
    private int currentMapIndex = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        devilTransform = GetComponent<RectTransform>(); 
        gameObject.SetActive(false);
        screenWidth = Screen.width;

        startingPosition = devilTransform.anchoredPosition;
    }

    void FixedUpdate()
    {
        DevilAnim();
        MoveDevil();
        

    }

    void MoveDevil()
    {
        devilTransform.anchoredPosition += new Vector2(speed * Time.deltaTime, 0);

        if (devilTransform.anchoredPosition.x > screenWidth)
        {
            gameObject.SetActive(false);
            devilTransform.anchoredPosition = startingPosition;
        }
    }

    void DevilAnim()
    {
        animator.SetBool("Run", true);
    }

}
