using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public enum EndState
{
    NONE,
    GOOD,
    FINE,
    BAD,
}

public class EndScreen : MonoBehaviour
{
    [SerializeField]
    Text m_mainText;
    [SerializeField]
    Text m_descriptionText;
    [SerializeField]
    Image m_statusSprite;

    [SerializeField]
    string[] m_endPhraseGoodList;

    [SerializeField]
    string[] m_endPhraseFineList;

    [SerializeField]
    string[] m_endPhraseBadList;

    public void UpdateContent(EndState endState, float totalTimeSeconds)
    {
        int randomSelection = 0;

        switch (endState)
        {
            case EndState.GOOD:
                randomSelection = Random.Range(0, m_endPhraseGoodList.Length);
                m_mainText.text = m_endPhraseGoodList[randomSelection];
                break;
            case EndState.FINE:
                randomSelection = Random.Range(0, m_endPhraseFineList.Length);
                m_mainText.text = m_endPhraseFineList[randomSelection];
                break;
            default:
                randomSelection = Random.Range(0, m_endPhraseBadList.Length);
                m_mainText.text = m_endPhraseBadList[randomSelection];
                break;
        }

        m_descriptionText.text = $"your baby survived for {totalTimeSeconds.ToString("0.0")} seconds";
    }
}