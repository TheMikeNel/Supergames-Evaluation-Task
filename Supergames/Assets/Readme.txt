EN: 
?? Mini-Game Architecture Overview

The project implements a modular architecture where each mini-game exists as an independent, self-contained block.
At the current stage, mini-games are represented as prefabs that are instantiated directly in the main scene.
However, the system can be easily extended to support scene-based mini-games in the future.

The architecture is built around abstractions using interfaces and abstract base classes, ensuring flexibility, scalability, and clean separation of logic.


?? Project Structure

The project consists of the following key components:

1. MiniGameManager – the entry point of the project.
Initializes the list of all available mini-games at startup and manages their lifecycle.

1. PlayerAccount – represents the player profile (currently stores only Name and Score).

3. MainMenuUI – the main menu interface that displays the player’s name and the list of available mini-games.
The mini-game entries are handled through the GamePanelUI class and its associated panel prefab.

4. MiniGameDefinition – ScriptableObject configurations for mini-games, used by MiniGameManager to manage and launch them.

5. Mini-Games – the actual mini-game implementations (classes, interfaces, and prefabs).


?? Mini-Game Composition

Each mini-game consists of four main components:

1. Root Object / Scene – the root GameObject that represents the mini-game hierarchy.

2. Mini-Game Script – attached to the Root Object, inheriting from the abstract class MiniGameBase.

3. Mini-Game UI – a separate UI prefab (optionally a Prefab Variant of MiniGameUIBase) containing its own UI script derived from MiniGameUIBase.

4. MiniGameDefinition (ScriptableObject) – the data asset that stores the mini-game’s name, icon, and prefab reference.
This serves as the top-level entry point for the system, allowing MiniGameManager to work with the mini-game without depending on its internal implementation.


??? How to Create a New Mini-Game

1. Create the Mini-Game Prefab
Build your mini-game hierarchy under a single Root GameObject that represents the entire game as a prefab.

2. Add the Game Logic
Attach a custom script to the Root GameObject.
This script must inherit from the abstract class MiniGameBase and implement all required abstract members.
Override StartGame() and StopGame(), ensuring that you call the corresponding base methods at the end (e.g., base.Init(...), base.StartGame(), base.StopGame()).

3. Set Up the UI
Create a UI prefab (preferably as a Variant of MiniGameUIBase) and attach a UI script that inherits from MiniGameUIBase.
Implement your custom initialization logic inside InitGameUI().

4. Bind Components in the Inspector
Assign all required references in the Inspector.
Avoid assigning button events directly through the Unity Inspector; instead, add them via code using button.onClick.AddListener(YourMethod).

5. Create the Mini-Game Definition
Create a new ScriptableObject (menuName = "Configs/MiniGameDefinition") and configure its name, icon, and prefab reference.

6. Register the Mini-Game
In the main scene, open the GameManager object and add your new MiniGameDefinition to the list of definitions.
The mini-game will then be automatically recognized and available at runtime.




RU:
В проекте реализовано разбиение мини-игр на обособленные блоки. Пока что миниигры могут представлять из себя только префабы. И они будут создаваться в основной сцене.
В перспективе несложно внедрить и мини-игры в виде сцен. Архитектура основана на абстракциях в виде интерфейсов и абстрактных классов и 

Проект состоит из:
1. MiniGameManager - EntryPoint проекта, при старте инициализирует список имеющихся в системе мини-игр.
3. PlayerAccount - аккаунт игрока (пока что имеет только имя и игровой счёт Score).
4. MainMenuUI - главное меню, где игрок увидит своё имя и список доступных мини-игр (для отображения мини-игр есть отдельный класс GamePanelUI и префаб панели).
2. MiniGameDefinitions - ScriptableObject-определения миниигр, с которыми и работает MiniGameManager.
3. Сами мини-игры (Классы мини-игр, интерфейсы, и префаб).

Мини-игра состоит из 4х компонентов:
1. Сцена мини-игры внутри Root-компонента.
2. На Root-компоненте - скрипт мини-игры, дочерний от MiniGameBase
3. UI мини-игры (можно использовать Prefab Variant от MiniGameUI Base), на котором также будет скрипт - дочерний от MiniGameUIBase.
4. MiniGameDefinition - ScriptableObject мини-игры, содержащий название, иконку и ссылку на префаб мини-игры. Верхний элемент и конечная точка мини-игры, с которой и работает в дальнейшем весь проект не затрагивая внутреннюю реализацию мини-игры.

Чтобы создать мини-игру:
1. Собрать свою сценку внутри корневого - Root-объекта, который будет представлять всю игру в виде префаба.
2. На этот Root-объект создать свой скрипт мини-игры, который должен быть унаследован от абстрактного класса MiniGameBase. Реализовать все абстрактные члены класса, а также перезаписать по своему методы StartGame и StopGame с обязательным вызовом в конце этих же методов из base (base.Init(...)/StartGame()/StopGame)
3. Создать UI для своей мини-игры (можно использовать Prefab Variant от MiniGameUI Base) и UI-скрипт для него, который будет унаследован от абстрактного класса MiniGameUIBase. Реализовать свою инициализацию из абстрактного класса - InitGameUI();
4. В скриптах мини игры и UI, в инспекторе привязать все нужные компоненты, для кнопок не стоит делать привязку Actions в Inspector. В проекте это реализуется в коде (button.AddListener(YourMethod)).
5. Создать и настроить MiniGameDefinition (menuName = Configs/MiniGameDefinition).
6. В основной сцене, в объекте GameManager добавить Definition в список игр. Тогда игра будет учитываться при запуске.