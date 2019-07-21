using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/// <summary>
/// Класс описывает игровой уровень и его параметры. 
/// Все параметры берутся из JSON
/// </summary>
public class Level
{
	public static Level newWorld;

	[SerializeField]
	private string _worldId;

	[SerializeField] 
    private string _worldName;

    [SerializeField] 
    private int _shipCount;

	[SerializeField]
	private int _difficulty;

	[SerializeField]
	private int _bossType;

	/// <summary>
	/// ID текущего уровня
	/// </summary>
	public string WorldId => _worldId;

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
	/// Тип босса в конце уровня
	/// </summary>
	public int BossType { get => _bossType; set => _bossType = value; }

	/// <summary>
	/// Метод создает экземпляр класса World из JSON, по указанному пути
	/// </summary>
	/// <param name="jsonString"></param>
	/// <returns></returns>
	public static Level CreateFromJSON(string jsonString)
    {
		if (newWorld != null)
		{
			return newWorld;
		}
		else
		{
			var jsonTextFile = Resources.Load<TextAsset>(jsonString);
			newWorld = JsonUtility.FromJson<Level>(jsonTextFile.text);
			return newWorld;
		}
    }
}
