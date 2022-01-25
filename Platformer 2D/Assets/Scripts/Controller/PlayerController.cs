using Configs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using View;

public class PlayerController 
{
    private float _xAxisInput;
    private bool _isJump;
    private bool _isMoving;

    private float _speed = 3f;
    private float _animationSpeed = 10f;
    private float _jumpSpeed = 9;
    private float _movingThreshHond = 0.1f;
    private float _jumpThreshHold = 1f;

    private float _earthGravitation = -9.8f;
    private float _yVelocity;
    private float _groundLevel;
    private Vector3 _leftScale = new Vector3(x: -1, y: 1, z: 1);
    private Vector3 _rightScale = new Vector3(x: 1, y: 1, z: 1);

    private LevelObjectView _playerView;
    private SpriteAnimatorController _animator;

    public PlayerController(LevelObjectView player, SpriteAnimatorController animator)
    {
        _playerView = player;
        _animator = animator;
        _animator.StartAnimation(_playerView.SpriteRenderer, track: AnimStatePlayer.Idle, loop: true, _animationSpeed);
    }


    public bool IsGrounded()
    {
        return _playerView.transform.position.y + float.Epsilon < _groundLevel && _yVelocity <= 0;
    }

    public void MoveTowards()
    {
        _playerView.transform.position += Vector3.right * (Time.deltaTime * _speed * (_xAxisInput < 0 ? -1 : 1));
        _playerView.transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
    }

    public void Update()
    {
        _animator.Update();
        _xAxisInput = Input.GetAxis("Horizontal");
        _isJump = Input.GetAxis("Vertical") > 0;
        if (_isMoving) MoveTowards();
        _isMoving = Mathf.Abs(_xAxisInput) > _movingThreshHond;

        if (IsGrounded())
        {
            _animator.StartAnimation
                (_playerView.SpriteRenderer, _isMoving ? AnimStatePlayer.Run : AnimStatePlayer.Idle, loop: true, _animationSpeed);
            if (_isJump && _yVelocity <=0)
            {
                _yVelocity = _jumpSpeed;
            }
            else if (_yVelocity < 0)
            {
                _yVelocity = float.Epsilon;
                _playerView.transform.position = _playerView.transform.position.Change(y: _groundLevel);
            }
            else
            {
                _yVelocity += _earthGravitation * Time.deltaTime;
                if (Mathf.Abs(_yVelocity) > _jumpThreshHold)
                {
                    _animator.StartAnimation
                        (_playerView.SpriteRenderer, track: AnimStatePlayer.Jump, loop: true, _animationSpeed);
                }

                _playerView.transform.position += Vector3.up * (_yVelocity * Time.deltaTime);
            }
        }
    }
}
