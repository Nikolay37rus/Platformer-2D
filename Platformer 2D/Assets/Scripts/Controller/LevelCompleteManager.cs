using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteManager : IDisposable
{
    private Vector3 _startPosition;
    private LevelObjectView _characterView;
    private List<LevelObjectView> _deathZones;
    private List<LevelObjectView> _winZones;

    public LevelCompleteManager(LevelObjectView characterView, List<LevelObjectView> deathZones, List<LevelObjectView> winZones)
    {
        _startPosition = characterView._Transform.position;
        characterView.OnObjectContact += OnLevelObjectContact;

        _characterView = characterView;
        _deathZones = deathZones;
        _winZones = winZones;
    }

    private void OnLevelObjectContact(LevelObjectView contactView)
    {
        if (_deathZones.Contains(contactView))
        {
            _characterView._Transform.position = _startPosition;
        }
    }

    public void Dispose()
    {
        _characterView.OnObjectContact -= OnLevelObjectContact;
    }

}
