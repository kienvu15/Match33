using Match3Core;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GemType type { get; private set; }
    public GridPosition gridPos { get; private set; }

    [SerializeField] SpriteRenderer spriteRenderer;
    
    public void Inittialize(GemType gemType, GridPosition gridPosition)
    {
        type = gemType;
        gridPos = gridPosition;
        SetColor();

        //SetWorldPosition(new Vector3(gridPos.x, gridPos.y));

        gameObject.SetActive(false);
    }

    public void SetColor()
    {
        Color color = type switch
        {
            GemType.Red => Color.red,
            GemType.Blue => Color.blue,
            GemType.Green => Color.green,
            GemType.Orange => new Color(255, 94, 0),
            GemType.Yellow => Color.yellow,
            GemType.None => Color.cyan,
        };
        spriteRenderer.color = color;
    }

    void SetGridPosition(GridPosition gridPosition) => gridPos = gridPosition;
    void SetWorldPosition(Vector3 Worldpos) => transform.position = Worldpos;
}
