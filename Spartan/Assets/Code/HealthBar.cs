using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    public TitanController titanController;

    void Start()
    {
        titanController = GetComponent<TitanController>();
        Transform bar = transform.Find(("Bar"));
        bar.localScale = new Vector3(1f,1f);
    }

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized,1f);
    }

    private void Update()
    {
        //SetSize(titanController.titan.health);
    }
}
