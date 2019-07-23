using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static Constants;

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
	/// Метод создает экземпляр класса World из JSON, по указанному индексу уровня
	/// </summary>
	/// <param name="currentlevelIndex"></param>
	/// <returns></returns>
	public static Level CreateFromJSON(int currentlevelIndex)
    {
		//Исключение отрицательных значений
		int levelIndex = Mathf.Abs(currentlevelIndex);

		var levelsPath =Application.dataPath + RESOURCES_PATH + JSON_PATH_LEVEL_FOLDER;
		DirectoryInfo d = new DirectoryInfo(levelsPath);
		int levelCount = FileHelper.JSONFileCount(d);

		//Проверка на невозможный номер уровня
		//Если индекс больше максимального, то загружаем последний уровень
		if (levelIndex > levelCount)
		{
			levelIndex = levelCount;
		}


		var filePath = JSON_PATH_LEVEL + levelIndex;
		Debug.Log(filePath);
		if (newWorld != null)
		{
			return newWorld;
		}
		else
		{
			var jsonTextFile = Resources.Load<TextAsset>(filePath);
			newWorld = JsonUtility.FromJson<Level>(jsonTextFile.text);
			return newWorld;
		}
    }
}
