using UnityEngine;
using UnityEngine.UI;

public class UIMessageHandler : MonoBehaviour
{
    public static UIMessageHandler Instance { get; private set; }
    public Text messageText;
    public float displayDuration = 2f;
    private float timer = 0f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        if (messageText == null)
            messageText = GetComponentInChildren<Text>();
        if (messageText != null)
            messageText.text = "";
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0 && messageText != null)
                messageText.text = "";
        }
    }

    public void ShowMessage(string msg)
    {
        if (messageText != null)
        {
            messageText.text = msg;
            timer = displayDuration;
        }
    }
}