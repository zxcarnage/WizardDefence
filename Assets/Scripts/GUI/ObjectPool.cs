using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] protected Transform _poolContainer;
    [SerializeField] private int _objectsAmount;
    
    private List<GameObject> _objectPool = new List<GameObject>();
    protected void InitializePool()
    {
        for (int i = 0; i < _objectsAmount; i++)
            {
                var instantiatedObject = Instantiate(_template, _poolContainer);
                instantiatedObject.SetActive(false);

                _objectPool.Add(instantiatedObject);
            }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _objectPool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }
}
