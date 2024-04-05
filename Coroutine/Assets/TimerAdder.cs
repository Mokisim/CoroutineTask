using System.Collections;
using TMPro;
using UnityEngine;

public class TimerAdder : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _delay = 0.5f;
    private int _number = 0;
    private WaitForSeconds _wait;
    private bool _isCoroutineWork;
    private Coroutine _coroutine;

    private void Awake()
    {
        _isCoroutineWork = false;
        _wait = new WaitForSeconds(_delay);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_isCoroutineWork == true)
            {
                _isCoroutineWork = false;

                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                }
            }
            else if (_isCoroutineWork == false)
            {
                _isCoroutineWork = true;
                _coroutine = StartCoroutine(Add());
            }
        }
    }

    private IEnumerator Add()
    {
        while (_isCoroutineWork == true)
        {
            _number++;

            _text.text = _number.ToString();

            yield return _wait;
        }
    }
}
