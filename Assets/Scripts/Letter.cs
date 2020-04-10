using UnityEngine;

public class Letter
{
    public GameObject FromHouse
    {
        get => _fromHouse;
        set => _fromHouse = value;
    }

    public GameObject ToHouse
    {
        get => _toHouse;
        set => _toHouse = value;
    }

    private GameObject _fromHouse;
    private GameObject _toHouse;
    
}
