# Last Stand

An AR zombie shooter for Android. Waves of zombies spawn on the real floor around you, and you aim by moving and turning your phone.

This was my first-semester project at IIT Roorkee (Aug to Nov 2023), built with Unity and ARCore. It's kept here as it was: raw, small, and the place I started.

## How it works

- **`SpawnPrefabOnTap`** raycasts a screen tap against the planes ARCore has found and places the arena there.
- **`ZombieSpawnr`** runs three spawn timers (regular zombies, big zombies and a boss) at four spawn points. Each interval shrinks over time down to a floor, so the waves get denser the longer you survive.
- **`KillCounter`** keeps score, and **`ChangeSc`** / **`Exit`** handle the Home, Options, Game and Game Over scenes.

## Opening the project

- Unity **2021.3.31f1** with Android Build Support
- AR Foundation with **ARCore XR Plugin 5.1** (resolved from `Packages/manifest.json`)

### Assets not included

Third-party art and audio aren't redistributed here. To run the game as it was, re-import them into the same folders:

| Folder | What it was |
| --- | --- |
| `Assets/Models/` | Zombie characters and walk animations from [Mixamo](https://www.mixamo.com), plus a pistol and a bloater model |
| `Assets/Nokobot/` | *Modern Guns: Handgun* by Nokobot (Unity Asset Store) |
| `Assets/Supercyan Free Forest Sample/` | *Free Forest Sample* by Supercyan (Unity Asset Store) |
| `Assets/Fonts/` | Horror display fonts |
| `Assets/SFX/` | A pistol firing sound |
| `Assets/Images/` | Crosshair, bullet and back-button icons |

Scenes and prefabs will show missing references until those are back in place.
