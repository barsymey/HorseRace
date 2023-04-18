using UnityEngine;

public class RaceManager : MonoBehaviour
{
    int points;

    [SerializeField] private RaceTrack[] _tracks;
    [SerializeField] private float _raceDistance = 100;
    [SerializeField] private BetScreen _betScreen;
    private bool _raceIsOn;
    private int _bet;
    private int _choisenNumber;
    
    void Update()
    {
        CheckTracks();
    }

    public void StartGame()
    {
        points = 100;
        ResetTracks();
        OpenBetScreen();
    }

    void OnRaceOver(int winner)
    {
        _raceIsOn = false;
        if(_choisenNumber == winner)
            points += _bet*2;
        else
            points -= _bet;
        OpenBetScreen();
    }

    void CheckTracks()
    {
        if(!_raceIsOn)
            return;
        for(int i = 0; i < _tracks.Length; i++)
        {
            if(_tracks[i].CheckFinnish())
            {
                OnRaceOver(i+1);
                ResetTracks();
            }
        }
    }

    void ResetTracks()
    {
        foreach(RaceTrack track in _tracks)
            track.ResetTrack(_raceDistance);
    }

    void OpenBetScreen()
    {
        _betScreen.Show(points, PlaceBid);
    }

    void PlaceBid(int bid, int number)
    {
        _bet = bid;
        _choisenNumber = number;
        _raceIsOn = true;
    }
}