using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _delay = 0.5f;

    private int _number = 0;
    private WaitForSeconds _wait;
    private bool _isCoroutineWork;
    private Coroutine counterCoroutine;

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

                if (counterCoroutine != null)
                {
                    StopCoroutine(counterCoroutine);
                }
            }
            else if (_isCoroutineWork == false)
            {
                _isCoroutineWork = true;
                counterCoroutine = StartCoroutine(AddCounter());
            }
        }
    }

    private IEnumerator AddCounter()
    {
        while (_isCoroutineWork == true)
        {
            _number++;

            _text.text = _number.ToString();

            yield return _wait;
        }
    }
}
