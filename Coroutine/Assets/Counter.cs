using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _delay = 0.5f;

    private int _number = 0;
    private WaitForSeconds _wait;
    private Coroutine _counterCoroutine;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_counterCoroutine == null)
            {
                _counterCoroutine = StartCoroutine(AddCounter());
            }
            else
            {
                StopCoroutine(_counterCoroutine);
                _counterCoroutine = null;
            }
        }
    }

    private IEnumerator AddCounter()
    {
        while (true)
        {
            _number++;

            _text.text = _number.ToString();

            yield return _wait;
        }
    }
}
