using Configs;
using UnityEngine;

public class Main : MonoBehaviour
{
     private SpriteAnimatorConfig _playerAnimatorConfig;
    [SerializeField] private int _animaationSpeed;
    [SerializeField] private LevelObjectView _playerView;

    private SpriteAnimatorController _playerAnimator;
    private CameraController _cameraController;
    private PlayerController _playerController;

    private void Start()
    {
        
        _playerAnimatorConfig = Resources.Load<SpriteAnimatorConfig>(path: "PlayerAnimatorConfig");
        if (_playerAnimatorConfig)
        {
            _playerAnimator = new SpriteAnimatorController(_playerAnimatorConfig);
            
        }

        _cameraController = new CameraController(_playerView.PlayerTransform, camera: Camera.main.transform);
        _playerController = new PlayerController(_playerView, _playerAnimator);
    }

    private void Update()
    {
        _playerController.Update();
        _cameraController.Update();

    }
}
