using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Holi");
        //this.GetComponent<Animator>().Play("Animations_Static.Run_Static");
        //animator.GetComponent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Animator>().Play("Animations_Static.Run_Static");
    }
}
