using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [Header("Set in Inspector")]
    // Шаблон для создания предметов
    public GameObject[] applePrefab;

    // Скорость движения приведения
    public float speed = 6f;

    //Границы движения привидения
    public float leftAndRightEdge = 11.5f;

    //Вероятность измнения направления движения
    public float chanceToChehgeDirections = 0.02f;

    //Частота создания предметов
    public float secondsBetween = 1f;

    GameManeger pausaGM = null;
    bool pausa = false;

    // Start is called before the first frame update
    void Start()
    {
        pausaGM = GameObject.Find("GameManeger").GetComponent<GameManeger>();
        //Сбрасывать предметы раз в секунду
        Invoke("DropApple", 2f);
    }

    public void DropApple ()
    {

        int ndx = Random.Range(0, applePrefab.Length);
        GameObject apple = Instantiate<GameObject>(applePrefab[ndx]);
        apple.transform.position = transform.position;
        if (!pausa) Invoke("DropApple", secondsBetween);
    }

    // Update is called once per frame
    void Update()
    {
        pausa = pausaGM.pause;
        if (!pausa)
        {

            //Простое перемещение

            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            Vector3 pos = transform.position;


            //Изменение направления движения и угла поворота
            if (pos.x < -leftAndRightEdge || pos.x > leftAndRightEdge)
            {
                transform.Rotate(0, 180, 0, Space.Self);
            }

            if (pos.x < -11.6f || pos.x > 11.6f)
            {
                pos.x = 0;
                transform.position = pos;
            }

        }
    }

    void FixedUpdate()
    { 
        //Изменение направления движения случайно
        if (Random.value < chanceToChehgeDirections & (transform.position.x > -10f & transform.position.x < 10f))
        {
            transform.Rotate(0, 180, 0, Space.Self);
        }
    }
}
