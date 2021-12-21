using System;
using System.Collections.Generic;
using UnityEngine;


public class Pool : MonoBehaviour
{
    [SerializeField] private Ball _prefab;

    [SerializeField] private int _startCapacity = 9;

    private List<Ball> _pool = new List<Ball>();

    //переписать на generic Pool<Ball> и без MonoBehaviour
    
    /*private Pool()
    {
        CreatePool();
    }*/

    private void Awake()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        //_pool = new List<Ball>();

        for (int i = 0; i < _startCapacity; i++)
        {
            Ball element = CreateElement();
            element.gameObject.SetActive(false);
        }
    }

    private Ball CreateElement()
    {
        Ball createdGo = Instantiate(_prefab, transform);

        _pool.Add(createdGo);
        return createdGo;
    }

    private bool TryGetElement(out Ball element)
    {
        foreach (Ball item in _pool)
        {
            if (item.gameObject.activeInHierarchy == false)
            {
                element = item;
                item.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public Ball GetElement()
    {
        if (TryGetElement(out Ball element))
        {
            return element;
        }

        return CreateElement();
    }

    //научиться писать макросы pvCreatePool -> в метод CreatePool и чтобы сразу скобки. мб каретку в аргументы сначала
}