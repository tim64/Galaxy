using UnityEngine;
using static Constants;

[System.Serializable]
/// <summary>
/// Класс описывает игровой уровень и его параметры. 
/// Все параметры берутся из JSON
/// </summary>
public class Level
{
	public static Level currentLevelData;

	[SerializeField]
	private string _levelId;

	[SerializeField] 
    private string _levelName;

    [SerializeField] 
    private int _shipCount;

	[SerializeField]
	private int _difficulty;

	[SerializeField]
	private int _bossType;

	/// <summary>
	/// ID текущего уровня
	/// </summary>
	public string LevelId => _levelId;

	/// <summary>
	/// Название уровня
	/// </summary>
	public string LevelName { get => _levelName; set => _levelName = value; }

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
	/// Метод создает экземпляр класса Level из JSON, по указанному индексу уровня
	/// </summary>
	/// <param name="currentlevelIndex"></param>
	/// <returns></returns>
	public static Level CreateFromJSON(int currentlevelIndex)
    {
		//Исключение отрицательных значений
		int levelIndex = Mathf.Abs(currentlevelIndex);

		int levelCount = MAX_JSON_LEVEL_FILE;


		//Проверка на невозможный номер уровня
		//Если индекс больше максимального, то загружаем последний уровень
		if (levelIndex > levelCount)
		{
			levelIndex = levelCount;
			CDebug.LogError("Invalid level index. Load Last level!");
		}

		var filePath = JSON_PATH_LEVEL + levelIndex;
		var jsonTextFile = Resources.Load<TextAsset>(filePath);
		currentLevelData = JsonUtility.FromJson<Level>(jsonTextFile.text);

		return currentLevelData;
    }
}
