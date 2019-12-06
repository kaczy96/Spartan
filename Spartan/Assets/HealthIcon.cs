using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIcon : MonoBehaviour {
    [SerializeField] GameObject image;
    [SerializeField] GameObject particles;

    public void Show() {
        image.gameObject.SetActive(true);
    }

    public void Hide() {
        if(image.gameObject.activeSelf)
            particles.SetActive(true);
        image.gameObject.SetActive(false);
    }
}
