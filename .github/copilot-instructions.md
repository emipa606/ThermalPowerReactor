# GitHub Copilot Instructions for Thermal Power:Reactor (Continued)

## Mod Overview and Purpose

**Mod Name:** Thermal Power:Reactor (Continued)  
**Author:** [cn]nuclear  
**PackageId:** Mlie.ThermalPowerReactor

**Description:**  
Thermal Power:Reactor (Continued) is an update and continuation of a nuclear power mod for the popular game RimWorld. The mod introduces two types of reactors—one using uranium and another using hydrogen—that can generate heat. Additionally, it includes thermal power generators that can convert this heat into energy. The mod also integrates Harmony for compatibility with recent changes in the game's vanilla mechanics.

## Key Features and Systems

1. **Reactor Types:**
   - **Uranium Reactor:** Utilizes uranium as fuel and is a controlled nuclear fission reactor.
   - **Hydrogen Reactor:** Employs hydrogen as fuel and is a controllable hydrogen fusion reactor.
   - **Thermal Power Generators:** Operate using high temperatures to drive dynamos.

2. **Heat Generation:**
   - The mod introduces two new heaters that can be placed in enclosed, fireproof rooms.
   - Thermoelectric generators are placed on walls, similar to AC units, with the heat-side facing outward.

3. **XML Integration:**
   - The mod extensively uses XML files to define new research projects, buildings, recipes, and power-related thing definitions.

4. **Harmony Patching:**
   - Harmony is utilized to adjust the maximum temperature for rooms to match the previous values, ensuring compatibility with recent updates to vanilla RimWorld.

## Coding Patterns and Conventions

- **C# Files:**
  - The mod's C# code is organized into several files, each focusing on specific functionalities:
    - `CompTempControl_InterfaceChangeTargetTemperature.cs`: Handles temperature control interface changes.
    - `TR.cs`: Contains main mod logic.
    - `TReactor.cs` and `TReactorHuge.cs`: Manage the tick behavior for different reactor sizes.
    - `Main.cs`: Initializes the mod.

- **Naming Conventions:**
  - Class names are descriptive, such as `TReactor` and `CompTempControl_InterfaceChangeTargetTemperature`.
  - Method names use camelCase, with meaningful prefixes and suffixes (e.g., `Postfix`, `Prefix`).

- **Code Structure:**
  - Each class has a clear purpose, and methods are logically grouped based on their functionality.
  - Proper use of comments and documentation to explain complex logic.

## XML Integration

- **ResearchProjectDefs:**
  - Defines new research projects related to nuclear and hydrogen power generation.
  - Example: `ResearchProjects_Nuclear_Heater.xml`

- **ThingDef:**
  - Contains definitions for new buildings, crafting recipes, and power-related items.
  - Example: `Buildings_Nuclear_Heater.xml`, `Carfting_Hydrogen.xml`

- **RecipeDef:**
  - Defines recipes for crafting hydrogen from chemfuel.
  - Example: `Carfting_Hydrogen.xml`

- **PowerDefs:**
  - Contains definitions for power-related items.
  - Example: `Power_Iteam.xml`, `Temperature_Power.xml`

## Harmony Patching

- **Purpose:** To ensure compatibility with recent updates to vanilla RimWorld, especially changes to room maximum temperatures.
- **Usage:**
  - Harmony patches are applied in the `Main.cs` file.
  - Patches adjust the maximum temperature for rooms to match previous values, ensuring that power output remains consistent.

## Suggestions for Copilot

1. **Feature Requests:**
   - **Additional Reactor Types:** Suggest adding more types of reactors (e.g., Thorium-based) with unique properties.
   - **Advanced Heat Management:** Implement more advanced heat management features, such as heat exchangers or thermal insulation.

2. **Bug Fixes:**
   - **Stability Issues:** Address any stability issues or crashes that may occur with the current implementation.
   - **Performance Optimization:** Optimize performance for large maps or high reactor counts.

3. **Localization:**
   - **Language Support:** Add support for more languages to expand the mod's accessibility to a global audience.

4. **User Interface:**
   - **Improved UI:** Enhance the user interface to provide clearer instructions and easier management of reactors and generators.

5. **Documentation:**
   - **Comprehensive Guides:** Create comprehensive guides and tutorials to help new users understand and set up the mod.

## Conclusion

Thermal Power:Reactor (Continued) is a robust and feature-rich mod for RimWorld that introduces innovative ways to generate and manage heat-based power. By following the coding patterns and conventions outlined above, and leveraging Harmony patching for compatibility, the mod ensures a seamless and enjoyable experience for players. We welcome contributions and suggestions from the community to further enhance this mod.

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
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

