using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private int _minute = 1;
    [SerializeField] private int _rotateSpeed = 100;
    [SerializeField] private float _ScaleSpeed = 0.01f , _minScale = 0.5f, _maxScale = 3f;
    private float _inpH , _inpV;
    public TextMeshProUGUI _text;
    void Awake()
    {
        StartCoroutine(CountDown(_minute));
    }

    void Update()
    {
        CubeScale(_ScaleSpeed,_minScale, _maxScale);
        CubeRotate(_rotateSpeed);
    }

    private void CubeRotate(int speed)
    {
        _inpH = Input.GetAxis("Horizontal");
        _inpV = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up * speed * _inpV * Time.deltaTime);
        transform.Rotate(Vector3.right * speed * _inpH * Time.deltaTime);
    }
    private void CubeScale(float speed ,float min, float max)
    {
        if (Input.GetKey(KeyCode.Space) && transform.localScale != new Vector3(max, max, max))
        {
            transform.localScale += new Vector3(speed, speed, speed);
        }
        else if (transform.localScale != new Vector3(min, min, min))
        {
            transform.localScale -= new Vector3(speed, speed, speed);
        }
    }
    IEnumerator CountDown(int min)
    {
        for(int m = min; m >= 0; m--)
        {
            for(int s = 60; s >= 0; s--)
            {
                yield return new WaitForSeconds(1);
                _text.text = m.ToString("00:") + s.ToString("00");
            }
        }
        Debug.Log("Game over");
    }

}

