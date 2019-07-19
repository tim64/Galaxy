using UnityEngine;

/// <summary>
/// Класс расширений для работы с объектами-кораблями
/// </summary>
public static class ShipExtensions
{
	// FIXME: Перемотреть логику под SOLID

	/// <summary>
	/// Получаем спрайт корабля из файлов, по номеру
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public static Sprite GetSpriteFromIndex(int index)
	{
		string spriteName = Constants.SHIP_PREFIX + index.ToString();
		Sprite newSprite = Resources.Load<Sprite>(Constants.SHIP_SPRITE_PATH + spriteName);
		return newSprite;
	}

	/// <summary>
	/// Метод возвращает случайный спрайт корабля
	/// </summary>
	/// <returns></returns>
	public static Sprite GetRandomShipSprite()
    {
		int randomNum = Random.Range(1, Constants.MAX_SHIP_NUM);
        string spriteName = Constants.SHIP_PREFIX + randomNum.ToString();
        Sprite newSprite = Resources.Load<Sprite>(Constants.SHIP_SPRITE_PATH + spriteName);
        return newSprite;
    }

	/// <summary>
	/// Метод создает позицию корабля по его положении в сетке
	/// </summary>
	/// <param name="numX"></param>
	/// <param name="numY"></param>
	/// <returns></returns>
	public static Vector3 GetNewShipPosition(int numX, int numY)
    {
        float y = numX * Constants.GRID_SIZE;
        float x = numY * Constants.GRID_SIZE;
        Vector3 newPosition = new Vector3(x, y, 0);
        return newPosition;
    }
}
