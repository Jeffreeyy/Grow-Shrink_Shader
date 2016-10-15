using UnityEngine;
using System.Collections;

public class VertexModifier : MonoBehaviour {

    private Renderer _renderer;
    [SerializeField]private float _minFatness;
    public float MinFatness
    {
        get { return _minFatness; }
    }
    [SerializeField]private float _maxFatness;
    public float MaxFatness
    {
        get { return _maxFatness; }
    }
    private float _fatness;
    public float Fatness
    {
        get { return _fatness; }
        set { _fatness = value; }
    }

	void Awake ()
    {
        _renderer = GetComponentInChildren<Renderer>();
        _fatness = _maxFatness;
	}

    public void ModifyVertex(float amount)
    {
        _renderer.material.SetFloat("_Amount", amount);
    }
}
