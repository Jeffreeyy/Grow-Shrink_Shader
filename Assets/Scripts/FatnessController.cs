using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FatnessController : MonoBehaviour {

    private VertexModifier _modifier;
    [SerializeField]private Image _fatnessBar;
    [SerializeField]private int _shrinkRate;

    void Start ()
    {
        _modifier = GetComponent<VertexModifier>();
        StartCoroutine(Shrink());
    }

    IEnumerator Shrink()
    {
        if (_modifier.Fatness <= _modifier.MinFatness)
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
        else
            _modifier.Fatness -= 0.005f;

		_modifier.ModifyVertex (_modifier.Fatness);
        UpdateBar();

        yield return new WaitForSeconds(_shrinkRate);
        StartCoroutine(Shrink());
    }

    public void Grow()
    {
        if (_modifier.Fatness < _modifier.MaxFatness)
            _modifier.Fatness += 0.02f;
        else
            _modifier.Fatness = _modifier.MaxFatness;

		_modifier.ModifyVertex (_modifier.Fatness);
        UpdateBar();
    }
    
    private void UpdateBar()
    {
		float calculatedFillAmount = _modifier.Fatness / (_modifier.MaxFatness - _modifier.MinFatness) + _modifier.MinFatness / (_modifier.MinFatness - _modifier.MaxFatness);
        _fatnessBar.fillAmount = calculatedFillAmount;
    }
}
