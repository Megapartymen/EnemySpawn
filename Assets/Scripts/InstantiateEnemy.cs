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

    private List<Vector3> _spawnAddresses;
    
    private void Start()
    {
        _spawnAddresses = new List<Vector3>();
        _spawnAddresses.Add(new Vector3(_spawnPointFirst.transform.position.x, _spawnPointFirst.transform.position.y + 1, _spawnPointFirst.transform.position.z));
        _spawnAddresses.Add(new Vector3(_spawnPointSecond.transform.position.x, _spawnPointSecond.transform.position.y + 1, _spawnPointSecond.transform.position.z));
        _spawnAddresses.Add(new Vector3(_spawnPointThird.transform.position.x, _spawnPointThird.transform.position.y + 1, _spawnPointThird.transform.position.z));        

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
            foreach (Vector3 spawnAddress in _spawnAddresses)
            {
                CreateEnemy(spawnAddress);
                yield return new WaitForSeconds(_spawnPause);
            }            
        }
    }    
}
