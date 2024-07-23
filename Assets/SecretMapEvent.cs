using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretMapEvent : MonoBehaviour
{
    public GameObject SpawnUnlock;

    private Enemy enemy;
    private bool eventTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!eventTriggered && enemy.Event())
        {
            Instantiate(SpawnUnlock, transform.position, Quaternion.identity);
            SecretMapTransition.Instance.Enable();
            eventTriggered = true;
        }
    }
}
