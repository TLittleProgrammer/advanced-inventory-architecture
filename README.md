# Advanced Inventory Architecture

Unity project with an inventory system, UI loading via Addressables, item data in code, and local packages for common primitives, game data, and MVC controllers.

## Unity Version

The project is created for Unity `6000.6.0f1`.

## Getting Started

1. Open the project folder in Unity.
2. Open the scene `Assets/Scenes/MainScene.unity`.
3. Enter Play Mode.
4. Select an item from the dropdown.
5. Click the add item button.
6. To merge identical items, drag one slot onto another.

## Key Features

- 32 inventory slots.
- 32 item types in `ResourceType`.
- Add items via dropdown and button.
- Store item quantities in a slot.
- Limit maximum quantity via item data.
- Update slot UI when the model changes.
- Drag-and-drop between slots.
- Merge identical items when dropped onto another slot.
- Load slot prefab via Addressables using the key `inventory_item`.
- Load sprite atlas via Addressables using the key `inventory_icons`.

## Project Structure

```text
Assets/
├── Content/                    # icons, sprite atlas, slot prefab, UI assets
├── Scenes/                     # MainScene
├── Scripts/
│   ├── Camera/                 # camera model and mechanics loader
│   ├── EntryPoint/             # project start and stop
│   ├── GameData/               # inventory, item, and atlas data
│   ├── Infrastructure/         # GameContext and model containers
│   ├── Inventory/              # inventory model, UI controllers, slots
│   ├── Logger/                 # logger interface and Unity implementation
│   ├── Spritesheets/           # sprite atlas loading and storage
│   └── Wrappers/               # components for drag-and-drop
└── TextMesh Pro/

LocalPackages/
├── common/                     # collections and reactive primitives
├── game_data/                  # generic data storages and tests
└── mvc/                        # MVC contracts and Addressables loader
```

## Initialization Flow

1. `EntryPoint` creates `GameContext`.
2. `StepsLoader` runs loaders.
3. `MechanicsLoader` sequentially connects logger, camera, spritesheets, and inventory.
4. `GameContext` stores `GameDataContainer`, a list of controllers, models, and logger.
5. `InventoryMechanicLoader` creates `InventoryModel`, registers setup controllers and UI controllers.
6. `StartControllersLoader` activates registered controllers.

## Inventory

The inventory code is located in `Assets/Scripts/Inventory`.

Main classes:

- `InventoryModel` stores a collection of `InventorySlotModel`.
- `InventorySlotModel` stores slot index, resource type, quantity, slot rectangle, and update events.
- `BaseResource` contains `ResourceType` and `Amount`.
- `InventorySetUpControllers` creates slots based on the value from `InventoryData`.
- `InventorySlotCollectionController` creates a UI load controller for each slot.
- `InventorySlotLoadController` loads the slot prefab via Addressables.
- `InventorySlotUpdateController` updates the slot's icon, quantity, and raycast state.
- `InventorySlotDragAndDropController` handles dragging.
- `InventorySlotDropController` triggers slot merging.

Adding an item is done via `InventoryModel.AddItemByIndex`. The index from the dropdown is cast to `ResourceType`, after which the item is added to the first empty slot or a slot with the same resource type.

Merging slots is done via `InventoryModel.TryMerge`. The method works only for identical `ResourceType` and takes into account `MaxCount` from the item data.

## Data

Project data is located in `Assets/Scripts/GameData`.

- `GameDataContainer` creates data collections.
- `InventoryFillableData` sets the inventory size: `32`.
- `InventoryResourcesFillableGameData` sets the list of items, name, `MaxCount`, and sprite reference.
- `AtlasesFillableData` sets the list of atlas ids to load.
- `SpriteData` stores `atlasId` and `spriteId`.

All current items use atlas id `inventory_icons` and `MaxCount = 64`.

## Addressables

The project uses two Addressables keys:

- `inventory_item` — slot prefab from `Assets/Content/Inventory/ItemPrefab.prefab`.
- `inventory_icons` — sprite atlas from `Assets/Content/icons.spriteatlas`.

`CollectionLoadController<TContainer>` loads the prefab, creates an instance, and attaches controllers to the created container.

`SpriteSheetsController` loads the `SpriteAtlas`, stores it in `SpriteSheetsModel`, and returns a sprite based on `SpriteData`.

## UI

UI references are stored in containers:

- `InventoryContainer`
- `InventoryDropdownContainer`
- `InventorySlotContainer`
- `SceneContainer`
- `LocationContainer`

The containers are `MonoBehaviour` and are used to link the scene with controllers.

## Local Packages

### `common`

Contains:

- `ICollection<TType>`
- `Trigger`
- `Trigger<T>`
- `Trigger<T1, T2>`
- `ReactiveCollection<T>`
- `ReactiveDictionary<TKey, TValue>`
- `ReactiveProperty<T>`

### `game_data`

Contains:

- `IGameData`
- `IFillableGameData`
- `FillableGameData`
- `GameDataCollection`
- `SimpleData`
- `SimpleGameData`

Also contains EditMode tests for `GameDataCollection`.

### `mvc`

Contains:

- `IModel`
- `IView`
- `IController`
- `ControllersCollection`
- `ReactiveCollectionController`
- `ReactiveDictionaryController`
- `CollectionLoadController<TContainer>`

## Tests

Tests are located in `LocalPackages/game_data/Tests`.

Covered scenarios:

- retrieving data by key;
- retrieving data via indexer;
- iterating over the collection via `foreach`.

## Dependencies

Main dependencies from `Packages/manifest.json`:

- `com.unity.addressables`
- `com.unity.ugui`
- `com.unity.2d.sprite`
- `com.unity.ide.rider`
- `com.unity.ide.visualstudio`
- `com.unity.modules.ui`
- `com.unity.modules.uielements`

Local dependencies:

- `common`
- `game_data`
- `mvc`
