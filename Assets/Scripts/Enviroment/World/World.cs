using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/// <summary>
/// Класс описывает игровой уровень и его параметры. 
/// Все параметры берутся из JSON
/// </summary>
public class World
{
	[SerializeField]
	private string _worldId;

	[SerializeField] 
    private string _worldName;

    [SerializeField] 
    private int _shipCount;

	[SerializeField]
	private int _difficulty;

	/// <summary>
	/// ID текущего уровня
	/// </summary>
	public string WorldId { get => _worldId; set => _worldId = value; }

	/// <summary>
	/// Название уровня
	/// </summary>
	public string WorldName { get => _worldName; set => _worldName = value; }

	/// <summary>
	/// Максимальное кол-во кораблей, которые будут на уровне
	/// </summary>
	public int ShipCount { get => _shipCount; set => _shipCount = value; }

	/// <summary>
	/// Сложность уровня
	/// </summary>
	public int Difficulty { get => _difficulty; set => _difficulty = value; }

	/// <summary>
	/// Метод создает экземпляр класса World из JSON, по указанному пути
	/// </summary>
	/// <param name="jsonString"></param>
	/// <returns></returns>
	public static World CreateFromJSON(string jsonString)
    {
        var jsonTextFile = Resources.Load<TextAsset>(jsonString);
        World newWorld =  JsonUtility.FromJson<World>(jsonTextFile.text);
        return newWorld;
    }
}
