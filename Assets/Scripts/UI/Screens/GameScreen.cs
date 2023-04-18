using UnityEngine;

public class GameScreen : UIScreen
{
    [SerializeField] private RaceManager _raceManager;

    public override void Show()
    {
        base.Show();
        _raceManager.StartGame();
    }
}
