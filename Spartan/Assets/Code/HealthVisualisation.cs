using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthVisualisation : MonoBehaviour {

    public HealthIcon firstHp;
    public HealthIcon secondHp;
    public HealthIcon thirdHp;
    public HealthIcon forthHp;
    public HealthIcon fifthHp;

    public void UpdateHpMeter(int health) {
        switch (health) {
            case 5: {
                firstHp.Show();
                secondHp.Show();
                thirdHp.Show();
                forthHp.Show();
                fifthHp.Show();
                return;
            }

            case 4: {
                firstHp.Show();
                secondHp.Show();
                thirdHp.Show();
                forthHp.Show();
                fifthHp.Hide();
                return;
            }

            case 3: {
                firstHp.Show();
                secondHp.Show();
                thirdHp.Show();
                forthHp.Hide();
                fifthHp.Hide();
                return;
            }

            case 2: {
                firstHp.Show();
                secondHp.Show();
                thirdHp.Hide();
                forthHp.Hide();
                fifthHp.Hide();
                return;
            }

            case 1: {
                firstHp.Show();
                secondHp.Hide();
                thirdHp.Hide();
                forthHp.Hide();
                fifthHp.Hide();
                return;
            }

            case 0: {
                firstHp.Hide();
                secondHp.Hide();
                thirdHp.Hide();
                forthHp.Hide();
                fifthHp.Hide();
                return;
            }

            default: {
                firstHp.Hide();
                secondHp.Hide();
                thirdHp.Hide();
                forthHp.Hide();
                fifthHp.Hide();
                return;
            }
        }
    }
}