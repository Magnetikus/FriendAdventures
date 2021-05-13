using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public float bottomY = -2f;
    Animator animator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.z /= 1.03f;
        transform.position = pos;

        if (transform.position.y < bottomY)
        {
            
            Destroy(gameObject);
            GameManeger scriptGM = GameObject.Find("GameManeger").GetComponent<GameManeger>();
            scriptGM.Promah();
        }
        if (this.tag == "Promah")
        {
            transform.position = transform.position;
            animator = GetComponent<Animator>();
            animator.SetBool("Pusk",true);
            Destroy(gameObject, 2f);
        }
    }

}
