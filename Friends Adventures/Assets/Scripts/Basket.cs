using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
   
    //public Material materialBasket;
    static Renderer rend;
    Rigidbody rb;
    public static string _colorBasket;
    public bool popadanie = false;
    public bool promah = false;

    Transform position;
        

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
                       
    }

    public static void Blue ()
    {
        rend.material.color = Color.blue;
        _colorBasket = "Blue";
    }

    public static void Green ()
    {
        rend.material.color = Color.green;
        _colorBasket = "Green";
    }

    public static void Red ()
    {
        rend.material.color = Color.red;
        _colorBasket = "Red";
    }

    public static void Yellow ()
    {
        rend.material.color = Color.yellow;
        _colorBasket = "Yellow";
    }

    private void FixedUpdate()
    {
        //управление с клавиатуры -- удалить после теста!!!
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rend.material.color = Color.blue;
            _colorBasket = "Blue";
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rend.material.color = Color.green;
            _colorBasket = "Green";
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            rend.material.color = Color.yellow;
            _colorBasket = "Yellow";
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            rend.material.color = Color.red;
            _colorBasket = "Red";
        }
    }

    void Update ()
    {

    }

    private void OnCollisionEnter(Collision coll)
    {
        GameObject collideWith = coll.gameObject;
        if (collideWith.tag == _colorBasket)
        {
            popadanie = true;
            Destroy(collideWith);
            
        }
        else
        {
            promah = true;
            position = collideWith.transform;
            //Destroy(collideWith);
            collideWith.tag = "Promah";
        }
    }
    private void LateUpdate()
    {
        popadanie = false;
        promah = false;
    }

}
