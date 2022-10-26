using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : MonoBehaviour
{
    [SerializeField] private Transform newPos;
    [SerializeField] private Transform ControlPos;
    [SerializeField] private Transform VolumePos;

    [SerializeField] private Transform Panel;

    private bool ChangePos = false;

   [SerializeField] private float Speed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        newPos.transform.position = Panel.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Panel.transform.position.x != newPos.transform.position.x && ChangePos)
        {
            float vel = Speed * Time.deltaTime;
            Panel.transform.position = Vector2.MoveTowards(Panel.transform.position,
                new Vector2(newPos.transform.position.x,Panel.transform.position.y),vel);
        }
        else
        {
            ChangePos = false;
        }
    }

    public void ControlButton()
    {
        newPos.transform.position = ControlPos.transform.position;
        ChangePos = true;

    }
    public void VolButton()
    {
        newPos.transform.position = VolumePos.transform.position;
        ChangePos = true;
    }
}
