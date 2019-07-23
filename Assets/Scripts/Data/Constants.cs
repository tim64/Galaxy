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
	public static int FLEET_ATTACK_RATE = 5;

	public static int FLEET_MOVE_TIME_X = 2;
	public static int FLEET_MAX_POS_X = 10;
	public static int FLEET_CURRENT_POS_X = 5;
	#endregion

	#region Path and Prefix
	//Различные пути и префиксы

	//Пусть к конфигам миров
	public static string JSON_PATH_LEVEL_FOLDER = "Data/Level Configs/";
	public static string JSON_PATH_LEVEL_FILENAME = "Level";
	public static string JSON_PATH_LEVEL = JSON_PATH_LEVEL_FOLDER + JSON_PATH_LEVEL_FILENAME;

	//Название папки с ресурсами
	public static string RESOURCES_PATH = "/Resources/";

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

	#region Boss Mega Ship
	//Время спавна кораблей поддрержки
	public static float BOSS_JET_SPAWN_TIME = 1;
	#endregion


	#region Boss Alien Ship
	//Общее время перемещения корабля босса по оси Х
	public static float BOSS_HORIZONTAL_FLY_PERIOD = 6;

	//Время перемещения корабля босса по оси Х
	public static float BOSS_HORIZONTAL_FLY_TIME = 2;

	//Крайняя координата перемещения босса по оси Х
	public static float BOSS_HORIZONTAL_MAX_X = 15;
	#endregion

	#region Scenes
	public static int SCENE_MENU = 0;
	public static int SCENE_LEVELS = 1;
	public static int SCENE_GAME = 2;
	#endregion

	#region Base Ship Params
	public static float BASE_SHIP_SHOOT_RATE = 0.1f;
	public static float BASE_SHIP_ROTATE_SPEED = 5;
	public static float BASE_SHIP_SHOOT_FORCE = 2;
	public static float BASE_SHIP_FLY_SPEED = 3;
	public static float BASE_SHIP_DAMAGE = 3;
	public static float SHOOT_RATE_MAX = 5;
	public static float BASE_SHIP_CRUSH_DAMAGE = 20;
	public static float BASE_SHIP_HP = 20;
	#endregion

	#region Angry Ship Params
	//Параметры злого корабля

	public static float ANGRY_SHIP_DAMAGE = 6;
	public static float ANGRY_SHIP_SHOOT_FORCE = 4;

	//Период яростной атаки
	public static float ANGRY_SHIP_RAGE_PERIOD = 3;

	//Продолжительность яростной атаки
	public static float ANGRY_SHIP_RAGE_ANIMATION_TIME = 5;

	//Скорость атаки при ярости
	public static float ANGRY_SHIP_RAGE_SHOOT_RATE = 3;

	//Обычная скорость атаки
	public static float ANGRY_SHIP_SHOOT_RAGE = 0.5f;
	#endregion

	#region Teleport ship
	public static float TELEPORT_SHIP_RADIUS = 5;

	public static float TELEPORT_SHIP_JUMP_PERIOD = 10;
	#endregion

	#region Boss Params
	public static float BOSS_SHOOT_RATE = 10;
	public static float BOSS_DAMAGE = 5;
	public static float BOSS_SHOOT_FORCE = 8;
	public static float BOSS_HP = 200;
	#endregion

	#region Boss Gun Params
	public static float BOSS_GUN_SHOOT_RATE = 15;
	public static float BOSS_GUN_DAMAGE = 10;
	public static float BOSS_GUN_FORCE = 15;
	#endregion

	#region Player Params
	public static float PLAYER_SPEED = 2;
	public static float PLAYER_RELOADING_TIME = 0.2f;
	public static float PLAYER_SHOOT_FORCE = 10;
	public static float PLAYER_MAX_HP = 100;
	public static float PLAYER_MAX_X_POSITION = 20;
	public static float PLAYER_DAMAGE = 7;
	#endregion

	#region Pool Id's
	public static int POOL_BULLET_ID = 1;
	public static int POOL_PLAYER_BULLET_ID = 2;
	public static int POOL_BOSS_SHIP_ID = 3;
	public static int POOL_EXPLOSION_ID = 4;
	public static int POOL_TELEPORT_FX_ID = 5;
	#endregion

	#region Timing
	public static float END_GAME_PAUSE_TIME = 2f;
	#endregion

}