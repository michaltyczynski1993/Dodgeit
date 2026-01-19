using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private bool isJoystickOn;
    [SerializeField] private Toggle joystickToggle;
    void Start()
    {
        isJoystickOn = PlayerPrefs.GetInt("VirtualJoystick", 1) == 1;
        joystickToggle.isOn = isJoystickOn;
    }

    public void ChangeJoystick()
    {
        if (isJoystickOn)
        {
            isJoystickOn = false;
            PlayerPrefs.SetInt("VirtualJoystick", 0);
            joystickToggle.isOn = isJoystickOn;
        }
        else
        {
            isJoystickOn = true;
            PlayerPrefs.SetInt("VirtualJoystick", 1);
            joystickToggle.isOn = isJoystickOn;
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
