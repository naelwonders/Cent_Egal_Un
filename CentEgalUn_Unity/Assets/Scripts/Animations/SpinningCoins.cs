using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningCoins : MonoBehaviour
{
    public Sprite tailColor;

    private Coin heads;
    public Animator animator;

    private float randomTimeInterval;

    private DragAndDropController dragDrop;
    

    void Start()
    {
        heads = GetComponent<Coin>();
        animator = GetComponent<Animator>();
        dragDrop = GetComponent<DragAndDropController>();
        StartCoroutine(PlayAnimationAtRandomIntervals());
    }

    public void Switch() {
        GetComponent<SpriteRenderer>().sprite = tailColor;
    }

    public void UnSwitch() {
        GetComponent<SpriteRenderer>().sprite = heads.headsImage;
    }

    void Update() 
    {
        //quand le player interagit avec le coin, la coin ne spin plus
        animator.SetBool("playerInteract", dragDrop.isDragged || !dragDrop.isDraggable);
    }

    public IEnumerator PlayAnimationAtRandomIntervals()
    {
        while(true) 
        {
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) 
            {
                randomTimeInterval = Random.Range(0.2f, 10f);
                yield return new WaitForSeconds(randomTimeInterval);
                animator.SetTrigger("turn");
            }
            yield return null;
        }
    }
}

