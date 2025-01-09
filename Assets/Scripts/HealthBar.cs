using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    /* assign health bar image in Inspector */
    [SerializeField] private Image healthFill;

    public void UpdateHealthBar(float current, float max)
    {
        /* update according to the total health left */
        healthFill.fillAmount = current/max;
    }
}
