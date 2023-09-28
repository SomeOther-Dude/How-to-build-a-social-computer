# Remote Questionnaire - Unity Client

This is an implementation of a client for the Visual Scene Maker Remote Questionnaire plugin.

For a full description, read here: <https://github.com/SceneMaker/VisualSceneMaker/tree/MindBot/plugins/remoteQuestionnaire>

## Requirements

Requires the `NativeWebSocket` package in your path.

Download from <https://github.com/endel/NativeWebSocket>

## Usage

* Drag the prefab `RemoteQuestionnaire/QuestionnaireGUI` in the scene and configure connecting address and port.
* Run the demo VSM project that you find at the VSM website <https://github.com/SceneMaker/VisualSceneMaker/tree/MindBot/plugins/remoteQuestionnaire/ExampleProject>.

## Command line

The QuestionnaireControl script is scanning command line options to override the IP address and port of the questionnaire server at launch.

* `--questionnaire-socket-address`
  * overrides the VSM socket address as command line argument
  * E.g.: `MindBotAvatarPlayer.exe --questionnaire-socket-address 127.0.0.1:5002`
  * Parsed in script `QuestionnaireControl.cs`
