using UnityEngine;
using System.Collections;

public class FoodPickup : MonoBehaviour
{

    private SpawnFood _foodSpawner;
	[SerializeField]private int _pickupScore = 1;

    void Start()
    {
        _foodSpawner = GetComponentInParent<SpawnFood>();
    }

    void OnTriggerEnter(Collider col)
    {
        col.GetComponent<FatnessController>().Grow();
		col.GetComponent<PlayerScore> ().AddScore (_pickupScore);
        Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        _foodSpawner.SpawnPickup();
    }
}
