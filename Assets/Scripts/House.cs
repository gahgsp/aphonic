using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class House : MonoBehaviour
{
    
    // TODO: Have different sprites here...
    public GameObject letterSign;

    // Every house starts receiving a letter
    private bool _isReceivingLetter = true;

    public bool IsReceivingLetter
    {
        get => _isReceivingLetter;
        set => _isReceivingLetter = value;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isReceivingLetter)
        {
            letterSign.SetActive(true);
        }
        else
        {
            letterSign.SetActive(false);
        }
    }
    public void DeliverLetter()
    {
        _isReceivingLetter = false;
    }
}
