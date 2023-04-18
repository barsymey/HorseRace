using UnityEngine;
using UnityEngine.UI;

public class BetScreen : MonoBehaviour
{
    public delegate void BidMadeCallback(int bid, int number);
    
    [SerializeField] Text pointsText;
    [SerializeField] Text choisenNumberText;
    [SerializeField] InputField bidInput;
    [SerializeField] Button betButton;

    private int _avaliablePoints;
    BidMadeCallback _callback;
    private int _choisenNumber;
    private int _bid;


    public void Show(int maxPointsToBet, BidMadeCallback callback)
    {
        _callback = callback; 
        _avaliablePoints = maxPointsToBet;
        _choisenNumber = 1;
        pointsText.text = "Points avaliable: " + _avaliablePoints.ToString();
        bidInput.text = 0.ToString();
        gameObject.SetActive(true);
        UpdateChoisenNumberText();
        
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void MakeBidButtonAction()
    {
        MakeBid(_bid, _choisenNumber);
    }

    public void BidNumberButtonAction(int number)
    {
        _choisenNumber = number;
        UpdateChoisenNumberText();
    }

    public void SetBidButtonAction(int amount)
    {
        bidInput.text = amount.ToString();
    }

    public void OnBidChanged()
    {
        _bid = int.Parse(bidInput.text);
        betButton.interactable = (_bid <= _avaliablePoints);
    }

    void MakeBid(int bid, int number)
    {
        _callback(bid, number);
        Hide();
    }

    void UpdateChoisenNumberText()
    {
        choisenNumberText.text = "Bet on horse #" + _choisenNumber;
    }
}