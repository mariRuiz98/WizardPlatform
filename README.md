# Documento de Mecánicas del Juego: Outer Realm

**Outer Realm** es un juego de plataformas 2D desarrollado siguiendo las pautas establecidas en las clases. Este documento detalla las mecánicas y elementos principales implementados en el juego.

## CONTROLES
- **WASD**: Para mover al player.
- **Espacio**: Para saltar.
- **Click izquierdo del ratón**: Para atacar.
- **Tecla E**: Para entrar al mítico Pipe Final y completar el nivel.

## 1. Mapa y Diseño de Entornos

- **Parallax**: Se utiliza la técnica de parallax para dar profundidad visual al fondo del mapa, creando un entorno inmersivo y dinámico.
- **Tiles y Normas de Dibujo**: Las plataformas han sido diseñadas mediante tiles, se ha hecho uso de establecer las normas de pintado y su posterior uso en el Tile Palette para implementar el background y el suelo colisionable.
- **Iluminación**: El ambiente se mejora mediante la implementación de **Light 2D** en las farolas del mapa, proporcionando un toque estético y una sensación de atmósfera viva.

## 2. HUD

El HUD del juego incluye:
- **Barra de Vida Progresiva**: Representa la vida del jugador.
- **Timer**: Muestra el tiempo disponible para completar el nivel.
- **Score**: Refleja la puntuación obtenida en función de los enemigos derrotados.

## 3. Mecánicas de Juego

### Enemigos
- **Slime**: Movimiento patrulla y ataque directo.
- **Bat**: Movimiento aéreo con trayectorias patrulla.
- **Wizard**: Ataques a distancia con proyectiles.
- Todos los enemigos cuentan con animaciones de movimiento y/o ataque para enriquecer la experiencia visual.

### Jugador
- Animaciones de movimiento, idle y ataque.
- Restauración de vida mediante **Medical Packs**, que se pueden recoger durante el nivel.

### Daño
- Efecto de daño en pantalla completa al recibir impactos, agregando dramatismo y peso a la acción.

### Pipe Final (Meta)
- Elemento interactuable que permite pasar de un nivel a otro.
- Se utiliza un sistema de colliders y tags para detectar al jugador.
- El jugador debe presionar la tecla **E** para entrar al Pipe Final.
- Se incluye un pasillo de luces que dirige al jugador hacia la meta, enfatizando el momento final de cada nivel.

## 4. Transiciones y Escenas

### Transiciones
- Se han implementado animaciones de **FadeIn** y **FadeOut** para cambios fluidos entre escenas.

### Escenas Desarrolladas
- **MainMenu**: Pantalla principal con opciones de inicio y configuración.
- **Platforms**: Escena principal donde se desarrollan los niveles.
- **EndGame**: Escena que aparece tras completar con éxito el último nivel.
- **GameOver**: Escena que se muestra cuando el jugador pierde todas sus vidas.

## 5. Menú de Pausa
- Se incluye un menú de pausa funcional que permite al jugador detener el juego y acceder a opciones como reanudar o salir al menú principal.

## 6. Música y Sonido
- Se incorpora música de fondo en todos los niveles para mejorar la inmersión.
- Se incluyen efectos sonoros para interacciones con botones.

## Links
- **Repositorio GitHub**: [https://github.com/mariRuiz98/WizardPlatform.git](https://github.com/mariRuiz98/WizardPlatform.git)
- **Juego itch.io**: [https://mburriez.itch.io/outer-realm](https://mburriez.itch.io/outer-realm)