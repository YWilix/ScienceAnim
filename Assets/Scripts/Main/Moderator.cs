using UnityEngine;

public class Moderator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKey(KeyCode.Q))
        {
            Application.Quit();
        }
    }
}
