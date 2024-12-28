using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devil : MonoBehaviour
{
    public Animator animator;
    public TimeManager timeManager;
    public Field field;
    private RectTransform devilTransform;


    public float speed = 15f;
    public Vector2 startingPosition;
    private float screenWidth;
    private bool isMapChanged = false;

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
        // �� ���� ���� �� ��ġ �ʱ�ȭ
        if (isMapChanged)
        {
            DevilRePosition(); // ��ġ �ʱ�ȭ
            isMapChanged = false;  // �ٽ� �������� �ʵ��� ����
        }

        DevilAnim();
        MoveDevil();
    }

    void MoveDevil()
    {
        devilTransform.anchoredPosition += new Vector2(speed * Time.deltaTime, 0);

        if (devilTransform.anchoredPosition.x > screenWidth)
        {
            gameObject.SetActive(false);
        }
    }

    void DevilAnim()
    {
        animator.SetBool("Run", true);
    }

    public void DevilRePosition()
    {
        devilTransform.anchoredPosition = startingPosition;
        gameObject.SetActive(true);
    }

    public void NotifyMapChanged()
    {
        isMapChanged = true;
    }
}
