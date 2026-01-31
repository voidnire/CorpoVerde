using System;
using TMPro;
using UnityEngine;

public class DamageNumber : MonoBehaviour
{
    [SerializeField] private TMP_Text damageText;
    private float floatSpeed;
    public void Start()
    {
        floatSpeed = UnityEngine.Random.Range(0.1f, 1.5f);
        Destroy(gameObject, 1f);
    }

    private void Update()
    {
        //transform.position += new Vector3(0, floatSpeed * Time.deltaTime, 0);
        transform.position += Vector3.up * Time.deltaTime*floatSpeed;
    }

    public void SetValue(float value)
    {
        damageText.text = value.ToString();
    }

    public void SetColor(Color color)
    {
        damageText.color = color;
    }

}
