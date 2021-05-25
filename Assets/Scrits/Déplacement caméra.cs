using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Déplacementcaméra : MonoBehaviour
{

    public float _vitesseCameraBase;
    public float _vitesseCameraMax;
    private float _vitesseCameraActuelle;
    public float _combienDeVitesseTuPrendsParSeconde;
    private float _addedVitesseCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        _addedVitesseCamera += _combienDeVitesseTuPrendsParSeconde;
        _vitesseCameraActuelle = _vitesseCameraBase + _addedVitesseCamera;
        if (_vitesseCameraActuelle < _vitesseCameraMax)
        {
            _vitesseCameraActuelle = _vitesseCameraMax;
        }



    }
}
