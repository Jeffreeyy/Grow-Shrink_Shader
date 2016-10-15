using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour
{
    [SerializeField]private GameObject[] _pickupPrefabs;
    [SerializeField]private float _spawnRate;

	void Awake ()
    {
        SpawnPickup();
	}

    public void SpawnPickup()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_spawnRate);
        GameObject pickup = Instantiate(_pickupPrefabs[Random.Range(0, _pickupPrefabs.Length)],transform.position,Quaternion.identity) as GameObject;
        pickup.transform.parent = gameObject.transform;
    }
}
