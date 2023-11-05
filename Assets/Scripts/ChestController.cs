using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public GameObject chestOpen;
    public Animator chestAnimation;
    public GameObject chestAnimationObject;
    private float animationTime = 0.75f;
    private bool chestOpenBool = false;
    public Transform LevelClear;

    void Start()
    {
        chestOpen.SetActive(false);
    }

    void Update()
    {
        

        if (chestOpenBool)
        {
            animationTime -= Time.deltaTime;
        }

        if (animationTime <= 0)
        {
            chestAnimationObject.SetActive(false);
            chestOpen.SetActive(true);
            chestOpenBool = false;
            LevelClear.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            chestAnimation.SetTrigger("Open");
            chestOpenBool = true;
        }
    }
}
