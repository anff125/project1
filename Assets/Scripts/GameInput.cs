using UnityEngine;


public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private PlayerControl _playerInputActions;

    private void Awake()
    {
        Instance = this;

        _playerInputActions = new PlayerControl();
        _playerInputActions.Player.Enable();
    }

    public Vector2 GetMovementVector()
    {
        return _playerInputActions.Player.Move.ReadValue<Vector2>();
    }
    
    private void OnDestroy()
    {
        _playerInputActions.Dispose();
    }
}