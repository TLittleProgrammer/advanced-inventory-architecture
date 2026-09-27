# Advanced Inventory Architecture

Unity-проект с системой инвентаря, загрузкой UI через Addressables, данными предметов в коде и локальными пакетами для общих примитивов, game data и MVC-контроллеров.

## Версия Unity

Проект создан для Unity `6000.6.0f1`.

## Запуск

1. Откройте папку проекта в Unity.
2. Откройте сцену `Assets/Scenes/MainScene.unity`.
3. Запустите Play Mode.
4. Выберите предмет в выпадающем списке.
5. Нажмите кнопку добавления предмета.
6. Для объединения одинаковых предметов перетащите один слот на другой.

## Основные Возможности

- 32 слота инвентаря.
- 32 типа предметов в `ResourceType`.
- Добавление предметов через dropdown и кнопку.
- Хранение количества предметов в слоте.
- Ограничение максимального количества через данные предмета.
- Обновление UI слота при изменении модели.
- Drag-and-drop между слотами.
- Объединение одинаковых предметов при drop на другой слот.
- Загрузка prefab слота через Addressables по ключу `inventory_item`.
- Загрузка sprite atlas через Addressables по ключу `inventory_icons`.

## Структура Проекта

```text
Assets/
├── Content/                    # иконки, sprite atlas, prefab слота, UI-ассеты
├── Scenes/                     # MainScene
├── Scripts/
│   ├── Camera/                 # модель камеры и загрузчик механики
│   ├── EntryPoint/             # запуск и остановка проекта
│   ├── GameData/               # данные инвентаря, предметов и атласов
│   ├── Infrastructure/         # GameContext и контейнеры моделей
│   ├── Inventory/              # модель инвентаря, UI-контроллеры, слоты
│   ├── Logger/                 # интерфейс логгера и Unity-реализация
│   ├── Spritesheets/           # загрузка и хранение sprite atlas
│   └── Wrappers/               # компоненты для drag-and-drop
└── TextMesh Pro/

LocalPackages/
├── common/                     # коллекции и reactive-примитивы
├── game_data/                  # generic-хранилища данных и тесты
└── mvc/                        # контракты MVC и Addressables loader
```

## Поток Инициализации

1. `EntryPoint` создаёт `GameContext`.
2. `StepsLoader` запускает загрузчики.
3. `MechanicsLoader` последовательно подключает logger, camera, spritesheets и inventory.
4. `GameContext` хранит `GameDataContainer`, список контроллеров, модели и logger.
5. `InventoryMechanicLoader` создаёт `InventoryModel`, регистрирует setup-контроллеры и UI-контроллеры.
6. `StartControllersLoader` активирует зарегистрированные контроллеры.

## Инвентарь

Код инвентаря находится в `Assets/Scripts/Inventory`.

Основные классы:

- `InventoryModel` хранит коллекцию `InventorySlotModel`.
- `InventorySlotModel` хранит индекс слота, тип ресурса, количество, прямоугольник слота и события обновления.
- `BaseResource` содержит `ResourceType` и `Amount`.
- `InventorySetUpControllers` создаёт слоты по значению из `InventoryData`.
- `InventorySlotCollectionController` создаёт контроллер загрузки UI для каждого слота.
- `InventorySlotLoadController` загружает prefab слота через Addressables.
- `InventorySlotUpdateController` обновляет иконку, количество и raycast-состояние слота.
- `InventorySlotDragAndDropController` обрабатывает перетаскивание.
- `InventorySlotDropController` вызывает объединение слотов.

Добавление предмета выполняется через `InventoryModel.AddItemByIndex`. Индекс из dropdown приводится к `ResourceType`, после чего предмет добавляется в первый пустой слот или в слот с таким же типом ресурса.

Объединение слотов выполняется через `InventoryModel.TryMerge`. Метод работает только для одинаковых `ResourceType` и учитывает `MaxCount` из данных предмета.

## Данные

Данные проекта находятся в `Assets/Scripts/GameData`.

- `GameDataContainer` создаёт коллекции данных.
- `InventoryFillableData` задаёт размер инвентаря: `32`.
- `InventoryResourcesFillableGameData` задаёт список предметов, имя, `MaxCount` и ссылку на sprite.
- `AtlasesFillableData` задаёт список atlas id для загрузки.
- `SpriteData` хранит `atlasId` и `spriteId`.

Все текущие предметы используют atlas id `inventory_icons` и `MaxCount = 64`.

## Addressables

В проекте используются два ключа Addressables:

- `inventory_item` — prefab слота из `Assets/Content/Inventory/ItemPrefab.prefab`.
- `inventory_icons` — sprite atlas из `Assets/Content/icons.spriteatlas`.

`CollectionLoadController<TContainer>` загружает prefab, создаёт instance и подключает контроллеры к созданному контейнеру.

`SpriteSheetsController` загружает `SpriteAtlas`, сохраняет его в `SpriteSheetsModel` и отдаёт sprite по данным `SpriteData`.

## UI

UI-ссылки хранятся в контейнерах:

- `InventoryContainer`
- `InventoryDropdownContainer`
- `InventorySlotContainer`
- `SceneContainer`
- `LocationContainer`

Контейнеры являются `MonoBehaviour` и используются для связи сцены с контроллерами.

## Локальные Пакеты

### `common`

Содержит:

- `ICollection<TType>`
- `Trigger`
- `Trigger<T>`
- `Trigger<T1, T2>`
- `ReactiveCollection<T>`
- `ReactiveDictionary<TKey, TValue>`
- `ReactiveProperty<T>`

### `game_data`

Содержит:

- `IGameData`
- `IFillableGameData`
- `FillableGameData`
- `GameDataCollection`
- `SimpleData`
- `SimpleGameData`

Также содержит EditMode-тесты для `GameDataCollection`.

### `mvc`

Содержит:

- `IModel`
- `IView`
- `IController`
- `ControllersCollection`
- `ReactiveCollectionController`
- `ReactiveDictionaryController`
- `CollectionLoadController<TContainer>`

## Тесты

Тесты находятся в `LocalPackages/game_data/Tests`.

Покрытые сценарии:

- получение данных по ключу;
- получение данных через индексатор;
- обход коллекции через `foreach`.

## Зависимости

Основные зависимости из `Packages/manifest.json`:

- `com.unity.addressables`
- `com.unity.ugui`
- `com.unity.2d.sprite`
- `com.unity.ide.rider`
- `com.unity.ide.visualstudio`
- `com.unity.modules.ui`
- `com.unity.modules.uielements`

Локальные зависимости:

- `common`
- `game_data`
- `mvc`
