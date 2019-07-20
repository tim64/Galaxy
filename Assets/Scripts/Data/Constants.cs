public static class Constants
{
	#region Fleet Params
	//Урон, который наносится противником если он врезается в игрока
	public static int EXPLOSION_DMG = 20;

	//Максимальное кол-во уникальных спайтов-кораблей
	public static int MAX_SHIP_NUM = 16;

	//Размер сетки генерации, по умолчанию
    public static int GRID_SIZE = 5;

	//Смещение флотов по горизонтали, при генерации сеткой
	public static int FLEET_HORIZONTAL_INDEX = 3;

	//Скорость вызова кораблей для атаки
	public static int FLEET_ATTACK_RATE = 2;
	#endregion

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

	//Время появления босса в вступлении
	public static int BOSS_INTRO_TIME = 5;
	#endregion

	#region Scenes
	public static int SCENE_MENU = 1;
	public static int SCENE_LEVELS = 2;
	public static int SCENE_LOADING = 3;
	public static int SCENE_GAME = 4;
	#endregion

	#region Base Ship Params
	public static float BASE_SHIP_SHOOT_RATE = 1;
	public static float BASE_SHIP_ROTATE_SPEED = 5;
	public static float BASE_SHIP_SHOOT_FORCE = 4;
	public static float BASE_SHIP_FLY_SPEED = 6;
	public static float BASE_SHIP_DAMAGE = 3;
	public static float SHOOT_RATE_MAX = 5;
	#endregion

	#region Angry Ship Params
	//Параметры злого корабля

	public static float ANGRY_SHIP_DAMAGE = 6;
	public static float ANGRY_SHIP_SHOOT_FORCE = 5;

	//Период яростной атаки
	public static float ANGRY_SHIP_RAGE_RATE = 3;

	//Продолжительность яростной атаки
	public static float ANGRY_SHIP_RAGE_TIME = 5;

	//Скорость атаки при ярости
	public static float ANGRY_SHIP_RAGE_SHOOT_RATE = 8;

	//Обычная скорость атаки
	public static float ANGRY_SHIP_SHOOT_RAGE = 2;
	#endregion

	#region Boss Params
	public static float BOSS_SHOOT_RATE = 3;
	public static float BOSS_DAMAGE = 5;
	public static float BOSS_SHOOT_FORCE = 8;
	#endregion

	#region Boss Gun Params
	public static float BOSS_GUN_SHOOT_RATE = 5;
	public static float BOSS_GUN_DAMAGE = 10;
	public static float BOSS_GUN_FORCE = 15;
	#endregion

	#region Pool Params
	public static float BULLET_DESTROY_TIME = 10f;
	#endregion

	#region Player Params
	public static float PLAYER_SPEED = 2;
	public static float PLAYER_RELOADING_TIME = 0.2f;
	public static float PLAYER_SHOOT_FORCE = 10;
	public static float PLAYER_MAX_HP = 100;
	#endregion


}