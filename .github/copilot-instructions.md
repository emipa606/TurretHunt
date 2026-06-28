# GitHub Copilot Instructions

Welcome to the development repository for **Turret Hunt (Continued)**, an evolved adaptation of the original mod by BaalEvan. This document serves as a guide to help you understand and enhance the mod's code using GitHub Copilot.

## Mod Overview and Purpose

**Turret Hunt (Continued)** offers enhanced functionalities to in-game turrets in RimWorld, allowing players to set them in an Auto Hunt mode. This mode mimics the "Drafted Hunt" feature from the AllowTools mod and adds new mechanisms through which players can control turret behavior, such as targeting all animals or only designated ones, including options for downed animals. This enriches the gameplay by making turrets smarter and more autonomous.

## Key Features and Systems

- **Auto Hunt Mode:** Turrets can be set to target animals automatically.
- **Gizmo Buttons:** New interface elements allow players to customize turret behavior:
  - Targeting all animals
  - Focusing only on designated animals
  - Ability to include or exclude downed animals
- **Default Behavior:** After activation, the turret defaults to targeting only designated animals, adjustable via the Gizmos.

## Coding Patterns and Conventions

### C# Patterns

- **Class Naming:** Classes like `Command_TurretHunt`, `TurretHuntSettings`, and `WorldSettings` are prefixed with their module or functionality to maintain organization.
- **Method Naming:** Methods such as `ToggleAction` and `ExposeData` follow a PascalCase style consistent with C# standards.
- **Settings Management:** Use of methods like `ExposeData` ensures persistent saving and loading of user settings through serialization.

### XML Integration

- The `About.xml` is used to define dependencies and meta-information regarding the mod.
- XML files should follow consistent indentation and tag structure to facilitate reading and editing.
- Ensure proper dependency declarations, like `UnlimitedHugs.HugsLib` mentioned in the XML for integrated functionality.

## Harmony Patching

The mod relies on Harmony, loaded via `brrainz.harmony`, to patch and enhance game functionality:

- **Patch Methodology:** Utilize Harmony patches in C# to modify or extend behaviors of existing game methods without altering their original content.
- **Patch Initialization:** Harmonious patches are typically initialized in static constructors or during mod loading events.

## Suggestions for Copilot

When using GitHub Copilot for ongoing development:

1. **Understand Context:** Copilot offers better suggestions when provided context. Ensure comments thoroughly explain the desired code functionality.
2. **Consistency is Key:** Stick to existing naming conventions and coding patterns. This helps Copilot suggest code snippets that fit seamlessly into your project.
3. **Iterate and Refine:** Use Copilot's suggestions as a base. Refine the code manually to ensure it aligns with the functionality and integrates well.
4. **Preexisting Functions:** Guide Copilot to leverage existing utility functions or classes like `TryGetGizmo` to maintain DRY principles.
5. **Debugging and Testing:** Regularly validate Copilot-generated code with your existing systems and testing tools to ensure reliability.

Enhancing Turret Hunt allows for more dynamic and engaging interactions, increasing fun and strategic depth within RimWorld. With these guidelines, you can efficiently enhance or expand the mod's capabilities using Copilot.

---

Please note: This project assumes access to existing libraries and tools such as Harmony and HugsLib. Ensure these dependencies are properly installed and referenced in your development environment.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).

