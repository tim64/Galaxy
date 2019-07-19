public static class Constants
{
	//Урон, который наносится противником если он врезается в игрока
	public static int EXPLOSION_DMG = 20;

	//Максимальное кол-во уникальных спайтов-кораблей
	public static int MAX_SHIP_NUM = 16;

	//Размер сетки генерации, по умолчанию
    public static int GRID_SIZE = 5;

	//Смещение флотов по горизонтали, при генерации сеткой
	public static int FLEET_HORIZONTAL_INDEX = 3;

	#region Path and Prefix
	//Различные пути и префиксы

	//Пусть к конфигам миров
	public static string JSON_PATH_WORLD1 = "Data/World Configs/World1";

	//Путь к папке с спрайтами кораблей
	public static string SHIP_SPRITE_PATH = "Ships/";

	//Префикс файлов спрайтов кораблей
	public static string SHIP_PREFIX = "ship_";
	#endregion

	#region Boss Params
	//Параметры босса

	//Скорость босса
	public static float BOSS_SPEED = 2;

	//Ширина полета босса при движении воьмеркой
	public static float BOSS_X_PATH_SCALE = 15;

	//Высота полета босса при движении воьмеркой
	public static float BOSS_Y_PATH_SCALE = 6;
	#endregion
}
