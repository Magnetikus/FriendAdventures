using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personag : MonoBehaviour
{
    public float speed = 0.2f;
    float wayX;
    public Vector3 pos;
    public float leftAndRightEdge = 10.5f;

    Animator animator;
    bool buttonLeft = false;
    bool buttonRight = false;
    bool naklon = false;
    bool left = false;
    bool right = false;

    GameManeger pausaGM = null;
    bool pausa = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        pausaGM = GameObject.Find("GameManeger").GetComponent<GameManeger>();
        
    }

    
    
    public void LeftButtonDown()
    {
        buttonLeft = true;
        buttonRight = false;
        wayX = -speed;
    }

    public void RightButtonDown()
    {
        buttonRight = true;
        buttonLeft = false;
        wayX = speed;
    }

    public void Stop()
    {
        buttonLeft = false;
        buttonRight = false;
        
    }

    public void Cast()
    {
        naklon = true;        
    }

    public void CastOff()
    {
        naklon = false;
    }
    
    void Update()
    {
        pausa = pausaGM.pause;
        if (pausa)
        {
            buttonLeft = buttonRight = false;
            animator.SetBool("buttonRight", buttonRight);
            animator.SetBool("buttonLeft", buttonLeft);
        }
        else
        {

            pos = transform.position;
            if (pos.x < -leftAndRightEdge)
            {
                pos.x += 0.2f;

            }

            if (pos.x > leftAndRightEdge)
            {
                pos.x += -0.2f;

            }

            if (pos.x < -leftAndRightEdge + 0.9f)
            {
                left = true;
            }
            else left = false;

            if (pos.x > leftAndRightEdge - 0.9f)
            {
                right = true;
            }
            else right = false;



            //управление с клавиатуры -- удалить после теста!!!
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                buttonLeft = false;
                buttonRight = true;
                wayX = speed;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                buttonRight = false;
                buttonLeft = true;
                wayX = -speed;
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                buttonLeft = false;

            }

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                buttonRight = false;

            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                naklon = true;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                naklon = false;
            }

            if (buttonRight == false && buttonLeft == false) wayX = 0;

            pos.x += wayX;
            transform.position = pos;
            animator.SetBool("buttonRight", buttonRight);
            animator.SetBool("buttonLeft", buttonLeft);
            animator.SetBool("naklon", naklon);
            animator.SetBool("left", left);
            animator.SetBool("right", right);
        }
        
    }

    

}
