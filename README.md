# VikingStates
Simple and extensive state manager. Get, set, add, remove, etc. states to manage your game.

# Use
Include `Viking.States`, call `VikingStates.SetState(<State>, <string>, <int>)`. This will set the previous state to the current state, and update the current state to the passed value.

Call `VikingStates.RestoreState()` to reset the current state to the previous state.

This allows for event processing like dialogue. Settings the current state to **Dialogue**, and restoring it to **Game** once done let's you prevent the player from moving, interacting, pausing, etc. while the dialogue is reading (if they're are dependant on the current state).

## Editor
![Editor](/Images/Editor.png)

## Commented Code
![Editor](/Images/VikingStates.png)
![Editor](/Images/States.png)
![Editor](/Images/State.png)

## Project
![Editor](/Images/Project.png)
