# MiniPokemon

MiniPokemon es un proyecto en C# (.NET) que implementa un juego o simulador básico inspirado en Pokémon. Este repositorio tiene como objetivo servir como base para aprender programación orientada a objetos, lógica de juego y estructura de proyectos en C#, mientras se recrea un sistema sencillo de criaturas al estilo Pokémon.

## Descripción

MiniPokemon permite gestionar criaturas, combates simples, estadísticas y flujos de juego básicos. Es un proyecto pensado como:

- Ejercicio educativo para aprender C#.
- Punto de partida para implementar mecánicas de RPG/combate.
- Demostración de buenas prácticas de proyecto .NET.

## Estructura del proyecto

```
MiniPokemon/
├── MiniPokemon/            # Código fuente principal (clases, lógica, modelos)
├── .gitignore
├── MiniPokemon.sln         # Solución de Visual Studio / .NET
├── README.md               # Documentación del proyecto
```

## Requisitos

Antes de usar o compilar el proyecto, asegúrate de tener instalado:

- .NET SDK 6.0 o superior
- Un editor compatible como Visual Studio, Visual Studio Code o JetBrains Rider

## Instalación y uso

1. Clona este repositorio:

```bash
git clone https://github.com/albaboo/MiniPokemon.git
cd MiniPokemon
```

2. Abre la solución en tu editor:
   - Visual Studio: abre `MiniPokemon.sln`
   - VS Code: abre la carpeta raíz con soporte .NET

3. Restaura los paquetes y compila:

```bash
dotnet restore
dotnet build
```

4. Ejecuta el proyecto:

```bash
dotnet run --project MiniPokemon/MiniPokemon.csproj
```

## Características

- Modelos de Pokémon con estadísticas básicas (HP, ataque, defensa, velocidad)
- Estructura inicial para combate (turnos, acciones)
- Separación entre lógica de juego y consola/interfaz
- Código organizado en clases reutilizables

### Funcionalidades sugeridas para mejorar

- Sistema de niveles y experiencia
- Interfaz gráfica (Unity, WinForms, WPF)
- Guardado de partidas
- Base de datos de criaturas y ataques

## Tests

Para agregar pruebas unitarias:

```bash
dotnet new mstest -o MiniPokemon.Tests
dotnet add MiniPokemon.Tests reference MiniPokemon/MiniPokemon.csproj
```

More info [here](https://deepwiki.com/albaboo/MiniPokemon)

---

¡Gracias por visitar MiniPokemon! 🐾

