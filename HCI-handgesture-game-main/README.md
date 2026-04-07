# HCI hand gesture games

Play classics such as super mario bros, the chrome no-internet dino game and battle city only using hand gestures!

Made in **Python 3.6**.

## Games

- Super Mario Bros: `python mario.py`
- Battle City: `python battle_city.py`
- Chrome Dino: `python dinosaur.py`

## Controls

### Super Mario Bros
The screen is split into 3 equal parts horizontally:
- Open hand (left) -> Left jump
- Closed hand (left) -> Left run
- Open hand (middle) -> Jump
- Closed hand (middle) -> Do nothing
- Open hand (right) -> Right jump
- Closed hand (right) -> Right run

### Battle City
The screen is split into 5 parts:
- Open hand -> Fire
- Closed hand (circle) -> Do nothing
- Closed hand (left triangle) -> Go left
- Closed hand (right triangle) -> Go right
- Closed hand (up triangle) -> Go up
- Closed hand (down triangle) -> Go down

### Chrome Dino
The screen is split into 2 equal parts vertically:
- Closed hand -> Run
- Open hand (upper) -> Jump
- Open hand (lower) -> Duck

## Requirements

- Python 3.6+
- TensorFlow
- OpenCV
- Pygame
- Gym
- pyrealsense2 (for RealSense camera)
