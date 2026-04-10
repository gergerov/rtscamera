# rtscamera

камера для  режима стратегии

![Unity](https://img.shields.io/badge/-Unity-blue)

## Installation
скопировать папку целиком в assets проекта

## Usage

- добавить на сцену префаб PlayerEmpty
- добавить на сцену префаб RTSCamera
- для главной камеры добавить компонент cinemachinebrain
- добавить к PlayerEmpty стандартный CharacterController
- добавить к PlayerEmpty PlayerEmptyController
- добавить к PlayerEmpty InputHandler
- у  RTSCamera в свойство tracking target добавить PlayerEmpty 
- у PlayerEmpty в компоненте InputHandler установить CamRTS камеру RTSCamera 

-настроить вид для CamRTS с учетом параметров камеры у PlayerEmptyController

## License

[MIT](LICENSE)
