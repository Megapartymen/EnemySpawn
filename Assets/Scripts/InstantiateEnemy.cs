using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _spawnPointFirst;
    [SerializeField] private GameObject _spawnPointSecond;
    [SerializeField] private GameObject _spawnPointThird;
    [SerializeField] private int _spawnPause;

    private Vector3 _spawnAddressFirst;
    private Vector3 _spawnAddressSecond;
    private Vector3 _spawnAddressThird;

    private void Start()
    {
        _spawnAddressFirst = new Vector3 (_spawnPointFirst.transform.position.x, _spawnPointFirst.transform.position.y + 1, _spawnPointFirst.transform.position.z);
        _spawnAddressSecond = new Vector3(_spawnPointSecond.transform.position.x, _spawnPointSecond.transform.position.y + 1, _spawnPointSecond.transform.position.z);
        _spawnAddressThird = new Vector3(_spawnPointThird.transform.position.x, _spawnPointThird.transform.position.y + 1, _spawnPointThird.transform.position.z);

        StartCoroutine(CircleInstantiate());
    }

    private void CreateEnemy(Vector3 spawnPoint)
    {
        GameObject enemy = Instantiate(_enemy, spawnPoint, Quaternion.identity);
    }

    private IEnumerator CircleInstantiate()
    {
        bool onInstantiate = true;

        while (onInstantiate)
        {
            CreateEnemy(_spawnAddressFirst);
            yield return new WaitForSeconds(_spawnPause);
            CreateEnemy(_spawnAddressSecond);
            yield return new WaitForSeconds(_spawnPause);
            CreateEnemy(_spawnAddressThird);
            yield return new WaitForSeconds(_spawnPause);
        }
    }








    //private void CircleInstantiate()
    //{
    //    bool off = true;
        
    //    while (off)
    //    {
    //        CreateEnemy(_spawnPointFirst);
    //        StartCoroutine(WaitNextEnemy());
    //        CreateEnemy(_spawnPointSecond);
    //        StartCoroutine(WaitNextEnemy());
    //        CreateEnemy(_spawnPointThird);
    //        StartCoroutine(WaitNextEnemy());

    //        off = false;
    //    }
    //}

    //private IEnumerator WaitNextEnemy()
    //{
    //    yield return new WaitForSeconds(2);
    //}
}
