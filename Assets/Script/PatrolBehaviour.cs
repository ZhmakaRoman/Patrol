using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _startWaitTime = 0;
    [SerializeField]
    private Transform[] _points;

    private float _waitTime;
    private int i = 0;
    private int next;

 

    void Update()
    { 
        //скорость нашего персонажа
        var progres =  _speed * Time.deltaTime;
        //перемещаем наши объекты
        transform.position = Vector3.Lerp(transform.position, _points[i].position, progres);
            //Узнаем дистанцию и если расстояние меньше 0.2f, объект считается достигнутым своего пункта назначения.
        if (Vector3.Distance(transform.position, _points[i].position) < 0.2f)
        {
            
            // обновить следующую точку, чтобы двигаться к ней, возвращаясь к первой точке при достижении последней точки в списке
            //next = (next + 1) % _points.Length;
            //обозначает что нужно перемещатся к след. точке.
            if (_waitTime <= 0 &&  _points.Length > 0)
            {
                _waitTime = _startWaitTime;
                next = (next + 1) % _points.Length;
                i = next;
            }
            else
            {
                //обратный отсчет время
                _waitTime -= Time.deltaTime;
            }
            
        }
      
        
    }

}

