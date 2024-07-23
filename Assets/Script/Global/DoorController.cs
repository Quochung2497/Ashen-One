using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public static DoorController doorcontroller;
    private Animator anim;
    public GameObject chargeEnemy, chargeEnemy1;
    private BoxCollider2D originalBoxCollider;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Awake()
    {
        if (doorcontroller != null && doorcontroller != this)
        {
            Destroy(gameObject);
        }
        else
        {
            doorcontroller = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    public virtual void OpeningDoor()
    {
        anim.SetBool("isOpening", true);
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        if (box != null)
        {
            originalBoxCollider = box;
            Destroy(box);
        }

        if (chargeEnemy != null)
        {
            StartCoroutine(active());
        }
        StartCoroutine(RecreateBoxColliderAfterDelay(5f));
    }

    public virtual void OpenDoor()
    {
        anim.SetBool("isOpening", true);
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        if (box != null)
        {
            originalBoxCollider = box;
            Destroy(box);
        }
    }
    IEnumerator active()
    {
        yield return new WaitForSeconds(3);
        chargeEnemy.SetActive(true);
        chargeEnemy1.SetActive(true);
    }
    IEnumerator RecreateBoxColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.SetBool("isClosing", true);
        BoxCollider2D newBoxCollider = gameObject.AddComponent<BoxCollider2D>();
        if (originalBoxCollider != null)
        {
            newBoxCollider.offset = originalBoxCollider.offset;
            newBoxCollider.size = originalBoxCollider.size;
            newBoxCollider.isTrigger = originalBoxCollider.isTrigger;
        }
    }
}
