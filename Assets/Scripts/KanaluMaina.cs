using UnityEngine;

public class KanaluMaina : MonoBehaviour
{
    [SerializeField] private GameObject[] channels;
    private int currentChannel = 0;

    private void Start()
    {
        ShowChannel(currentChannel);
    }

    public void NextChannel()
    {
        currentChannel++;
        if (currentChannel >= channels.Length)
            currentChannel = 0;

        ShowChannel(currentChannel);
    }

    public void PreviousChannel()
    {
        currentChannel--;
        if (currentChannel < 0)
            currentChannel = channels.Length - 1;

        ShowChannel(currentChannel);
    }

    private void ShowChannel(int index)
    {
        for (int i = 0; i < channels.Length; i++)
            channels[i].SetActive(i == index);
    }
}
