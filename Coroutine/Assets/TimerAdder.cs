using System.Collections;
using TMPro;
using UnityEngine;

public class TimerAdder : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField]private float _delay = 0.5f;
    private int _number = 0;
    private WaitForSeconds _wait;
    private bool _isFirtsInput;

    private void Awake()
    {
        _isFirtsInput = false;
        _wait = new WaitForSeconds(_delay);
    }

    private void Update()
    {
        if (_isFirtsInput == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            _isFirtsInput = false;
            StopCoroutine(Add());
        }
        else if (_isFirtsInput == false && Input.GetKeyDown(KeyCode.Mouse0))
        {
            _isFirtsInput = true;
            StartCoroutine(Add());
        }
    }

    private IEnumerator Add()
    {
        while (_isFirtsInput == true)
        {
            _number++;

            _text.text = _number.ToString();

            yield return _wait;
        }
    }
}
