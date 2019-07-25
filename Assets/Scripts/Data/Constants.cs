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
	//Скорость перемещения босса по оси Х
	public static int FLEET_MOVE_TIME_X = 2;
	//Максимальное ограничение перемещения босса по оси Х
	public static int FLEET_MAX_POS_X = 10;
	//Ограничение перемещения босса по оси Х
	public static int FLEET_CURRENT_POS_X = 5;
	//Скорось спавна кораблей боссом
	public static float FLEET_SPAWN_ANIMATION_DELAY = 0.25f;
	#endregion

	#region Path and Prefix
	//Различные пути и префиксы
	//Пусть к конфигам уровней
	public static string JSON_PATH_LEVEL_FOLDER = "Data/Level Configs/";
	//Папка с уровнями
	public static string JSON_PATH_LEVEL_FILENAME = "Level";
	//Полный путь
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
	//ID сцены "Меню"
	public static int SCENE_MENU = 0;
	//ID сцены "Уровни"
	public static int SCENE_LEVELS = 1;
	//ID сцены "Игра"
	public static int SCENE_GAME = 2;
	#endregion

	#region Base Ship Params

	//Скорость стрельбы корабля
	public static float BASE_SHIP_SHOOT_RATE = 0.1f;
	//Скорость поворота корабля
	public static float BASE_SHIP_ROTATE_SPEED = 5;
	//Сила стрельбы
	public static float BASE_SHIP_SHOOT_FORCE = 1;
	//Скорость полета при атаке
	public static float BASE_SHIP_FLY_SPEED = 2;
	//Урон корабля
	public static float BASE_SHIP_DAMAGE = 2;
	//Максимальная скорость стрельбы при рандоме
	public static float SHOOT_RATE_MAX = 4;
	//Урон при лобовой атаке
	public static float BASE_SHIP_CRUSH_DAMAGE = 10;
	//Базовое здоровье корабля
	public static float BASE_SHIP_HP = 20;
	#endregion

	#region Angry Ship Params
	//Параметры злого корабля

	//Урон данного типа корабля
	public static float ANGRY_SHIP_DAMAGE = 2;
	//Сила стрельбы данного типа корабля
	public static float ANGRY_SHIP_SHOOT_FORCE = 3;
	//Период яростной атаки
	public static float ANGRY_SHIP_RAGE_PERIOD = 3;
	//Продолжительность яростной атаки
	public static float ANGRY_SHIP_RAGE_ANIMATION_TIME = 5;
	//Скорость атаки при ярости
	public static float ANGRY_SHIP_RAGE_SHOOT_RATE = 3;
	//Обычная скорость атаки
	public static float ANGRY_SHIP_SHOOT_RAGE = 0.2f;
	#endregion

	#region Teleport ship
	//Радиус для телепорта
	public static float TELEPORT_SHIP_RADIUS = 10;
	//Период телепортации
	public static float TELEPORT_SHIP_JUMP_PERIOD = 10;
	//Максимальный разброс ри телепорте
	public static float TELEPORT_RANDOM_MAX = 10;
	//Задержка эффекта телепортации
	public static float TELEPORT_FX_DELAY = 0.5f;
	#endregion

	#region Boss Params
	//Скорость стрельбы босса
	public static float BOSS_SHOOT_RATE = 10;
	//Урон босса
	public static float BOSS_DAMAGE = 5;
	//Сила стрельбы босса
	public static float BOSS_SHOOT_FORCE = 8;
	//Здоровье босса
	public static float BOSS_HP = 200;
	#endregion

	#region Boss Gun Params
	//Скорость тсрельбы пушки босса
	public static float BOSS_GUN_SHOOT_RATE = 15;
	//Урон пушки босса
	public static float BOSS_GUN_DAMAGE = 10;
	//Сила атаки пушки босса
	public static float BOSS_GUN_FORCE = 15;
	#endregion

	#region Player Params
	//Скорость игрока
	public static float PLAYER_SPEED = 2;
	//Перезарядка стрельбы
	public static float PLAYER_RELOADING_TIME = 0.2f;
	//Сила выстрела игрока
	public static float PLAYER_SHOOT_FORCE = 10;
	//Максимальное здоровье игрока
	public static float PLAYER_MAX_HP = 100;
	//Максимальная позиция по Х
	public static float PLAYER_MAX_X_POSITION = 20;
	//Урон игрока
	public static float PLAYER_DAMAGE = 7;
	#endregion

	#region Pool Id's
	//ID пула пуль
	public static int POOL_BULLET_ID = 1;

	//ID пула пуль игрока
	public static int POOL_PLAYER_BULLET_ID = 2;
	//ID кораблей, которыми спавнит босс
	public static int POOL_BOSS_SHIP_ID = 3;
	//ID пула вызрывов
	public static int POOL_EXPLOSION_ID = 4;
	//ID пула эффектов для телепорта
	public static int POOL_TELEPORT_FX_ID = 5;
	#endregion

	#region Timing
	//Время после заверешения игры и вызовом финиша
	public static float END_GAME_PAUSE_TIME = 2f;
	#endregion

	#region UI
	//Время анимации для интро-текста
	public static float CROSS_FADE_TIME = 2f;
	//Задержка анимации для интро-текста
	public static float CROSS_FADE_DALAY_TIME = 2f;

	#endregion

	#region Tags
	//Тэг игрока
	public static string PLAYER_TAG = "Player";
	//Тэг врага
	public static string ENEMY_TAG = "Enemy";
	//Тег пули врага
	public static string BULLET_ENEMY_TAG = "Bullet";
	//Тег пули игрока
	public static string BULLET_PLAYER_TAG = "PlayerBullet";

	#endregion

}