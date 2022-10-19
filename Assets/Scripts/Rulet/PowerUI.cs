using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PowerUI : MonoBehaviour
{
    [SerializeField] private PowerRuletScript _powerRuletScript;

    private float _speed => _powerRuletScript.ImageVelocity;

    private bool isSpin => _powerRuletScript.isSpinRulet;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > _powerRuletScript.LimitPos.position.y)
        {
            transform.position= _powerRuletScript.SpawnPos.position;
        }

        if (isSpin)
        {
             transform.position = new Vector3(transform.position.x,transform.position.y + _speed * Time.deltaTime,transform.position.z);
        }
       
    }
}
