# GitHub Copilot Instructions for RimWorld Modding Project: TurretHunt

## Mod Overview and Purpose

The **TurretHunt** mod for RimWorld is designed to enhance the functionality of turrets, giving them the ability to autonomously hunt wildlife or designated targets within their range. This adds a strategic layer to defensive play styles and provides players with nuanced turret management options.

### Purpose
- To allow players greater control over how turrets engage with game entities.
- To automate hunting tasks, thereby freeing up colonists for other duties.
- To give turrets the ability to selectively target types of creatures or specific threats.

## Key Features and Systems

- **Autonomous Hunting**: Turrets can be toggled to hunt wildlife autonomously, allowing them to act as advanced defensive structures.
  
- **Target Designation**: Players can choose which specific targets the turrets should prioritize, adding a tactical element.
  
- **Kill Downed Option**: Turrets can be set to kill downed targets, ensuring threats are neutralized.

- **Configurable Settings**: Various aspects of turret behavior can be adjusted through mod settings, providing flexible control to the player.

## Coding Patterns and Conventions

- **Class Structure**: This project utilizes multiple classes, each with focused responsibilities for modularity and clarity.
  
- **Naming Conventions**: Classes and methods are named using PascalCase, while parameters and fields use camelCase, following C# conventions.
  
- **Access Modifiers**: Use of `public`, `internal`, and `private` access modifiers to encapsulate functionality appropriately.
  
- **Design Patterns**: Utilizes the Singleton pattern for `DefOf` class to ensure definitions are consistent and easy to reference.

## XML Integration

- **XML Defs**: Integration of XML files is done to define the static properties and behaviors for the turrets, allowing easy adjustments without recompiling the C# code.

- **Harmony Patches**: XML integration works alongside Harmony patches for smooth addition and modification of game behaviors without altering original source code.

## Harmony Patching

- **Purpose**: To modify existing game methods where appropriate, ensuring compatibility and functionality with the vanilla game mechanics.
  
- **Implementation**: Harmony is used to patch methods, enabling modifications like adding new toggles or altering turret target acquisition logic.

## Suggestions for Copilot

- **Method Completion**: Utilize Copilot to auto-generate method headers based on existing patterns, such as `ToggleTurretHunting`, which follow common function design.

- **XML Definition Helper**: Suggest XML tags or C# property definitions based on standard RimWorld defs to ensure consistency and correctness.

- **Harmony Patch Skeletons**: Copilot can assist in setting up skeletons for new Harmony patches, ensuring that all necessary attributes and classes are properly implemented.

- **Code Refactoring Suggestions**: Identify areas where code can be refactored to enhance readability or performance, providing suggestions for inline changes.

By adhering to these structures and guidelines, contributors can maintain consistency throughout the project, leverage GitHub Copilot for productivity boosts, and ensure the mod remains robust, maintainable, and extendable.
