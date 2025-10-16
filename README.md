# 🎮 Mini-Game Framework (Unity Test Project)

This project demonstrates a **modular micro-component architecture** for managing and integrating multiple mini-games within a single Unity project.

---

## 🧩 Overview

The system splits mini-games into **self-contained blocks**, allowing new games to be easily added without modifying existing code.

Currently, mini-games are represented as **prefabs** instantiated within the main scene.  
However, the architecture is easily extendable to support **scene-based mini-games** in the future.

The project is built around **interfaces** and **abstract base classes**, ensuring clean separation of logic, scalability, and flexibility.

---

## ⚙️ Project Structure

| Component | Description |
|------------|--------------|
| **MiniGameManager** | Entry point of the project. Initializes and manages all mini-games. |
| **PlayerAccount** | Represents player data (currently includes `Name` and `Score`). |
| **MainMenuUI** | Displays the player's profile and a list of available mini-games. Uses `GamePanelUI` and a prefab panel for displaying entries. |
| **MiniGameDefinition** | A `ScriptableObject` containing mini-game metadata (name, icon, prefab reference). Managed by `MiniGameManager`. |
| **Mini-Games** | Actual mini-game implementations (classes, prefabs, interfaces). |

---

## 🧱 Mini-Game Composition

Each mini-game consists of **four core components**:

1. **Root Object / Scene**  
   The root GameObject representing the entire mini-game hierarchy.

2. **Mini-Game Script**  
   Attached to the Root Object. Inherits from the abstract class `MiniGameBase`.

3. **Mini-Game UI**  
   A separate UI prefab (can be a **Prefab Variant** of `MiniGameUIBase`) with its own UI controller script derived from `MiniGameUIBase`.

4. **MiniGameDefinition (ScriptableObject)**  
   Stores the name, icon, and prefab reference of the mini-game.  
   Acts as the **top-level configuration** used by the system — the manager interacts with this object rather than the internal implementation of the mini-game.

---

## 🛠️ How to Create a New Mini-Game

1. **Create a Mini-Game Prefab**  
   - Build your mini-game under a single Root GameObject.  
   - Save it as a prefab representing the entire game.

2. **Add Game Logic**  
   - Attach a custom script to the Root GameObject.  
   - Inherit from `MiniGameBase` and implement all abstract members.  
   - Override `StartGame()` and `StopGame()` — make sure to call the base methods inside (e.g. `base.StartGame()`).

3. **Set Up the UI**  
   - Create a UI prefab (optionally as a Variant of `MiniGameUIBase`).  
   - Add a script derived from `MiniGameUIBase` and implement `InitGameUI()`.

4. **Bind Components in the Inspector**  
   - Assign all required references.  
   - Avoid linking button actions in the Inspector — use code instead:  
     ```csharp
     button.onClick.AddListener(YourMethod);
     ```

5. **Create a MiniGameDefinition**  
   - Create a new ScriptableObject via the menu:  
     **`Create → Configs → MiniGameDefinition`**  
   - Configure its `Name`, `Icon`, and `Prefab` fields.

6. **Register the Mini-Game**  
   - In the main scene, open the `GameManager` object.  
   - Add the new `MiniGameDefinition` to the list of definitions.  
   - The mini-game will now appear in the main menu at runtime.

---

## 🧠 Notes

- The architecture focuses on **loose coupling** and **modularity**.  
- Future extensions could include:
  - Scene-based mini-games (loaded additively).
  - Addressables support for dynamic loading.
  - Shared player profiles and save systems.

---

> 💡 *This project demonstrates a lightweight, scalable framework for integrating multiple mini-games under a unified system in Unity.*
